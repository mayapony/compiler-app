using CompilerApp.menus;
using CompilerApp.models;
using CompilerApp.pages;
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
        CompilerMenu compilerMenu = new CompilerMenu();
        FileMenu fileMenu = new FileMenu();

        public Home()
        {
            InitializeComponent();
        }

        // 打开文件按钮
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            fileMenu.openFileToCodeText(rtbCode);
        }

        // 分词按钮
        private void 分词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compilerMenu.divisionCode(rtbCode, tbTokens, tbErrors);
        }

        private void rtbCode_TextChanged(object sender, EventArgs e)
        {
            // TODO 代码输入高亮
            // 分词ToolStripMenuItem_Click(sender, e);
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileMenu.openFileToCodeText(rtbCode);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileMenu.saveCodeTextToFile(rtbCode);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fileMenu.saveCodeTextToFile(rtbCode);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            compilerMenu.divisionCode(rtbCode, tbTokens, tbErrors);
        }

        private void nFADFAMFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NFA_DFA_MFAForm nfa_dfa_mfaForm = new NFA_DFA_MFAForm();
            nfa_dfa_mfaForm.ShowDialog();
        }
    }
}
