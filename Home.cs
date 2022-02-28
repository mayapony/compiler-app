using CompilerApp.models;
using CompilerApp.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CompilerApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "c";
            dialog.Filter = "C语言代码|*.c";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dialog.FileName, Encoding.Default))
                {
                    rtbCode.Text = sr.ReadToEnd();
                }
            }
        }

        private void 分词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenUtil tokenUtil = new TokenUtil();
            string[] lines = rtbCode.Lines;

            for (int i = 0; i < lines.Length; i++)
            {
                tokenUtil.analyzeOneLine(lines[i], i);
            }

            // 写入tokens
            List<string> tokenLines = new List<string>();
            tokenLines.Add("--------------------------------------------------------");
            tokenLines.Add("行号\t单词\t类型\t是否合法\t单词码\t起始下标");
            tokenLines.Add("--------------------------------------------------------");
            foreach (Token token in tokenUtil.tokens)
            {
                Debug.WriteLine(token);
                highlightWord(token);
                tokenLines.Add(token.ToString());
                
            }
            rtbCode.Select(rtbCode.TextLength, 0);
            tbTokens.Lines = tokenLines.ToArray();

            // 写入errors
            List<string> errorLines = new List<string>();
            errorLines.Add(tokenUtil.errors.Count + " errors");

            foreach (Error error in tokenUtil.errors)
            {
                errorLines.Add(error.ToString());
            }
            tbErrors.Lines = errorLines.ToArray();  Vv
        }


        private void highlightWord(Token token)
        {
            rtbCode.Select(token.startIdx, token.word.Length);
            if (token.type == "关键词")
            {
                // Debug.WriteLine("select word: start-{0:G} end-{1:G}", token.startIdx, token.startIdx + token.word.Length - 1);
                rtbCode.SelectionColor = Color.Blue;
            }
            else if (token.type == "数据类型")
            {
                rtbCode.SelectionFont = new Font("Consolas", (float)20.25, FontStyle.Bold);
            } else if (token.type == "数字")
            {
                rtbCode.SelectionColor = Color.DarkBlue;
            }
        }
    }
}
