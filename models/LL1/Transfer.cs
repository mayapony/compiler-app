using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.models.LL1
{
    /// <summary>
    /// 文法的产生式
    /// left->right
    /// </summary>
    class Transfer
    {
        public Transfer(string left, string right)
        {
            this.left = left;
            this.right = right;
        }

        public Transfer(string transfer)
        {
            string[] splits = transfer.Split(new char[] { '-', '>' });
            this.left = splits.First();
            this.right = splits.Last();
        }

        public string left { get; set; }    // 左部
        public string right { get; set; }   // 右部
    }
}
