using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BreakerOfChains
{
    //This is the kingdom where the we have 2 functionalities now sending message and receieving message.
    public class Kingdom
    {
        public string Name { get; set; }
        public string Emblem { get; set; }
        public string KingName { get; set; }
        public List<Kingdom> allies { get; set; }
        public bool alligencegiven { get; set; }
        
        public Kingdom(string name, string emblem, string kingName = "")
        {
            Name = name;
            Emblem = emblem;
            KingName = kingName;
            allies = new List<Kingdom>();
            alligencegiven = false;
        }

        public void sendMessages()
        {
            foreach (Kingdom kingdom in Universe.kingdoms.Values)
            {
                if (!this.Equals(kingdom))
                {
                    MessageFormat mesg = new MessageFormat();
                    mesg.FromKingdom = this;
                    mesg.ToKingdom = kingdom;
                    mesg.Message = GetRandomMessage();
                    Universe.Priest.AddMessagetoBallotbox(mesg);
                }
            }
        }

        private string GetRandomMessage()
        {
            Random ran = new Random();
            int index = ran.Next(25);
            return Messages.MessagesList[index];
        }

        public static bool ProcessreceivedMessage(string messagetoProcess, Char[] value)
        {
            List<char> mesg = messagetoProcess.ToLower().ToCharArray().ToList();
            mesg.RemoveAll(item => item.Equals(' '));
            mesg.RemoveAll(item => item.Equals('"'));
            mesg.Sort();
            foreach (char item in value)
            {
                if (mesg.Contains(item))
                {
                    mesg.Remove(item);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private void AddAllies(Kingdom fromkingdom,Kingdom toKingdom)
        {
            if(!Universe.kingdoms[fromkingdom.Name].allies.Contains(toKingdom))
            {
                Universe.kingdoms[fromkingdom.Name].allies.Add(toKingdom);
            }
            
        }
        private bool validateInputMessage(string inputmessage)
        {
            Regex reg = new Regex(@"[a-zA-Z]+,[a-zA-Z\s!@#$%^&*']+");
            return (reg.IsMatch(inputmessage));
        }

        public bool receiveMessageAndAddAllies(string message,Kingdom fromKingdom,Kingdom toKingdom,HighPriest p)
        {
            if(p.Compitetors.Contains(toKingdom.Name))
            {
                return false;
            }
            if(Kingdom.ProcessreceivedMessage(message,Emblem.ToLower().ToCharArray()))
            {
                AddAllies(fromKingdom,toKingdom);
                return true;
            }
            return false;
        }
    }
}
