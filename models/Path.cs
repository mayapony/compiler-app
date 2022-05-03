using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.models
{
    class Path
    {
        public int start { get; set; }
        public int end { get; set; }
        public char val { get; set; }
        /// <summary>
        /// 构造一条路径
        /// </summary>
        /// <param name="start">开始点</param>
        /// <param name="end">结束点</param>
        /// <param name="val">路径上的值</param>
        public Path(int start, int end, char val)
        {
            this.start = start;
            this.end = end;
            this.val = val;
        }
    }
}
