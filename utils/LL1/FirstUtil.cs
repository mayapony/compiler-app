using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilerApp.utils.LL1
{
    public class FirstUtil
    {
        public Dictionary<string, HashSet<string>> TransferDict = GrammarUtil.TransferDict;
        public Dictionary<string, unTStatus> canToEmptyUnTSet = GrammarUtil.canToEmptyUnTSet;
        public HashSet<string> unTSet = GrammarUtil.unTSet;  // 非终结符集合

        public Dictionary<string, HashSet<string>> FirstSet = new Dictionary<string, HashSet<string>>(); // First集合

        /// <summary>
        /// 计算First集
        /// </summary>
        public void genFirstSet()
        {
            genCanToEmptyUnTSet();

            bool flag = true; // 标志First集有没有改变
            unTSet.ToList().ForEach(unT => FirstSet.Add(unT, new HashSet<string>()));
            while (flag)
            {
                flag = false;
                unTSet.ToList().ForEach(unT =>
                {
                    if (First(unT)) flag = true;
                });
            }

            GrammarUtil.FirstSet = FirstSet;
        }

        private bool First(string unT)
        {
            bool changed = false;
            TransferDict[unT].ToList().ForEach(right =>
            {
                // right 是产生式的一个右部
                HashSet<string> curUnTFirsts = FirstSet[unT];
                string Y1 = right.First().ToString(); // 产生式右部第一个字符

                // 1. 如果是终结符 则加入First集
                if (GrammarUtil.isTerminal(Y1) && !curUnTFirsts.Contains(Y1))
                {
                    FirstSet[unT].Add(Y1);
                    changed = true;
                }
                // 2. 如果不是终结符
                else if (!GrammarUtil.isTerminal(Y1))
                {
                    // 如果是非终结符，并且能推出空
                    int i = 0;
                    for (i = 0; i < right.Length; i++)
                    {
                        string Yi = right[i].ToString();
                        if (GrammarUtil.isTerminal(Yi) || canToEmptyUnTSet[Yi] != unTStatus.Yes) break;

                        if (First(Yi)) changed = true;

                        FirstSet[Yi].ToList().ForEach(f =>
                        {
                            if (!curUnTFirsts.Contains(f) && f != GrammarUtil.empty)
                            {
                                FirstSet[unT].Add(f);
                                changed = true;
                            }
                        });
                    }
                    if (i < right.Length)
                    {
                        string Yi = right[i].ToString();
                        if (First(Yi)) changed = true;
                        FirstSet[Yi].ToList().ForEach(f =>
                        {
                            if (!curUnTFirsts.Contains(f))
                            {
                                FirstSet[unT].Add(f);
                                changed = true;
                            }
                        });
                    }
                    else if (i == right.Length && !FirstSet[unT].Contains(GrammarUtil.empty))
                    {
                        FirstSet[unT].Add(GrammarUtil.empty);
                        changed = true;
                    }
                }
            });
            return changed;
        }
        private bool canToEmpty(string unT)
        {
            return TransferDict[unT].Contains(GrammarUtil.empty);
        }

        private bool cantToEmpty(string unT)
        {
            // 非终结符unT的右部 全都有非终结符 则不可能到空
            int cnt = 0;
            TransferDict[unT].ToList().ForEach(right =>
            {
                Regex regex = new Regex(".?[a-z]+.?");
                if (regex.IsMatch(right)) cnt++;
            });
            return cnt == TransferDict[unT].ToArray().Length;
        }

        /// <summary>
        /// 判断是否能从右部产生式到达空
        /// </summary>
        /// <param name="unT">左部非终结符</param>
        /// <returns>true: 能到空</returns>
        private bool canToEmptyFromRight(string unT)
        {
            string[] rights = TransferDict[unT].ToArray();

            // 如果右部有字符 有字符是终结符 或者 为不可推到空的终结符 或待定则返回false
            foreach (string right in rights)
            {
                int cnt = 0;
                foreach (char ch in right)
                    if (!GrammarUtil.isTerminal(ch.ToString()) && canToEmptyUnTSet[ch.ToString()] == unTStatus.Yes) cnt++;
                if (cnt == right.Length) return true;
            }

            return false;
        }

        /// <summary>
        /// 判断是否不能从产生式右部到空
        /// </summary>
        /// <param name="unT">非终结符</param>
        /// <returns>true: 不能到空</returns>
        private bool cantToEmptyFromRight(string unT)
        {
            string[] rights = TransferDict[unT].ToArray();
            int cnt = 0;
            foreach (string right in rights)
                foreach (char ch in right)
                    if (GrammarUtil.isTerminal(ch.ToString()) || char.IsUpper(ch) && canToEmptyUnTSet[ch.ToString()] == unTStatus.No)
                    {
                        cnt++;
                        break;
                    }
            return cnt == rights.Length;
        }

        /// <summary>
        /// 判断每个非终结符是否能到空，并保存
        /// </summary>
        private void genCanToEmptyUnTSet()
        {
            List<string> unTList = unTSet.ToList();
            // 1. 初值为未定
            unTList.ForEach(unT =>
            {
                if (!canToEmptyUnTSet.ContainsKey(unT))
                    canToEmptyUnTSet.Add(unT, unTStatus.unKnown);
            });

            // 2. 扫描文法产生式
            unTList.ForEach(unT =>
            {
                if (cantToEmpty(unT)) canToEmptyUnTSet[unT] = unTStatus.No;
                else if (canToEmpty(unT)) canToEmptyUnTSet[unT] = unTStatus.Yes;
            });

            // 3. 扫描产生式右部每一符号
            bool flag = true; // 标志非终结符对应特征是否改变
            while (flag)
            {
                flag = false;
                unTList.ForEach(unT =>
                {
                    if (canToEmptyUnTSet[unT] == unTStatus.unKnown)
                        if (canToEmptyFromRight(unT)) { canToEmptyUnTSet[unT] = unTStatus.Yes; flag = true; }
                        else if (cantToEmptyFromRight(unT)) { canToEmptyUnTSet[unT] = unTStatus.No; flag = true; }
                });
            }
            GrammarUtil.canToEmptyUnTSet = canToEmptyUnTSet;
        }

    }
}
