using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerApp.utils.LL1
{
    public class SelectUtil
    {

        public Dictionary<string, SortedSet<string>> SelectSet = new Dictionary<string, SortedSet<string>>(); // Follow集合
        List<string> unTs = GrammarUtil.unTSet.ToList();

        public void genSelectSet()
        {
            unTs.ForEach(unT =>
            {
                List<string> rights = GrammarUtil.TransferDict[unT].ToList();
                rights.ForEach(right =>
                {
                    string key = unT + "->" + right;
                    SelectSet.Add(key, new SortedSet<string>());

                    int i = 0;
                    for (; i < right.Length; i++)
                    {
                        string curChar = right[i].ToString();
                        if (GrammarUtil.isTerminal(curChar))
                        {
                            SelectSet[key].Add(curChar);
                            break;
                        }
                        else if (GrammarUtil.canToEmptyUnTSet[curChar] == unTStatus.Yes)
                        {
                            GrammarUtil.FirstSet[curChar].ToList().ForEach(first =>
                            {
                                if (first != GrammarUtil.empty) SelectSet[key].Add(first);
                            });
                        }
                        else if (GrammarUtil.canToEmptyUnTSet[curChar] == unTStatus.No)
                        {
                            GrammarUtil.FirstSet[curChar].ToList().ForEach(first => SelectSet[key].Add(first));
                            break;
                        }
                    }
                    if (right == GrammarUtil.empty || i == right.Length)
                    {
                        GrammarUtil.FollowSet[unT].ToList().ForEach(follow => SelectSet[key].Add(follow));
                    }
                });

            });
            GrammarUtil.SelectSet = SelectSet;
        }
    }
}
