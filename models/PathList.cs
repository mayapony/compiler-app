using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.models
{
    public struct Path {
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


    class PathList
    {  
        public int head { get; set; }

        public int tail { get; set; }

        public List<Path> paths = new List<Path>();

        public static int IDX = 0;

        /// <summary>
        /// 将另一个路径列表添加到当前列表的后面 (ab)
        /// </summary>
        /// <param name="other">另一个路径序列</param>
        public void connectPathList(PathList other)
        {
            this.paths.Add(new Path(tail, other.head, '#'));
            this.tail = other.tail;
            this.paths = new List<Path>(this.paths.Concat(other.paths));
        }

        /// <summary>
        /// 将两个路径列表并联(a|b)
        /// </summary>
        /// <param name="other">另一个路径序列</param>
        public void parallelPathList(PathList other)
        {
            this.paths = new List<Path>(this.paths.Concat(other.paths));
            this.paths.Add(new Path(++IDX, this.head, '#'));
            this.paths.Add(new Path(IDX, other.head, '#'));
            this.paths.Add(new Path(this.tail, ++IDX, '#'));
            this.paths.Add(new Path(other.tail, IDX, '#'));
            this.tail = IDX;
            this.head = IDX - 1;
        }

        /// <summary>
        /// 对当前列表作闭包 (a*)
        /// </summary>
        public void closurePathList()
        {
            this.paths.Add(new Path(++IDX, this.head, '#'));
            this.paths.Add(new Path(IDX, ++IDX, '#'));
            this.paths.Add(new Path(tail, IDX, '#'));
            this.paths.Add(new Path(tail, head, '#'));
            this.tail = IDX;
            this.head = IDX - 1;
        }

        /// <summary>
        /// 通过字符构造路径
        /// </summary>
        /// <param name="val">输入的字符</param>
        public PathList(char val)
        {
            this.paths.Add(new Path(++IDX, ++IDX, val));
            this.head = IDX - 1;
            this.tail = IDX;
        }

        public PathList(int head, int tail, List<Path> paths)
        {
            this.head = head;
            this.tail = tail;
            this.paths = paths;
        }
    }
}
