using CompilerApp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerApp.utils
{
    class NFA_DFA_MFAUtil
    {
        private char[] _formulaChars = { '|', '*', '(', ')' }; // 正则式组成字符
        private char[] _notBracket = { '|', '*' }; // 非括号字符
        public PathList nfaPathList = null; // nfa 路径列表
        public List<SortedSet<int>> T = new List<SortedSet<int>>(); // 对NFA构造的子集
        public List<string> tStr = new List<string>(); // 子集转换为字符串

        public NFA_DFA_MFAUtil()
        {
            Array.Sort(_formulaChars);
            Array.Sort(_notBracket);
        }


        /// <summary>
        /// 验证正规式是否合法
        /// </summary>
        /// <param name="formula">输入的正规式</param>
        /// <param name="left">formula最左边的索引</param>
        /// <param name="right">formula最右边的索引</param>
        /// <returns>是否合法 合法为true 非法为false</returns>
        public bool verifyFormalFormula(string formula, int left, int right)
        {
            Debug.WriteLine("验证正规式是否合法...");
            bool isValid = false;
            if (formula.Length <= 0 || isExist(_notBracket, formula[0]) || formula[formula.Length - 1] == '|') return false;
            for (int i = left; i < right; i++)
            {
                char cur = formula[i];
                if (char.IsLetter(cur) || cur == '*') continue;
                else if (cur == '|') // |* || 非法
                    if (i + 1 < right && isExist(_notBracket, formula[i + 1])) return false;
                    else continue;
                else if (cur == '(')
                {
                    int idx = i, lCnt = 0;
                    for (; idx < right; idx++)
                    {
                        if (formula[idx] == '(') lCnt++;
                        else if (formula[idx] == ')')
                        {
                            lCnt--;
                            if (lCnt == 0)
                            {
                                Debug.WriteLine(formula.Substring(i + 1, idx - i - 1));
                                isValid = verifyFormalFormula(formula, i + 1, idx - 1);
                                break;
                            }
                        }
                    }
                    if (!isValid)
                    {
                        Debug.WriteLine("isValid = false");
                        return false;
                    }
                    isValid = false;
                    i = idx;
                }
                else
                {
                    Debug.WriteLine(cur.ToString());
                    Debug.WriteLine("else");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 将合法的正规式转化为NFA
        /// </summary>
        /// <param name="formula">正规式</param>
        /// <param name="left">最左索引</param>
        /// <param name="right">最右索引</param>
        /// <returns>路径列表</returns>
        public PathList formulaToNFA(string formula, int left, int right)
        {
            Debug.WriteLine("正规式转NFA...");
            Debug.WriteLine("输入的正规式是：", formula);

            for (int i = left; i < right; i++)
            {
                char cur = formula[i];

                if (char.IsLetter(cur))
                {
                    if (nfaPathList != null) nfaPathList.connectPathList(new PathList(cur));
                    else nfaPathList = new PathList(cur);
                }
                else if (cur == '(')
                {
                    int rPos = findRightBracket(formula, i, right);
                    if (nfaPathList != null) nfaPathList.connectPathList(formulaToNFA(formula, i + 1, rPos));
                    else nfaPathList = formulaToNFA(formula, i + 1, rPos);
                    i = rPos;
                }
                else if (cur == '*') nfaPathList.closurePathList();
                else if (cur == '|')
                {
                    cur = formula[++i];
                    if (char.IsLetter(cur)) nfaPathList.parallelPathList(new PathList(cur));
                    else if (cur == '(')
                    {
                        int rPos = findRightBracket(formula, i, right);
                        nfaPathList.parallelPathList(formulaToNFA(formula, i + 1, rPos));
                        i = rPos;
                    }
                }
            }

            return nfaPathList;
        }

        /// <summary>
        /// 将NFA转换为DFA
        /// </summary>
        /// <returns>转换后的DFA</returns>
        public PathList NFAToDFA()
        {
            T = new List<SortedSet<int>>();
            Debug.WriteLine("nfa to dfa...");
            List<Path> paths = new List<Path>();
            List<char> vals = getVals().ToList();
            int cnt = 0;

            SortedSet<int> set = new SortedSet<int>();
            set.Add(nfaPathList.head);
            T.Add(emptyClosure(set));
            tStr.Add(String.Join(",", emptyClosure(set).ToList()));
            cnt++;
            Debug.WriteLine("closure(0): " + String.Join(",", emptyClosure(set).ToList()));

            for (int i = 0; i < T.Count; i++)
            {
                SortedSet<int> t = T[i];
                vals.ForEach(val =>
                {
                    Debug.WriteLine("val: " + val);
                    SortedSet<int> u = emptyClosure(move(t, val));
                    string uStr = string.Join(",", u.ToList());
                    Debug.WriteLine("u: " + uStr);
                    
                    if (uStr != "" && !isExist(tStr.ToArray(), uStr))
                    {
                        paths.Add(new Path(i, cnt++, val));
                        Debug.WriteLine("add....");
                        T.Add(u);
                        tStr.Add(uStr);
                    } 
                    else
                    {
                        int end = tStr.FindIndex(str => str == uStr);
                        paths.Add(new Path(i, end, val));
                    }
                });
            }

            Debug.WriteLine("============result============");
            tStr.ForEach(val => Debug.WriteLine(val.ToString()));

            return new PathList(0, cnt - 1, paths);
        }
     
        
        /// <summary>
        /// 拿到NFA中所有的输入字符集
        /// </summary>
        /// <returns>NFA中的输入字符集</returns>
        private HashSet<char> getVals()
        {
            HashSet<char> vals = new HashSet<char>();
            for (int i = 0; i < nfaPathList.paths.Count; i++) {
                if (nfaPathList.paths[i].val != '#') vals.Add(nfaPathList.paths[i].val);
            }
            return vals;
        }

        /// <summary>
        /// 空串闭包
        /// </summary>
        /// <param name="I">输入状态集合I</param>
        /// <returns>状态集合I通过任意次空串所能到达的集合</returns>
        private SortedSet<int> emptyClosure(SortedSet<int> I)
        {
            List<Path> paths = nfaPathList.paths;
            SortedSet<int> ret = new SortedSet<int>();
            HashSet<int> mark = new HashSet<int>();
            List<int> iCopy = I.ToList();


            for (int i = 0; i < iCopy.Count; i++)
            {
                int cur = iCopy[i];
                ret.Add(cur);
                if (mark.Contains(cur))
                    continue;
                for (int j = 0; j < paths.Count; j++)
                {
                    Path curPath = paths[j];
                    if (cur == curPath.start && curPath.val == '#')
                        iCopy.Add(curPath.end);
                }
                mark.Add(cur);
            }


            return ret;
        }

        /// <summary>
        /// 对集合作move操作
        /// </summary>
        /// <param name="I">状态集合I</param>
        /// <param name="val">经过的弧</param>
        /// <returns>move过的状态集合</returns>
        private SortedSet<int> move(SortedSet<int> I, char val)
        {
            SortedSet<int> ret = new SortedSet<int>();
            List<Path> paths = nfaPathList.paths;
            List<int> iCopy = I.ToList();
            for (int i = 0; i < iCopy.Count; i++)
                for (int j = 0; j < paths.Count; j++)
                    if (paths[j].start == iCopy[i] && paths[j].val == val)
                        ret.Add(paths[j].end);
            return ret;
        }

        /// <summary>
        /// 判断t是否存在于ts中
        /// </summary>
        /// <typeparam name="T">任意类型</typeparam>
        /// <param name="ts">任意类型的数组</param>
        /// <param name="t">任意类型</param>
        /// <returns>true: 存在</returns>
        private bool isExist<T>(T[] ts, T t)
        {
            Array.Sort(ts);
            return Array.BinarySearch(ts, 0, ts.Length, t) >= 0;
        }

        /// <summary>
        /// 找到正则式中与当前左括号匹配的右括号的下标
        /// </summary>
        /// <param name="formula">正则式</param>
        /// <param name="idx">idx为左括号位置</param>
        /// <param name="right">检查到right</param>
        /// <returns>匹配的右括号的下标</returns>
        private int findRightBracket(string formula, int idx, int right)
        {
            int lCnt = 0;
            for (; idx < right; idx++)
            {
                if (formula[idx] == '(') lCnt++;
                else if (formula[idx] == ')') lCnt--;
                if (lCnt == 0) break;
            }
            return idx;
        }
    }
}
