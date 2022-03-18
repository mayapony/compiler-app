using CompilerApp.models;
using CompilerApp.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerApp.menus
{
    class CompilerMenu
    {
        public void divisionCode(RichTextBox rtbCode, TextBox tbTokens, TextBox tbErrors)
        {
            // 定义分词工具对象
            TokenUtil tokenUtil = new TokenUtil();
            string[] lines = rtbCode.Lines; // 拿到输入框内所有的代码

            Cursor oldCursor = rtbCode.Cursor; // 保存光标位置

            for (int i = 0; i < lines.Length; i++)
            {
                tokenUtil.analyzeOneLine(lines[i], i); // 逐行分析单词
            }

            // 写入tokens
            List<string> tokenLines = new List<string>();
            tokenLines.Add("--------------------------------------------------------");
            tokenLines.Add("行号\t单词\t类型\t是否合法\t单词码\t起始下标");
            tokenLines.Add("--------------------------------------------------------");
            foreach (Token token in tokenUtil.tokens)
            {
                // 默认调用Token的ToString方法
                Debug.WriteLine(token); // 在控制台输出
                highlightWord(rtbCode, token); // 高亮对应单词
                tokenLines.Add(token.ToString()); // 在Token输出框口进行输出

            }
            // 结束后光标停在最后
            rtbCode.Select(rtbCode.TextLength, 0);
            tbTokens.Lines = tokenLines.ToArray();

            // 写入errors
            List<string> errorLines = new List<string>();
            errorLines.Add(tokenUtil.errors.Count + " errors");
            errorLines.Add("-----------------------------------");
            foreach (Error error in tokenUtil.errors)
            {
                errorLines.Add(error.ToString());
                errorLines.Add("-----------------------------------");
            }
            tbErrors.Lines = errorLines.ToArray();
            rtbCode.Cursor = oldCursor;
            rtbCode.SelectionColor = Color.Black;
        }


        private void highlightWord(RichTextBox rtbCode, Token token)
        {
            // 选择对应单词
            rtbCode.Select(token.startIdx, token.word.Length);
            
             if (token.word == "int" || token.word == "char")
            {
                rtbCode.SelectionFont = new Font("Consolas", (float)20.5, FontStyle.Bold);
            }
             else if (token.type == "关键词")
            {
                rtbCode.SelectionColor = Color.Blue;
            }
            else if (token.type == "数字")
            {
                rtbCode.SelectionColor = Color.Green;
            }
            else if (token.type == "分隔符")
            {
                rtbCode.SelectionColor = Color.Red;
            }
            //else if (token.type == "运算符")
            //{
            //    rtbCode.SelectionColor = Color.Red;
            //}
            rtbCode.Select(token.startIdx, 0);
            rtbCode.SelectionColor = Color.Black;
        }

    }
}
