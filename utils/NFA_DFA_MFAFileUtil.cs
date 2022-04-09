using CompilerApp.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerApp.utils
{
    class NFA_DFA_MFAFileUtil
    {
        /// <summary>
        /// 从文件读入NFA
        /// </summary>
        /// <returns>nfa 路径序列</returns>
        public PathList readNFAFromFile()
        {
            PathList ret = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                if (path == null) return null;
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    int head = Int32.Parse(lines[0]);
                    int tail = Int32.Parse(lines[1]);
                    List<models.Path> paths = new List<models.Path>();
                    for (int i = 2; i < lines.Length; i++)
                    {
                        string[] frags = lines[i].Split(' ');
                        paths.Add(new models.Path(Int32.Parse(frags[0]), Int32.Parse(frags[2]), frags[1][0]));
                    }
                    ret = new PathList(head, tail, paths);
                }
            }
            return ret;
        }
    }
}
