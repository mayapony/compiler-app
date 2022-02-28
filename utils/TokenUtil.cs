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
        private string[] _keywords = { "return", "main", "printf" };    // 关键字
        private string[] _valueType = { "int", "char", "char" };    // 数值类型
        private char[] _separators = { ',', ';', '{', '}', '(', ')', '[', ']' };    // 分隔符
        private char[] _operators = { '+', '-', '*', '/', '=', '<', '>' };  // 运算符


        private int lineNumber = 0;
        private int _curIndex = 0;

        public List<Error> errors = new List<Error>();
        public List<Token> tokens = new List<Token>();
        public TokenUtil()
        {
            Array.Sort(_keywords);
            Array.Sort(_separators);
            Array.Sort(_operators);
            Array.Sort(_valueType);
        }


        public void analyzeOneLine(string line, int lineNumber)
        {
            string word = "";
            this.lineNumber = lineNumber;
            for (int i = 0; i < line.Length; i++, _curIndex ++)
            {
                if (isInKeyword(line[i]))
                {
                    word += line[i];
                }
                else if (line[i] == ' ' || line[i] == '\t')
                {
                    if (word.Length > 0)
                    {
                        checkWordType(word);
                        word = "";
                    }
                    continue;
                }
                else
                {
                    if (word.Length > 0)
                    {
                        checkWordType(word);
                        word = "";
                    }
                    checkCharType(line[i]);
                }
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
            else if (isExist(_valueType, word))
            {
                type = "类型";
            }
            else if (isNumber(word))
            {
                type = "数字";
            }
            else
            {
                type = "变量";
                isError = verityValueIsError(word);
            }
            if (isError)
            {
                errors.Add(new Error(lineNumber, word, "标识符命名错误"));
            }
            tokens.Add(new Token(lineNumber, word, type, "合法", 0, _curIndex - word.Length, isError));
        }

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

        private bool isInKeyword(char c)
        {
            return char.IsLetter(c) || char.IsDigit(c) || c == '_' || c == '.';
        }

        private bool isExist<T>(T[] ts, T t)
        {
            return Array.BinarySearch(ts, 0, ts.Length, t) >= 0;
        }

        private bool isNumber(string str)
        {
            int dotFlag = 0; // 是否出现过小数点
            foreach (char c in str)
            {
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
    }
}
