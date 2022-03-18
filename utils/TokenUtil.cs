using CompilerApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.utils
{
    public class TokenUtil
    {
        // 类型定义
        private string[] _keywords = { "return", "main", "printf", "include", "if", "while", "for", "else", "int", "char" };    // 关键字

        private char[] _separators = { ',', ';', '{', '}', '(', ')', '[', ']' };    // 分隔符
        private char[] _operators = { '+', '-', '*', '/', '=', '<', '>' };  // 运算符
        private string[] _operatorsGroup = { "+=", "-=", ">=", "<=", "++", "--" }; 


        private int lineNumber = 0;
        private int _curIndex = 0;

        public List<Error> errors = new List<Error>();
        public List<Token> tokens = new List<Token>();
        public TokenUtil()
        {
            Array.Sort(_keywords);
            Array.Sort(_separators);
            Array.Sort(_operators);
            Array.Sort(_operatorsGroup);
        }


        // 对一行进行分析
        public void analyzeOneLine(string line, int lineNumber)
        {
            string word = "";
            this.lineNumber = lineNumber;
            for (int i = 0; i < line.Length; i++, _curIndex ++)
            {
                // 如果字符可以构成关键词或数字
                if (isInKeyword(line[i]))
                {
                    word += line[i];
                }
                // 碰到空格或制表符
                else if (isInSpaceSeparator(line[i]))
                {
                    if (word.Length > 0)
                    {
                        checkWordType(word);
                        word = "";
                    }
                    continue;
                } 
                else if (isExist(_separators, line[i]))
                {
                    if (word.Length > 0)
                    {
                        checkWordType(word);
                        word = "";
                    }
                    tokens.Add(new Token(lineNumber, line[i].ToString(), "分隔符", "合法", 0, _curIndex, false));
                }
                // 碰到其余分隔符
                else
                {
                    if (word.Length > 0)
                    {
                        checkWordType(word);
                        word = "";
                    }
                    string charGroup = "";
                    while (i < line.Length && !isInKeyword(line[i]) && !isInSpaceSeparator(line[i]) && !isExist(_separators, line[i]))
                    {
                        charGroup += line[i++];
                        _curIndex++;
                    }
                    if (i < line.Length && char.IsDigit(line[i]) && (line[i - 1] == '+' || line[i - 1] == '-'))
                    {
                        charGroup = charGroup.Substring(0, charGroup.Length - 1);
                        word += line[i - 1];
                    }
                    checkCharGroupType(charGroup);

                    _curIndex--;
                    i--; // 上面加多了w(ﾟДﾟ)w
                }
            }
            if (word.Length > 0)
            {
                checkWordType(word);
            }
            _curIndex++;
        }

        private void checkWordType(string word)
        {
            string type;
            bool isError = false;
            if (isExist(_keywords, word))
            {
                type = "关键词";
            } 
            else if (isNumber(word))
            {
                type = "数字";
            }
            else
            {
                type = "变量";
                // 判断是否有误
                isError = verityValueIsError(word);
            }
            if (isError)
            {
                string errType = "标识符命名错误";
                
                if (onlyDotNumber(word))
                {
                    type = "非法数字";
                    errType = "数字错误";
                }

                errors.Add(new Error(lineNumber, word, errType));
            }
            tokens.Add(new Token(lineNumber, word, type, isError ? "非法" : "合法", 0, _curIndex - word.Length, isError));
        }

        private void checkCharGroupType(string charGroup)
        {
            bool first = true;
            for (int i = 1; i < charGroup.Length; i+=2)
            {
                string frag = charGroup[i - 1] + "" + charGroup[i];
                if (isExist(_operatorsGroup, frag))
                {
                    addOneCharGroupRecord(frag, first);
                    first = false;
                } 
                else
                {
                    addOneCharGroupRecord(frag.Substring(0, 1), first);
                    first = false;
                    addOneCharGroupRecord(frag.Substring(1, 1), first);
                }
                
            }
            if (charGroup.Length % 2 == 1)
            {
                addOneCharGroupRecord(charGroup[charGroup.Length - 1].ToString(), first);
            }
            // tokens.Add(new Token(lineNumber, charGroup.ToString(), "组", first ? "合法" : "非法", 0, _curIndex, false));
        }

        // 判断字符的类型
        private void checkCharType(char c)
        {
            string type = "未知";
            if (isExist<char>(_operators, c))
            {
                type = "运算符";
            }
            else if (isExist<char>(_separators, c))
            {
                type = "分隔符";
            }
            tokens.Add(new Token(lineNumber, c.ToString(), type, "合法", 0, _curIndex, false));
        }

        // 判断字符是否可以构成关键词或变量或数字
        private bool isInKeyword(char c)
        {
            return char.IsLetter(c) || char.IsDigit(c) || c == '_' || c == '.';
        }

        private bool isInSpaceSeparator(char c)
        {
            return c == ' ' || c == '\t';
        }

        // 判断t是否存在与ts中
        private bool isExist<T>(T[] ts, T t)
        {
            return Array.BinarySearch(ts, 0, ts.Length, t) >= 0;
        }
        
        // 判断是否为数字
        private bool isNumber(string str)
        {
            int dotFlag = 0; // 是否出现过小数点
            int i = 0;
            if (str[0] == '-' || str[0] == '+') i++;
            for (; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '.')
                {
                    if (dotFlag == 1) return false;
                    dotFlag = 1;
                    continue;
                }
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        // 验证变量合法性
        private bool verityValueIsError(string word)
        {
            return word[0] != '_' && !char.IsLetter(word[0]);
        }

        private void addOneCharGroupRecord<T>(T t, bool isValid)
        {
            tokens.Add(new Token(lineNumber, t.ToString(), "运算符", isValid ? "合法" : "非法", 0, _curIndex, !isValid));
            if (!isValid)
            {
                errors.Add(new Error(lineNumber, t.ToString(), "运算符使用错误"));
            }
        }

        private bool onlyDotNumber(string word) 
        {
            for (int i = 0; i < word.Length; i++) 
                if (word[i] != '.' && !char.IsDigit(word[i]))
                    return false;
            return true;
        }

    }
}
