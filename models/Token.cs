using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.models
{
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

        public int lineNumber { get; set; }

        public string word { get; set; }

        public string type { get; set; }

        public string validity { get; set; }

        public int wordCode { get; set; }

        public int startIdx { get; set; }

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
