using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakerOfChains
{
    public class Validation
    {
        public static string ValidateKingdoms(List<string> input)
        {
            if(input.Count > 5)
            {
                return "All are compitetors cannot conduct election";
            }
            if(input.Count == 1)
            {
                return "Only single candidate has be nomoninated not able conduct election";
            }
            
            foreach (string comp in input)
            {
                if(!Universe.kingdoms.ContainsKey(comp.ToUpper()))
                {
                    return "One or more compitetors are not in the universe.";
                }
            }
            return "sucess";
        }
    }
}
