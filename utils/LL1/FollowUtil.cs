using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.utils.LL1
{
    public class FollowUtil
    {
        public Dictionary<string, HashSet<string>> FollowSet = new Dictionary<string, HashSet<string>>(); // Follow集合
        List<string> unTs = GrammarUtil.unTSet.ToList();

        public void genFollowSet()
        {
            unTs.ForEach(unT => FollowSet.Add(unT, new HashSet<string>()));
            FollowSet[unTs.First()].Add("#");

            bool flag = true;
            while (flag)
            {
                flag = false;
                unTs.ForEach(unT =>
                {
                    if (Follow(unT)) flag = true;
                });
            }
            GrammarUtil.FollowSet = FollowSet;
        }


        public bool Follow(string unT)
        {
            bool changed = false;
            char t = unT[0];
            unTs.ForEach(otherUnT =>
            {
                List<string> rights = GrammarUtil.TransferDict[otherUnT].ToList();
                rights.ForEach(right =>
                {
                    int i = 0;
                    for (; i < right.Length; i++)
                    {
                        if (right[i] == t)
                        {
                            bool next = true;
                            while (next && ++i < right.Length)
                            {
                                next = false;
                                string curChar = right[i].ToString();
                                if (GrammarUtil.isTerminal(curChar))
                                    FollowSet[unT].Add(curChar);
                                else // 如果为非终结符
                                {
                                    if (GrammarUtil.canToEmptyUnTSet[curChar] == unTStatus.Yes) next = true;
                                    if (addFollowSet(unT, curChar)) changed = true;
                                }
                            }
                            if (next) i--;
                        }
                    }
                    if (i == right.Length && right.Contains(unT))
                    {
                        // 指针到了最后把Follow(otherUnt)加入
                        FollowSet[otherUnT].ToList().ForEach(follow =>
                        {
                            if (!FollowSet[unT].Contains(follow)) changed = true;
                            FollowSet[unT].Add(follow);
                        });
                    }
                });

            });
            return changed;
        }

        private bool addFollowSet(string unT, string otherUnT)
        {
            bool res = false;
            GrammarUtil.FirstSet[otherUnT].ToList().ForEach(first =>
            {
                if (!FollowSet[unT].Contains(first)) res = true;
                FollowSet[unT].Add(first);
            });
            return res;
        }
    }
}
