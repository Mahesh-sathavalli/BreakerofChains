using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakerOfChains;
using System.Collections.Generic;

namespace GeekTrust.Test
{
    [TestClass]
    public class HighPriestTest
    {
        
        [TestMethod]
        public void Test_AddSixMessages()
        {
            //Test to add the messages less than 6
            string output = "Ballot box count should be atleast 6";
            Universe Sotheros = new Universe();
            HighPriest priest = Universe.Priest;
            List<Kingdom> CompitetorsKingdom = new List<Kingdom>();
            AddMessagetoBallotBox(priest);
            string op  = priest.AddSixMessages();
            Assert.AreEqual(op,output);
        }

        [TestMethod]
        public void Test_AddSixMessagesEqualto5()
        {
            //Test to add the messages less than 6
            string output = "Ballot box count should be atleast 6";
            Universe Sotheros = new Universe();
            HighPriest priest = Universe.Priest;
            List<Kingdom> CompitetorsKingdom = new List<Kingdom>();
            for (int i = 0; i < 5; i++)
            {
                priest.AddMessagetoBallotbox(Get5messages());
            }
            
            string op = priest.AddSixMessages();
            Assert.AreEqual(op, output);
        }

        [TestMethod]
        public void Test_AddSixMessagesGreaterthen5()
        {
            //Test to add the messages less than 6
            string output = "Sucess";
            Universe Sotheros = new Universe();
            HighPriest priest = Universe.Priest;
            List<Kingdom> CompitetorsKingdom = new List<Kingdom>();
            for (int i = 0; i < 7; i++)
            {
                priest.AddMessagetoBallotbox(Get5messages());
            }

            string op = priest.AddSixMessages();
            Assert.AreEqual(op, output);
        }
        [TestMethod]
        public void Test_SendMesgFromKingdomsToBallotBoxNOCompitetors()
        {
            string output = "Not able to conduct election because of no compitetors";
            Universe Sotheros = new Universe();
            HighPriest priest = Universe.Priest;
            priest.Compitetors = new List<string>();
            string result = priest.ConductElection();
            Assert.AreEqual(output, result);
        }
        [TestMethod]
        public void Test_SendMesgFromKingdomsToBallotBoxCompitetors()
        {
            string output = "Sucess";
            Universe Sotheros = new Universe();
            HighPriest priest = Universe.Priest;
            priest.Compitetors = new List<string>();
            List<string> kingdoms = new List<string>() { "AIR", "LAND", "WATER", "SPACE", "FIRE", "ICE" };
            Random kingEmblem = new Random();
            for (int i = 0; i < 2; i++)
            {
                int ind = kingEmblem.Next(6);
                priest.Compitetors.Add(kingdoms[ind]);
                kingdoms.RemoveAt(ind);
            }
            string result = priest.ConductElection();
            Assert.AreEqual(output, result);
        }

        private MessageFormat Get5messages()
        {
            MessageFormat mesg = new MessageFormat();
            string king ="";
            string emblem ="";
            RandomKingdoms(out king, out emblem);
            mesg.FromKingdom = new Kingdom(king,emblem);
            RandomKingdoms(out king, out emblem);
            mesg.ToKingdom = new Kingdom(king, emblem);
            string message = GetRandomMessage();
            mesg.Message = message;
            return mesg;
        }

        private void AddMessagetoBallotBox(HighPriest priest)
        {
            priest.AddMessagetoBallotbox(GetDummyMessages());
        }

        private MessageFormat GetDummyMessages()
        {
            MessageFormat mesg = new MessageFormat();
            mesg.FromKingdom = new Kingdom("AIR", "owl");
            mesg.ToKingdom = new Kingdom("LAND", "panda");
            mesg.Message = "We promptly judged antique ivory buckles for the next prize.";
            return mesg;
        }

        private void RandomKingdoms(out string king,out string emblem)
        {
            List<string> kingdoms = new List<string>() { "AIR","LAND","WATER","SPACE","FIRE","ICE"};
            List<string> Emblem = new List<string>() { "owl", "panda", "octopus", "gorilla", "dragon", "mammoth" };
            Random kingEmblem = new Random();
            int ind = kingEmblem.Next(6);
            king = kingdoms[ind];
            emblem = kingdoms[ind];
        }
        private string GetRandomMessage()
        {
            Random ran = new Random();
            int index = ran.Next(25);
            return Messages.MessagesList[index];
        }
    }
}
