using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerApp.menus
{
    class FileMenu
    {
        private string _path = "~/Desktop";

        public void openFileToCodeText(RichTextBox rtbCode)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "c";
            dialog.Filter = "C语言代码|*.c";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _path = dialog.FileName;
                using (StreamReader sr = new StreamReader(dialog.FileName, Encoding.UTF8))
                {
                    rtbCode.Text = sr.ReadToEnd();
                }
            }
        }

        public void saveCodeTextToFile(RichTextBox rtbCode)
        {
            if (File.Exists(_path)) 
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(rtbCode.Text.ToString());
                    fs.Write(buffer, 0, buffer.Length);
                    MessageBox.Show("保存成功");
                    return;
                }
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "请选择要保存的文件的路径";
            dialog.InitialDirectory = _path;
            dialog.Filter = "C语言|*.c";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _path = dialog.FileName;
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(rtbCode.Text.ToString());
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
