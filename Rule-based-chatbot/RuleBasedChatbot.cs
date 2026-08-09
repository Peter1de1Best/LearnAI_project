namespace WIKI_AI_PROJECT.Rulebasedchatbot
{
    public class RuleBasedChatbot
    {
        public void RunChatbot()
        {
            Conversation conversation = new Conversation();

            SayWelcome();
            AskAndGetName(conversation);
            SayHello(conversation);

            HelpersRuleBasedChatbot Helpers = new HelpersRuleBasedChatbot();

            while (true)
            {
                Console.WriteLine();
                Console.Write($"{conversation.DisplayName}'s question: ");

                Helpers.ReadAndStoreUserMessage(conversation);

                if (conversation.Stage == ChatStage.Finished)
                {
                    break;
                }

                ChatTurn currentTurn = conversation.Turns.Last();

                Helpers.DetectAction(currentTurn);
                Helpers.DetectTopic(currentTurn);
                Helpers.DetectObject(currentTurn);

                Helpers.DetermineIntents(currentTurn);

                //bool continueChat = Helpers.HandleAction(action);
                bool continueChat = Helpers.HandleDetectedIntents(currentTurn, conversation);

                if (!continueChat)
                {
                    break;
                }
            }
        }
        
        private void SayWelcome()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("      Welkom bij mijn chatbot");
            Console.WriteLine("=================================");
            Console.WriteLine();
        }

        private void AskAndGetName(Conversation conversation) //intitial question
        {
            Console.Write("Hello, I'm Chatbot of the Croods.\nWhat's your name?\nUser: ");

            String? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"You chose not to answer.\nUsing \"User\" for chatbot behavior.");
                conversation.AcceptedNameInput = "User";
                conversation.DisplayName = "User";
                return;
            }

            conversation.AcceptedNameInput = name;

            for (int i=0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]))
                {
                    if (i == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your name must start with letters.");
                        Console.WriteLine("Please use format: Firstname Lastname or Firstname.");
                        AskAndGetName(conversation);
                        return;
                    }

                    conversation.DisplayName = name.Substring(0, i);
                    Console.WriteLine();
                    Console.WriteLine($"You gave the input {name}.\nSimplifying to {conversation.DisplayName} for chatbot behavior.");
                    return;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Your name: " + name);
            conversation.DisplayName = name;
        }

        private void SayHello(Conversation conversation)
        {
            Console.WriteLine();
            Console.WriteLine($"Hello {conversation.DisplayName}");
        }
    }
}