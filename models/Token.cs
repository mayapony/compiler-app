using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.models
{
    // Token 类
    public class Token
    {
        public Token(int lineNumber, string word, string type, string validity, int wordCode, int startIdx, bool isError)
        {
            this.lineNumber = lineNumber;
            this.word = word;
            this.type = type;
            this.validity = validity;
            this.wordCode = wordCode;
            this.startIdx = startIdx;
            this.isError = isError;
        }

        // 行号
        public int lineNumber { get; set; }

        // 单词的内容
        public string word { get; set; }

        // 类型
        public string type { get; set; }

        // 是否合法
        public string validity { get; set; }

        // 单词码
        public int wordCode { get; set; }

        // 起始位置
        public int startIdx { get; set; }

        // 是否错误
        private bool isError { get; set; }

        public override string ToString()
        {
            string res = lineNumber.ToString() + "\t" + word.ToString() + "\t" + type.ToString() +
                "\t" + validity.ToString() + "\t\t" + wordCode.ToString() + "\t" + startIdx.ToString();
            if (isError)
            {
                res += "\t<- error";
            }
            return res;
        }
    }
}
