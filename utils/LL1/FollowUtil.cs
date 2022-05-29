using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.utils.LL1
{
    public class FollowUtil
    {
        public Dictionary<string, HashSet<string>> FollowSet = new Dictionary<string, HashSet<string>>(); // Follow集合

        public void genFollowSet()
        {
            FollowSet.Add(GrammarUtil.unTSet.First(), new HashSet<string>() { "#" });
        }
    }
}
