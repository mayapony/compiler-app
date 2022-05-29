using CompilerApp.utils.LL1;
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
    public partial class LL1Form : Form
    {
        LL1FileUtil ll1FileUtil = new LL1FileUtil();
        LL1Util ll1Util = new LL1Util();
        public LL1Form()
        {
            InitializeComponent();
        }

        private void btnReadGrammer_Click(object sender, EventArgs e)
        {
            string[] transfers = ll1FileUtil.readGrammar();
            tbGrammars.Lines = transfers;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            GrammarUtil.genGrammarDict(tbGrammars.Lines);

            ll1Util.confirmGrammar();

            foreach (KeyValuePair<string, HashSet<string>> pair in GrammarUtil.TransferDict)
            {
                Debug.WriteLine(pair.Key + ": " + String.Join(", ", pair.Value));
            }

            foreach (KeyValuePair<string, unTStatus> pair in GrammarUtil.canToEmptyUnTSet)
            {
                Debug.WriteLine(pair.Key + ": " + String.Join(", ", pair.Value));
            }


            foreach (KeyValuePair<string, HashSet<string>> pair in GrammarUtil.FirstSet)
            {
                Debug.WriteLine(pair.Key + ": " + String.Join(", ", pair.Value));
            }

            foreach (KeyValuePair<string, HashSet<string>> pair in GrammarUtil.FollowSet)
            {
                Debug.WriteLine(pair.Key + ": " + String.Join(", ", pair.Value));
            }

            foreach (KeyValuePair<string, SortedSet<string>> pair in GrammarUtil.SelectSet)
            {
                Debug.WriteLine(pair.Key + ": " + String.Join(", ", pair.Value));
            }
        }
    }
}
