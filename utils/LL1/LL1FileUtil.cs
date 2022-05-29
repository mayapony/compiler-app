using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerApp.utils.LL1
{
    class LL1FileUtil
    {
        public string[] readGrammar()
        {
            string[] ret = new string[]{};
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "文本|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                if (path == null) return ret;
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    ret = lines;
                }
            }
            return ret;
        }
    }
}
