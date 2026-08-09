namespace WIKI_AI_PROJECT.Rulebasedchatbot
{

    public class Conversation
    {
        public string AcceptedNameInput { get; set; }

        public string DisplayName { get; set; }

        public List<ChatTurn> Turns { get; set; } = new();

        public ChatStage Stage { get; set; }
    }

    public class UserMessage
    {
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ChatAnalysis
    {
        public List<ChatAction> Actions { get; set; } = new();
        public List<ChatTopic> Topics { get; set; } = new();
        public List<ChatObject> Objects { get; set; } = new();

        public List<ChatIntent> PossibleIntents { get; set; } = new();
    }

    public class ChatTurn
    {
        public UserMessage UserMessage { get; set; } = new();
        public ChatAnalysis Analysis { get; set; } = new();
    }

    public enum ChatStage
    {
        Greeting,
        CollectingQuestion,
        Answering,
        WaitingForConfirmation,
        WaitingForIntentSelection,
        Escalating,
        Finished
    }

    public enum ChatAction
        {
            Unknown,
            Betalen,
            Wijzigen,
            Bekijken,
            Annuleren,
            Retourneren,
            Bestellen
        } 
    public enum ChatTopic
    {
        Unknown,
        Automatische_incasso,
        Factuur,
        Bestelling,
        Account
    }

    public enum ChatObject
    {
        Unknown,
        Rekeningnummer,
        Factuur,
        Bestelling,
        Wachtwoord,
        Username,
        Inloggen
        
    }

    public enum ChatIntent
    {
        PasswordChange,
        ChangeBankAccount,
        ChangeDirectDebitBankAccount,
        PasswordSee
    }
}

