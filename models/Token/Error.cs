using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.models
{
    public class Error
    {
        public Error(int line, string wrod, string type)
        {
            this.line = line;
            this.word = wrod;
            this.type = type;
        }

        public int line { get; set; }
        public string word { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return line + "行\t" + word + "\t\t" + type + '\n';
        }
    }
}
