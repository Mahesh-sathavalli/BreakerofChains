Personal Info
Name : Mahesh

Few Corner cases and limitations
1. I have run the elections till 1000 times if still not able decide then will be printing message that can't decide the result.

I got some feed back from Clair Sebastian I have addressed most of that see the details below

1.  There is an error on compilation, "The type or namespace name `MessageFormat' could not be found." Have you missed adding a file?
      This is because of one file missing which had all the messages

2.  Have identified most of the domain classes like kingdom, HighPriest, Universe etc. and there is some decent separation of concerns.
      Thanks for the above comment. I still feel I can do some more changes to achieve more seperation of concerns. Please let me know if I can do more

3.  Good readable code.
      Thank you

4.  The naming conventions used are not consistent
        eg: the public method sendMessages() in KingDom class
        eg: the private method GetRandomMessage in KinDom class
        Kingdom is a one word, so it need not be Camelcased
        Naming of the methods could be improved to indicate actual behaviour
        eg: receiveMessage returns a bool and it is actually checking whether to give allegiance on receiving a message.

          Changed to the possible extent. If still I can, I will.

5.Kingdom can choose to add an ally to himself. Not anybody else. This is broken currently. eg: look at the code snippet below: HighPriest is calling the method AddAlliancetoSenderKingdom which is not correct. This whole behaviour could have belonged to the Kingdom.
    if (Universe.kingdoms[item.ToKingdom.Name].receiveMessage(item.Message, item.FromKingdom, item.ToKingdom))
          AddAlliancetoSenderKingdom(item.FromKingdom, Universe.kingdoms[item.ToKingdom.Name]);
            There are multiple such behaviours that needs to be pushed to the appropriate classes. Do have a look.

        Changed the above functionality and others which I could be able to. Let me know I there are others also
6.Is it really necessary to have such indirections ? "Universe.kingdoms[item.ToKingdom.Name]". Isn't item.ToKingdom enough ?
      I am using kingdoms as Dictionary so When I try to get the KingDom object I will use the above indirection which helps in this below function.

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

      In the above function if I have only list of KingDom object then I need to traverse or Write a LINQ query in C# to get the appropriate competitor and send message respectively
        since the Compitetors have the same name as kingdom name I will just access the kingdom object through the competitor name.
      correct me If I am doning wrong or we can do it better.

Attachments:

  the Attachments contains following files
      1. Bin - contains debug and release folder which in turn contains binary files
      2. BreakerOfChains - contains the classes and assembly files
                  Main files that are required
                      1.BallotBox.cs
                      2.HighPriest.cs
                      3.KingDom.cs
                      4.Messages.cs
                      5.Universe.cs
                      6.UniverseOpertions.cs
                      7.Validations.cs
      3.  exe - This is where exe is there we can run directly into windows system. If you guys are using mono on linux I don't know whether it is possible or not but you can build from project
                  next time will install mono and linux on my system will make it compatible on both.
      4. GeekTrust.Test
              - contains Unit tests.
The above mentioned are the most important files.


Please let me know anything which needs to be improved.

I am Ready for changes.
