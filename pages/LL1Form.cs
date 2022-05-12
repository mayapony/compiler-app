using CompilerApp.utils.LL1;
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
    public partial class LL1Form : Form
    {
        LL1FileUtil ll1FileUtil = new LL1FileUtil();
        public LL1Form()
        {
            InitializeComponent();
        }

        private void btnReadGrammer_Click(object sender, EventArgs e)
        {
            string[] transfers = ll1FileUtil.readGrammar();
            tbGrammars.Lines = transfers;
        }
    }
}
