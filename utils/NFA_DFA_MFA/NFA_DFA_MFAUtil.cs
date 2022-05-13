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
        public PathList dfaPathList = null; // dfa 路径列表
        public PathList mfaPathList = null; // mfa 路径列表
        public List<SortedSet<int>> C = new List<SortedSet<int>>(); // 对NFA构造的子集
        public List<string> tStr = new List<string>(); // 子集转换为字符串
        public List<SortedSet<int>> stateSets = new List<SortedSet<int>>(); // 划分出的状态集
        public List<char> inputCharSets = null; // 输入字符集

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
            Debug.WriteLine("输入的正规式是：" + formula.Substring(left, right - left));
            PathList subPathList = null;
            // ad(bc | bd) * bd
            for (int i = left; i < right; i++)
            {
                char cur = formula[i];

                if (char.IsLetter(cur))
                {
                    PathList newPathList = new PathList(cur);
                    if (i + 1 < right && formula[i + 1] == '*') newPathList.closurePathList();
                    if (subPathList != null) subPathList.connectPathList(newPathList);
                    else subPathList = newPathList;
                }
                else if (cur == '(')
                {
                    int rPos = findRightBracket(formula, i, right);
                    PathList newPathList = formulaToNFA(formula, i + 1, rPos);
                    if (rPos + 1 < right && formula[rPos + 1] == '*')
                    {
                        newPathList.closurePathList();
                    }
                    if (subPathList != null) subPathList.connectPathList(newPathList);
                    else subPathList = newPathList;
                    i = rPos;
                }
                else if (cur == '|')
                {
                    //cur = formula[++i];
                    PathList newPathList = formulaToNFA(formula, i + 1, right);
                    subPathList.parallelPathList(newPathList);
                    break;
                }
            }

            nfaPathList = subPathList;
            return subPathList;
        }

        /// <summary>
        /// 将NFA转换为DFA
        /// </summary>
        /// <returns>转换后的DFA</returns>
        public PathList nfa2dfa()
        {
            // 输入字符集 如上例为 [a, b]
            inputCharSets = getInputCharSets(nfaPathList).ToList();
            dfaPathList = null;
            // C为一个列表 存放一系列有序集合（SortedSet）（同书中实例代码段的C）
            C = new List<SortedSet<int>>();
            Debug.WriteLine("nfa to dfa...");
            // 待构造的dfa的路径序列
            List<Path> paths = new List<Path>();
            int cnt = 0; // 当前C中已经存放了多少个集合

            SortedSet<int> set = new SortedSet<int>();
            set.Add(nfaPathList.head.ElementAt(0));

            /**
             * 初始时K0的闭包是C中的唯一成员
             * 这里说一下tStr列表的作用：
             * tStr集合保存的是一系列由C中的集合转换而成的字符串，由于集合是有序集合（集合中的元素唯一）
             * 所以不同的有序集合所转换为的字符串肯定也是不同的，所以这里用tStr来检测，新构成的集合是否存在过 
             **/
            C.Add(emptyClosure(set));
            tStr.Add(String.Join(",", emptyClosure(set).ToList()));
            cnt++;
            Debug.WriteLine("closure(0): " + String.Join(",", emptyClosure(set).ToList()));

            // 注意这个循环中的C.Count 在后期向C中添加元素时这个Count是会增加的
            for (int i = 0; i < C.Count; i++)
            {
                // 这个t即为未被标记的集合
                SortedSet<int> t = C[i];
                // 用输入字符集中的每一个字符 对t进行move操作并求闭包
                inputCharSets.ForEach(val =>
                {
                    // 对t进行move操作并求闭包得到集合u
                    SortedSet<int> u = emptyClosure(move(t, val, nfaPathList));
                    // 将得到的u转换为对应的字符串 （例：[1, 2, 3] -> "1, 2, 3"）
                    string uStr = string.Join(",", u.ToList());
                    // 如果uStr不为空并且未被标记过（这里如果tStr里存在uStr说明它已经被标记过了（因为for循环已经进行过它） 这里需要理解一下）
                    if (uStr != "" && !isExist(tStr.ToArray(), uStr))
                    {
                        // 这里要添加一条弧 因为能从当前节点i（对应C中一个集合）通过输入字符val进行到cnt
                        paths.Add(new Path(i, cnt++, val));
                        // 将u添加到C
                        C.Add(u);
                        // 将u转换成的字符串添加到tStr
                        tStr.Add(uStr);
                    }
                    else // 如果u集合已经存在过
                    {
                        // 找到它在C中对应到的下标
                        int end = tStr.FindIndex(str => str == uStr);
                        if (end != -1)
                            // 添加一条路径 从 i ---val---> end
                            paths.Add(new Path(i, end, val));
                    }
                });
            }

            Debug.WriteLine("============result============");
            tStr.ForEach(val => Debug.WriteLine(val.ToString()));

            SortedSet<int> tail = new SortedSet<int>();
            for (int i = 0; i < C.Count; i++)
                if (C[i].Contains(nfaPathList.tail.ElementAt(0)))
                    tail.Add(i);
            dfaPathList = new PathList(new SortedSet<int>() { 0 }, tail, paths);
            return dfaPathList;
        }

        /// <summary>
        /// 将DFA转换为MFA
        /// </summary>
        /// <returns>转换后的MFA</returns>
        public PathList dfa2mfa()
        {
            Debug.WriteLine("dfa to mfa...");
            inputCharSets = getInputCharSets(dfaPathList).ToList();
            SortedSet<int> states = getStates();
            SortedSet<int> left = new SortedSet<int>();
            SortedSet<int> right = new SortedSet<int>();
            List<Path> paths = new List<Path>();
            SortedSet<int> heads = new SortedSet<int>();
            SortedSet<int> tails = new SortedSet<int>();
            states.ToList().ForEach(state =>
            {
                if (dfaPathList.tail.Contains(state)) left.Add(state);
                else right.Add(state);
            });
            stateSets.Add(right);
            stateSets.Add(left);
            if (left.Count == 0 || right.Count == 0)
            {
                heads = new SortedSet<int>() { 0 };
                tails = new SortedSet<int>() { 0 };
                paths = new List<Path>();
                inputCharSets.ForEach(val => paths.Add(new Path(0, 0, val)));
                return new PathList(heads, tails, paths);
            }
            divideStateSet(right);
            divideStateSet(left);
            stateSets.Sort((x, y) => x.ElementAt(0).CompareTo(y.ElementAt(0)));
            Debug.WriteLine("RESULT:");
            stateSets.ForEach(set => Debug.WriteLine(string.Join(" ", set)));
            paths = constructPathList().paths;
            Debug.WriteLine("PATH RESULT:");
            paths.ForEach(path => Debug.WriteLine(path.start + " " + path.end + " " + path.val));
            return constructPathList(); ;
        }
        /// <summary>
        /// 对输入的状态集进行划分
        /// </summary>
        /// <param name="curSets">待划分状态集</param>
        private void divideStateSet(SortedSet<int> curSets)
        {
            Debug.WriteLine(String.Join(" ", curSets));
            if (curSets.Count <= 1) return;
            foreach (char inputChar in inputCharSets) // 对每个输入字符进行判断
            {
                List<int> moveResList = move(curSets, inputChar, dfaPathList).ToList(); // 通过输入字符转移到的状态集
                Debug.WriteLine(string.Join(" ", moveResList));
                SortedSet<int> left = new SortedSet<int>(); // 划分的左集合
                SortedSet<int> right = new SortedSet<int>(); // 划分的右集合
                // 如果转移后只有一个状态或者转移后的状态完全被当前集合包括 直接看下一个输入字符
                if (moveResList.Count == 1 || isAContainB(curSets.ToList(), moveResList)) continue;
                // 因为等下要拆分所以这里先将当前集合删掉
                if (!haveStateSet(curSets)) // 如果当前状态集已经不存在了
                    return;
                // 遍历当前集合的每个元素
                for (int i = 0; i < curSets.Count; i++)
                {
                    int curSet = curSets.ElementAt(i);
                    int curMoveRes = findThisEnd(curSet, inputChar);
                    if (curMoveRes == -1) continue;
                    // 如果待分离的集合内 有与move(a)后的集合中的第一个属于集合的，以转移后的第一个元素为基准
                    Debug.WriteLine("curMoveRes is：" + curMoveRes.ToString());
                    Debug.WriteLine("curMoveRes in: " + findCharInSets(curMoveRes).ToString());
                    Debug.WriteLine("moveRes[0] in: " + findCharInSets(moveResList[0]).ToString());
                    if (findCharInSets(curMoveRes) == findCharInSets(moveResList[0]))
                        left.Add(curSet);
                    else
                        right.Add(curSet);
                }
                // 先将左右加入所有状态集的集合
                stateSets.Remove(curSets);
                stateSets.Add(left);
                stateSets.Add(right);
                divideStateSet(left);
                divideStateSet(right);
            }
        }
        /// <summary>
        /// 利用划分的结果构造MFA
        /// </summary>
        /// <returns>MFA的路径序列</returns>
        private PathList constructPathList()
        {
            List<Path> paths = new List<Path>();
            SortedSet<int> heads = new SortedSet<int>();
            SortedSet<int> tails = new SortedSet<int>();
            for (int i = 0; i < stateSets.Count; i++)
            {
                SortedSet<int> curSet = stateSets[i];
                if (isAContainB(dfaPathList.head.ToList(), curSet.ToList()))
                    heads.Add(i);
                else if (isAContainB(dfaPathList.tail.ToList(), curSet.ToList()))
                    tails.Add(i);
                for (int j = 0; j < inputCharSets.Count; j++)
                {
                    // 在原DFA里通过这个状态能到达end
                    int end = findThisEnd(curSet.ElementAt(0), inputCharSets[j]);
                    if (end == -1) continue;
                    if (findCharInSets(end) != -1)
                        paths.Add(new Path(i, findCharInSets(end), inputCharSets[j]));
                }
            }
            return new PathList(heads, tails, paths);
        }
        /// <summary>
        /// 拿到NFA中所有的输入字符集
        /// </summary>
        /// <returns>NFA中的输入字符集</returns>
        private HashSet<char> getInputCharSets(PathList pathList)
        {
            HashSet<char> vals = new HashSet<char>();
            for (int i = 0; i < pathList.paths.Count; i++)
            {
                if (pathList.paths[i].val != '#') vals.Add(pathList.paths[i].val);
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
        /// <param name="pathList">路径序列</param>
        /// <returns>move过的状态集合</returns>
        private SortedSet<int> move(SortedSet<int> I, char val, PathList pathList)
        {
            SortedSet<int> ret = new SortedSet<int>();
            List<Path> paths = pathList.paths;
            List<int> iCopy = I.ToList();
            for (int i = 0; i < iCopy.Count; i++)
                for (int j = 0; j < paths.Count; j++)
                    if (paths[j].start == iCopy[i] && paths[j].val == val)
                        ret.Add(paths[j].end);
            return ret;
        }
        /// <summary>
        /// 获取所有的状态
        /// </summary>
        /// <returns>状态集</returns>
        private SortedSet<int> getStates()
        {
            SortedSet<int> states = new SortedSet<int>();
            for (int i = 0; i < dfaPathList.paths.Count; i++)
            {
                Path path = dfaPathList.paths[i];
                states.Add(path.start);
                states.Add(path.end);
            }
            return states;
        }
        /// <summary>
        /// 判断当前是否存在这个状态集
        /// </summary>
        /// <param name="curSets">待判断的状态集</param>
        /// <returns>是否存在</returns>
        private bool haveStateSet(SortedSet<int> curSets)
        {
            foreach (SortedSet<int> set in stateSets)
            {
                Debug.WriteLine(string.Join(",", set.ToList()));
                if (string.Join(",", set.ToList()) == string.Join(",", curSets.ToList()))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 找到当前状态通过某一输入字所到达的状态
        /// </summary>
        /// <param name="start">开始状态</param>
        /// <param name="a">输入字</param>
        /// <returns>结束状态</returns>
        private int findThisEnd(int start, char a)
        {
            int end = -1;
            List<Path> paths = dfaPathList.paths;
            for (int i = 0; i < paths.Count; i++)
            {
                if (paths[i].start == start && paths[i].val == a)
                {
                    end = paths[i].end;
                    break;
                }
            }
            return end;
        }
        /// <summary>
        /// 返回a所在集合的下标
        /// </summary>
        /// <param name="a">输入的a</param>
        /// <returns>所在集合的下标</returns>
        private int findCharInSets(int a)
        {
            for (int i = 0; i < stateSets.Count; i++)
                if (stateSets[i].Contains(a))
                    return i;
            return -1;
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
        /// 判断b数列元素是否全部被a包括
        /// </summary>
        /// <param name="a">a数列</param>
        /// <param name="b">b数列</param>
        /// <returns>被包括返回true</returns>
        private bool isAContainB(List<int> a, List<int> b)
        {
            foreach (int i in b)
                if (!a.Contains(i))
                    return false;
            return true;
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
