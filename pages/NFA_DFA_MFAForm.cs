using CompilerApp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            } 
            else
            {
                MessageBox.Show("不合法");
            }
        }

    }
}
