using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.utils.LL1
{
    public class LL1Util
    {
        public void confirmGrammar()
        {
            FirstUtil firstUtil = new FirstUtil();
            firstUtil.genFirstSet();
        }
    }
}
