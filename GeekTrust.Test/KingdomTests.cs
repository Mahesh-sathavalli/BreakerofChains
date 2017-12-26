using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreakerOfChains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakerOfChains.Tests
{
    [TestClass()]
    public class KingdomTests
    {
        [TestMethod()]
        public void ProcessreceivedMessageTest()
        {
            //Only success messages
            string messageToProcess = "Walar Morghulis: All men must die.";
            char[] emblem = "owl".ToCharArray();
            Assert.AreEqual(true, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "Die or play the tame of thrones";
            emblem = "panda".ToCharArray();
            Assert.AreEqual(true, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "Sphinx of black quartz judge my dozen vows";
            emblem = "space".ToCharArray();
            Assert.AreEqual(true, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "Fear cuts deeper than swords My Lord.";
            emblem = "octopus".ToCharArray();
            Assert.AreEqual(true, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "zmzmzmzaztzozh";
            emblem = "mammoth".ToCharArray();
            Assert.AreEqual(true, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "Drag on Martin!";
            emblem = "dragon".ToCharArray();
            Assert.AreEqual(true, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
        }

        [TestMethod()]
        public void ProcessreceivedMessageNotSuccessTest()
        {
            string messageToProcess = "nothing can be done";
            char[] emblem = "owl".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "I don't type what you need";
            emblem = "panda".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "I don't have time to look at what you need";
            emblem = "space".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "There are too intelligent you cannot find a way that it cannot esca*e";
            emblem = "octopus".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "bro they are extinct";
            emblem = "mammoth".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            messageToProcess = "These might be imaginary";
            emblem = "dragon".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
            //Sending blank
            messageToProcess = "";
            emblem = "dragon".ToCharArray();
            Assert.AreEqual(false, Kingdom.ProcessreceivedMessage(messageToProcess, emblem));
        }

    }
}