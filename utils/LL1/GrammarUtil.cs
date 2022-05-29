using CompilerApp.models.LL1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilerApp.utils.LL1
{
    public enum unTStatus { unKnown, Yes, No } // 未知、是、否
    public static class GrammarUtil
    {
        // A -> ["ab", "bc"]
        public static Dictionary<string, HashSet<string>> TransferDict = new Dictionary<string, HashSet<string>>();
        public static Dictionary<string, unTStatus> canToEmptyUnTSet = new Dictionary<string, unTStatus>(); // 能推出#的非终结符
        public static HashSet<string> unTSet = new HashSet<string>();  // 非终结符集合

        public static Dictionary<string, HashSet<string>> FirstSet = new Dictionary<string, HashSet<string>>(); // First集合
        public static Dictionary<string, HashSet<string>> FollowSet = new Dictionary<string, HashSet<string>>(); // Follow集合

        /// <summary>
        /// 从输入的转移式生成文法字典
        /// </summary>
        /// <param name="transferStrs">输入的转移式</param>
        public static void genGrammarDict(string[] transferStrs)
        {
            foreach (string transferStr in transferStrs)
            {
                Transfer transfer = new Transfer(transferStr);
                unTSet.Add(transfer.left);

                if (TransferDict.ContainsKey(transfer.left))
                    transfer.right.Split('|').ToList().ForEach(r => TransferDict[transfer.left].Add(r));
                else
                {
                    HashSet<string> rightSets = new HashSet<string>();
                    transfer.right.Split('|').ToList().ForEach(r => rightSets.Add(r));
                    TransferDict.Add(transfer.left, rightSets);
                }
            }
        }

        // 判断c是否为终结符
        public static bool isTerminal(string cs)
        {
            char c = cs[0];
            return char.IsLower(c) || c == '#';
        }
    }
}
