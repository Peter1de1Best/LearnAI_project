namespace WIKI_AI_PROJECT.Rulebasedchatbot
{
    public class HelpersRuleBasedChatbot
    {
        public void ReadAndStoreUserMessage(Conversation conversation)
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("You must give an input.");
                    continue;
                }
                
                string normalizedInput = input.Trim().ToLower();

                if (Config.ExitCommands.Contains(normalizedInput))
                {
                    conversation.Stage = ChatStage.Finished;
                    return;
                }
                
                conversation.Turns.Add(new ChatTurn
                {
                    UserMessage = new UserMessage
                    {
                        Text = input,
                        Timestamp = DateTime.Now
                    },
                    Analysis = new ChatAnalysis()
                });
                return;
            }

        }
        
        public void DetectAction(ChatTurn currentTurn)
        {
            
            string[] words = currentTurn.UserMessage.Text
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(string word in words)
            {
                if (Config.InputActionNormalization.TryGetValue(word, out ChatAction action))
                {
                    currentTurn.Analysis.Actions.Add(action);
                }
            }

            if (currentTurn.Analysis.Actions.Count == 0)
            {
                currentTurn.Analysis.Actions.Add(ChatAction.Unknown);
            }
        }

        public void DetectTopic(ChatTurn currentTurn)
        {
            string[] words = currentTurn.UserMessage.Text
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (Config.InputTopicNormalization.TryGetValue(word, out ChatTopic topic))
                {
                    currentTurn.Analysis.Topics.Add(topic);
                }
            }

            if (currentTurn.Analysis.Topics.Count == 0)
            {
                currentTurn.Analysis.Topics.Add(ChatTopic.Unknown);
            }
        }

        public void DetectObject(ChatTurn currentTurn)
        {
            string[] words = currentTurn.UserMessage.Text
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (Config.InputObjectNormalization.TryGetValue(word, out ChatObject thisObject))
                {
                    currentTurn.Analysis.Objects.Add(thisObject);
                }
            }

            if (currentTurn.Analysis.Objects.Count == 0)
            {
                currentTurn.Analysis.Objects.Add(ChatObject.Unknown);
            }
        }

        public void DetermineIntents(ChatTurn currentTurn)
        {
            HelpersChatAnalysis helperChatAnalysis = new HelpersChatAnalysis ();

            if (helperChatAnalysis.IsPasswordChangeRequest(currentTurn))
            {
                currentTurn.Analysis.PossibleIntents.Add(ChatIntent.PasswordChange);
            }

            if (helperChatAnalysis.IsPasswordSeeRequest(currentTurn))
            {
                currentTurn.Analysis.PossibleIntents.Add(ChatIntent.PasswordSee);
            }

            if (helperChatAnalysis.IsAccountNumberChange(currentTurn))
            {
                if (currentTurn.Analysis.Topics.Contains(ChatTopic.Automatische_incasso))
                {
                    currentTurn.Analysis.PossibleIntents.Add(ChatIntent.ChangeDirectDebitBankAccount);
                }
                else
                {
                    currentTurn.Analysis.PossibleIntents.Add(ChatIntent.ChangeBankAccount);
                }
            }
        }



        public bool HandleDetectedIntents(ChatTurn currentTurn, Conversation conversation)
        {
            if (currentTurn.Analysis.PossibleIntents.Count == 0)
            {
                return UnknownQuestion(conversation);
            }
            
            if (currentTurn.Analysis.PossibleIntents.Contains(ChatIntent.PasswordSee))
            {
                if (currentTurn.Analysis.PossibleIntents.Count == 1)
                {
                    return AnswerQuestion(conversation, Config.UnsupportedIntents[ChatIntent.PasswordSee]);
                }
                else
                {
                    Console.WriteLine($"Als u bedoelde: {Config.UnsupportedIntents[ChatIntent.PasswordSee]}, dan is dat helaas niet mogelijk.");
                    currentTurn.Analysis.PossibleIntents.Remove(ChatIntent.PasswordSee);
                }
            }

            if (currentTurn.Analysis.PossibleIntents.Count == 1)
            {
                ChatIntent intent = currentTurn.Analysis.PossibleIntents.First();

                return AnswerQuestion(conversation, Config.IntentToAnswerLookup[intent]);
            }

            return AskForIntentClarification(currentTurn);
        }

        //public bool HandleDetectedIntents(ChatTurn currentTurn, Conversation conversation)
        //{
        //    
        //}

        public bool RejectQuestion(Conversation conversation, string answer)
        {
            conversation.Stage = ChatStage.CollectingQuestion;

            Console.WriteLine(answer);
            
            Console.WriteLine("DEAD END");

            return true;
        }

        public bool AnswerQuestion(Conversation conversation, string answer)
        {
            conversation.Stage = ChatStage.Answering;

            Console.WriteLine(answer);
            
            Console.WriteLine("DEAD END");
            
            return false;
        }

        private bool UnknownQuestion(Conversation conversation)
        {
            Console.WriteLine(
                "Ik begrijp uw vraag helaas niet. " +
                "Kunt u uw vraag anders formuleren?"
            );

            conversation.Stage = ChatStage.CollectingQuestion;

            return true;
        }

        private bool AskForIntentClarification(ChatTurn currentTurn)
        {
            Console.WriteLine("Ik begrijp meerdere mogelijke vragen:");

            foreach (ChatIntent intent in currentTurn.Analysis.PossibleIntents.ToList())
            {


                if (intent == ChatIntent.PasswordSee)
                {

                }

                Console.WriteLine($"{currentTurn.Analysis.PossibleIntents.IndexOf(intent) + 1}. {Config.IntentToQuestionLookup[intent]}");
            }

            Console.WriteLine("Welke vraag bedoelt u?");

            return true;
        }

        public bool HandleAction(ChatAction action)
        {
            Console.WriteLine();

            switch(action)
            {
                case ChatAction.Annuleren:
                    Console.WriteLine("ALGEMENE INFORMATIE OVER BESTELLING ANNULEREN");
                    Console.WriteLine("DEAD END");
                    return false;
                    //break;

                case ChatAction.Bekijken:
                    Console.WriteLine("ALGEMENE INFORMATIE OVER BESTELLING BEKIJKEN");
                    Console.WriteLine("DEAD END");
                    return false;
                    //break;

                case ChatAction.Retourneren:
                    Console.WriteLine("ALGEMENE INFORMATIE OVER BESTELLING RETOURNEREN");
                    Console.WriteLine("DEAD END");
                    return false;
                    //break;

                case ChatAction.Bestellen:
                    Console.WriteLine("ALGEMENE INFORMATIE OVER BESTELLING DOEN");
                    Console.WriteLine("DEAD END");
                    return false;
                    //break;

                case ChatAction.Betalen:
                    Console.WriteLine("ALGEMENE INFORMATIE OVER BETALEN");
                    Console.WriteLine("DEAD END");
                    return false;
                    //break;

                case ChatAction.Wijzigen:
                    Console.WriteLine("ALGEMENE INFORMATIE OVER Wijzigen");
                    Console.WriteLine("DEAD END");
                    return false;
                    //break;

                default:
                    Console.WriteLine("I couldn't determine the action.");
                    Console.WriteLine("Please rephrase your question.");
                    return true;
                    //break;
            }
        }
        
    }

    public class HelpersChatAnalysis
    {
        public bool IsPasswordChangeRequest(ChatTurn currentTurn)
        {
            return 
                currentTurn.Analysis.Objects.Contains(ChatObject.Wachtwoord) && 
                currentTurn.Analysis.Actions.Contains(ChatAction.Wijzigen) && 
                    (currentTurn.Analysis.Topics.Contains(ChatTopic.Account) || currentTurn.Analysis.Topics.Contains(ChatTopic.Unknown));
        }

        public bool IsPasswordSeeRequest(ChatTurn currentTurn)
        {
            return
                currentTurn.Analysis.Objects.Contains(ChatObject.Wachtwoord) && 
                currentTurn.Analysis.Actions.Contains(ChatAction.Bekijken) && 
                    (currentTurn.Analysis.Topics.Contains(ChatTopic.Account) || currentTurn.Analysis.Topics.Contains(ChatTopic.Unknown));
        }

        public bool IsAccountNumberChange(ChatTurn currentTurn)
        {
            return 
                currentTurn.Analysis.Actions.Contains(ChatAction.Wijzigen) &&
                currentTurn.Analysis.Objects.Contains(ChatObject.Rekeningnummer);
        }
        
    }
}