using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakerOfChains
{
    class UniverseOperations
    {
        static void Main()
        {
            Universe Sotheros = new Universe();
            HighPriest priest = Universe.Priest;
            List<Kingdom> CompitetorsKingdom = new List<Kingdom>();
            GetRulerAndAllies(CompitetorsKingdom.FirstOrDefault());
            Console.WriteLine("Enter the kingdoms competing to be the ruler:");
            List<string> input = Convert.ToString(Console.ReadLine()).Split(' ').ToList();
            string mesg = Validation.ValidateKingdoms(input);
            while (mesg != "sucess")
            {
                Console.WriteLine(mesg + " \nPlease Enter the Kingdom who is there in the universe");
                input = Convert.ToString(Console.ReadLine()).Split(' ').ToList();
                mesg = Validation.ValidateKingdoms(input);
            }
                int count = 1;
            while (Sotheros.KingOfall == null)
            {
                    
                    Console.WriteLine("Reuslt after round " + count + " ballet count");
                    if(count == 1)
                    {
                        priest.AddCompitetors(input);
                    }
                    
                    string result = priest.ConductElection();
                    CompitetorsKingdom = priest.DisplayAlliesForCompitetors();
                    if(CompitetorsKingdom != null && CompitetorsKingdom.Count ==1)
                    {
                        Sotheros.KingOfall = CompitetorsKingdom.FirstOrDefault();
                        GetRulerAndAllies(CompitetorsKingdom.FirstOrDefault());
                    }else if(CompitetorsKingdom != null && CompitetorsKingdom.Count > 1)
                    {
                        priest.ModifyCompiteors(CompitetorsKingdom);
                    }

                    count++;
                    if(count == 1000)
                    {
                        Console.WriteLine("Not able to decided the King since they have equal share in all rounds.");
                        break;
                    }
            }
            Console.Read();
        }

        private static void GetRulerAndAllies(Kingdom king)
        {
            Console.WriteLine("Who is the Ruler of Southeros");
            if(king == null)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(king.Name);
            }
            
            Console.WriteLine("Allies of Ruler?");
            if(king == null)
            {
                Console.WriteLine("None");
            }else
            {
                foreach (var item in king.allies)
                {
                    Console.Write(item.Name + " ");
                }
            }
            
            Console.WriteLine();
        }
    }
}
