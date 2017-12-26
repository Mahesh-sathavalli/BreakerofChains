using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakerOfChains
{
    public class HighPriest
    {
        List<MessageFormat> BallotBox;
        List<MessageFormat> SixMessageFromBallotBox;
        public List<string> Compitetors;

        public HighPriest()
        {
            BallotBox = new List<MessageFormat>();
            SixMessageFromBallotBox = new List<MessageFormat>();
            Compitetors = new List<string>();
        }

        public void AddMessagetoBallotbox(MessageFormat messages)
        {
            //Make the validations if needed
            BallotBox.Add(messages);
        }
        //Messages will be added to the ballot box.
        public string AddSixMessages()
        {
            if(BallotBox.Count >0 && BallotBox.Count >=6)
            {
                for (int i = 0; i < 6; i++)
                {
                    Random rand = new Random();
                    //every time the ballot box count is descreasing so need to decrease the upper limit also
                    int index = rand.Next(Math.Abs(BallotBox.Count - i));
                    SixMessageFromBallotBox.Add(BallotBox[index]);
                    //Remove vote from ballot box
                    BallotBox.RemoveAt(index);
                }
            }else
            {
                return "Ballot box count should be atleast 6";
            }

            return "Sucess";
        }

        //Pick random messages and send it to respective kingdoms.
        private bool SendMesgFromKingdomsToBallotBox()
        {
            if(Compitetors.Count > 0)
            {
                foreach (string compitetor in Compitetors)
                {
                    Universe.kingdoms[compitetor.ToUpper()].sendMessages();
                }
                return true;
            }
            return false;
        }
       
        public string ConductElection()
        {
            string processMessage = "";
            if (SendMesgFromKingdomsToBallotBox())
            {
                processMessage = AddSixMessages();
                if(processMessage == "Sucess")
                {
                    //Send the messages to Respective kingdoms before that eliminate the messages between compitetors
                    SendMessagetoKingdomsFromBalltoBox(this);
                    return processMessage;
                }
                else
                {
                    Console.WriteLine(processMessage);
                    return processMessage;   
                }
            }
            else
            {
                processMessage = "Not able to conduct election because of no compitetors";
                Console.WriteLine(processMessage);
                return processMessage;
            }
             
        }


        private void SendMessagetoKingdomsFromBalltoBox(HighPriest p)
        {
            foreach (var item in SixMessageFromBallotBox)
            {
                if(!Universe.kingdoms[item.ToKingdom.Name].alligencegiven)
                {
                    if(Universe.kingdoms[item.ToKingdom.Name].receiveMessageAndAddAllies(item.Message, item.FromKingdom, item.ToKingdom, p))
                        Universe.kingdoms[item.ToKingdom.Name].alligencegiven = true;
                }
            }
        }

       
        private bool EliminateCompetitorMessages()
        {
            var itemstoBeDeleted = SixMessageFromBallotBox.Where(i => ShouldBeDeleted(i)).ToList();
            foreach (var item in itemstoBeDeleted)
            {
                SixMessageFromBallotBox.Remove(item);
            }
            if(SixMessageFromBallotBox.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ShouldBeDeleted(MessageFormat i)
        {
            return (Compitetors.Contains(i.ToKingdom.Name)) ? true : false;
        }

        public void AddCompitetors(List<string> inputCompitetors)
        {
                Compitetors.AddRange(inputCompitetors.ConvertAll(d => d.ToUpper()));
            
        }


        //Modify compitetors if Ballat count is Same
        public void ModifyCompiteors(List<Kingdom> Kingdoms)
        {
            Compitetors.Clear();
            Compitetors.AddRange(Kingdoms.Select(x => x.Name));
        }

        public List<Kingdom> DisplayAlliesForCompitetors()
        {
            List<Kingdom> rulerList = new List<Kingdom>();
            int numofAllies = 0;
            foreach (var item in Compitetors)
            {
                if(Universe.kingdoms[item].allies.Count > numofAllies)
                {
                    numofAllies = Universe.kingdoms[item].allies.Count;
                    rulerList.Clear();
                    rulerList.Add(Universe.kingdoms[item]);
                }else if(Universe.kingdoms[item].allies.Count == numofAllies)
                {
                    if(!rulerList.Contains(Universe.kingdoms[item]))
                    {
                        rulerList.Add(Universe.kingdoms[item]);
                    }
                }
                 
                Console.WriteLine("Allies for " + Universe.kingdoms[item].Name +" " + Universe.kingdoms[item].allies.Count);
            }
            
            return rulerList;
        }
    }
}
