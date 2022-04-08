using CompilerApp.models;
using CompilerApp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerApp.pages
{
    public partial class NFA_DFA_MFAForm : Form
    {
        NFA_DFA_MFAUtil nfa_dfa_mfaUtil = new NFA_DFA_MFAUtil();

        public NFA_DFA_MFAForm()
        {
            InitializeComponent();
        }

        private void btnValidFormal_Click(object sender, EventArgs e)
        {
            string input = tbFormal.Text;
            bool isValid = nfa_dfa_mfaUtil.verifyFormalFormula(input, 0, input.Length);
            
            if (isValid)
            {
                MessageBox.Show("合法");
                btnGenNFA.Enabled = true;
            } 
            else
            {
                btnGenNFA.Enabled = true;
                MessageBox.Show("不合法");
            }
        }

        private void btnGenNFA_Click(object sender, EventArgs e)
        {
            string input = tbFormal.Text;
            PathList.IDX = 0;
            PathList pathList = nfa_dfa_mfaUtil.formulaToNFA(input, 0, input.Length);
            Debug.WriteLine(pathList.head);
            Debug.WriteLine(pathList.tail);

            Path[] paths = pathList.paths.ToArray<Path>();
            for (int i = 0; i < paths.Length; i++)
            {
                Path path = paths[i];
                Debug.WriteLine(path.start + " " + path.val + " " + path.end);
            }


            dgNFA.AutoGenerateColumns = false;
            dgNFA.DataSource = null;
            dgNFA.DataSource = pathList.paths;

            tbNFAHead.Text = pathList.head.ToString();
            tbNFATail.Text = pathList.tail.ToString();
        }
    }
}
