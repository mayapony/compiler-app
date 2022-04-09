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
        NFA_DFA_MFAFileUtil NFA_DFA_MFAFileUtil = new NFA_DFA_MFAFileUtil();

        public NFA_DFA_MFAForm()
        {
            InitializeComponent();
            tbFormal.Text = "(a*|b)*";
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

            tbNFAHead.Text = pathList.head.ToString();
            tbNFATail.Text = pathList.tail.ToString();
            dgvDataBind(dgNFA, pathList);

            btnGenDFA.Enabled = true;
        }

        private void btnOpenNFA_Click(object sender, EventArgs e)
        {
            PathList pathList = NFA_DFA_MFAFileUtil.readNFAFromFile();
            if (pathList == null) return;
            else
            {
                dgvDataBind(dgNFA, pathList);
                btnGenDFA.Enabled = true;
                nfa_dfa_mfaUtil.nfaPathList = pathList;
                tbNFAHead.Text = pathList.head.ToString();
                tbNFATail.Text = pathList.tail.ToString();
            }
        }

        /// <summary>
        /// 将数据绑定到data grid view组件
        /// </summary>
        /// <param name="dgv">data grid view 组件</param>
        /// <param name="pathList">路径序列</param>
        private void dgvDataBind(DataGridView dgv, PathList pathList)
        {
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = null;
            dgv.DataSource = pathList.paths;
        }

        private void btnGenDFA_Click(object sender, EventArgs e)
        {
            PathList pathList = nfa_dfa_mfaUtil.NFAToDFA();
            tbDFAHead.Text = pathList.head.ToString();
            SortedSet<int> tails = new SortedSet<int>();
            List<SortedSet<int>> T = nfa_dfa_mfaUtil.T;
            for (int i = 0; i < T.Count; i++)
                if (T[i].Contains(nfa_dfa_mfaUtil.nfaPathList.tail))
                    tails.Add(i);

            tbDFATail.Text = String.Join(", ", tails);
            dgvDataBind(dgDFA, pathList);
        }
    }
}
