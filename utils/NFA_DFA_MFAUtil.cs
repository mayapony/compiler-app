using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.utils
{
    class NFA_DFA_MFAUtil
    {
        private char[] _formulaChars = { '|', '*', '(', ')' };
        private char[] _notBracket = { '|', '*' };

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
            bool isValid = false;
            if (formula.Length <= 0 || isExist(_notBracket, formula[0]) || formula[formula.Length - 1] == '|') return false;
            for (int i = left; i < right; i++)
            {
                char cur = formula[i];
                if (char.IsLetter(cur)) continue;
                else if (isExist(_notBracket, cur) )
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



        private bool isExist<T>(T[] ts, T t)
        {
            return Array.BinarySearch(ts, 0, ts.Length, t) >= 0;
        }
    }
}
