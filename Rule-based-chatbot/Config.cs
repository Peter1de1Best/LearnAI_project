namespace WIKI_AI_PROJECT.Rulebasedchatbot
{
    public static class Config
    {
        public static readonly Dictionary<string, ChatAction> InputActionNormalization = new()
        {
            { "annuleren", ChatAction.Annuleren },
            { "annuleer", ChatAction.Annuleren},
            { "annuleert", ChatAction.Annuleren},
            { "annuleerde", ChatAction.Annuleren },
            { "annuleerden", ChatAction.Annuleren },
            { "geannuleerd", ChatAction.Annuleren },
            { "geannuleerde", ChatAction.Annuleren },
            { "annulering", ChatAction.Annuleren },
            { "annuleringen", ChatAction.Annuleren },
            //{ "cancel", ChatAction.Annuleren},
            //{ "cancels", ChatAction.Annuleren},
            //{ "cancelled", ChatAction.Annuleren },
            //{ "cancellation", ChatAction.Annuleren },
            //{ "cancelling", ChatAction.Annuleren },
            { "controleren", ChatAction.Bekijken},
            { "controleer", ChatAction.Bekijken},
            { "controleerden", ChatAction.Bekijken},
            { "gecontroleerd", ChatAction.Bekijken},
            { "controleerde", ChatAction.Bekijken},
            { "bekijken", ChatAction.Bekijken},
            { "bekijk", ChatAction.Bekijken},
            { "bekijkt", ChatAction.Bekijken},
            { "bekeken", ChatAction.Bekijken},
            { "bekeek", ChatAction.Bekijken},
            { "checken", ChatAction.Bekijken},
            { "checkten", ChatAction.Bekijken},
            { "checkte", ChatAction.Bekijken},
            { "checkt", ChatAction.Bekijken},
            { "gecheckt", ChatAction.Bekijken},
            { "inzien", ChatAction.Bekijken},
            { "ingezien", ChatAction.Bekijken},
            //{ "look at", ChatAction.Bekijken},
            { "check", ChatAction.Bekijken},
            //{ "checked", ChatAction.Bekijken},
            //{ "checking", ChatAction.Bekijken},
            { "retourneren", ChatAction.Retourneren},
            { "retourneerden", ChatAction.Retourneren},
            { "retourneerde", ChatAction.Retourneren},
            { "retourneer", ChatAction.Retourneren},
            { "retourneert", ChatAction.Retourneren},
            //{ "return", ChatAction.Retourneren},
            //{ "returned", ChatAction.Retourneren},
            //{ "returns", ChatAction.Retourneren},
            //{ "returning", ChatAction.Retourneren},
            { "bestellen", ChatAction.Bestellen },
            { "bestel", ChatAction.Bestellen },
            { "bestelde", ChatAction.Bestellen },
            { "bestelden", ChatAction.Bestellen },
            { "bestelt", ChatAction.Bestellen },
            { "besteld", ChatAction.Bestellen },
            { "aanschaffen", ChatAction.Bestellen },
            { "koop", ChatAction.Bestellen },
            { "kopen", ChatAction.Bestellen },
            { "gekocht", ChatAction.Bestellen },
            { "buy", ChatAction.Bestellen },
            //{ "ordered", ChatAction.Bestellen },
            //{ "ordering", ChatAction.Bestellen },
            { "betalen", ChatAction.Betalen },
            { "betaal", ChatAction.Betalen },
            { "betaalde", ChatAction.Betalen },
            { "betaalt", ChatAction.Betalen },
            { "betaald", ChatAction.Betalen },
            { "betaling", ChatAction.Betalen },
            { "afrekenen", ChatAction.Betalen },
            { "afgerekend", ChatAction.Betalen },
            //{ "pay", ChatAction.Betalen },
            //{ "paid", ChatAction.Betalen },
            //{ "payment", ChatAction.Betalen },
            { "wijzigen", ChatAction.Wijzigen},
            { "aanpassen", ChatAction.Wijzigen},
            { "veranderen", ChatAction.Wijzigen},
            //{ "change", ChatAction.Wijzigen},
            //{ "edit", ChatAction.Wijzigen},
            { "wijzigt", ChatAction.Wijzigen},
            { "verandert", ChatAction.Wijzigen},
            //{ "changes", ChatAction.Wijzigen},
            //{ "edits", ChatAction.Wijzigen},
            { "wijzigde", ChatAction.Wijzigen},
            { "veranderde", ChatAction.Wijzigen},
            //{ "changed", ChatAction.Wijzigen},
            //{ "edited", ChatAction.Wijzigen},
            { "gewijzigde", ChatAction.Wijzigen},
            { "aangepaste", ChatAction.Wijzigen},
            { "gewijzigd", ChatAction.Wijzigen},
            { "aangepast", ChatAction.Wijzigen},
            { "veranderd", ChatAction.Wijzigen},
            { "vergeten", ChatAction.Wijzigen}
        };

        public static readonly Dictionary<string, ChatTopic> InputTopicNormalization = new()
        {
                { "automatische incasso", ChatTopic.Automatische_incasso},
                { "incasso", ChatTopic.Automatische_incasso },
                { "machtiging", ChatTopic.Automatische_incasso },
                { "automatisch betalen", ChatTopic.Automatische_incasso },

                { "factuur", ChatTopic.Factuur },
                { "rekening", ChatTopic.Factuur },

                { "bestelling", ChatTopic.Bestelling },
                { "order", ChatTopic.Bestelling },

                { "account", ChatTopic.Account },
                { "profiel", ChatTopic.Account },
                { "inloggen", ChatTopic.Account }

        };

        public static readonly Dictionary<ChatIntent, string> UnsupportedIntents = new()
        {
            {ChatIntent.PasswordSee, "U vraagt om uw wachtwoord in te zien, maar dat kan niet om veiligheidsredenen."}
        };

        public static readonly Dictionary<string, ChatObject> InputObjectNormalization = new()
        {
            { "rekeningnummer", ChatObject.Rekeningnummer },
            { "iban", ChatObject.Rekeningnummer },

            { "factuur", ChatObject.Factuur },

            { "bestelling", ChatObject.Bestelling },

            { "wachtwoord", ChatObject.Wachtwoord },
            { "password", ChatObject.Wachtwoord },

            { "inlognaam", ChatObject.Username },
            { "username", ChatObject.Username },
            { "usernaam", ChatObject.Username },
            { "gebruikersnaam", ChatObject.Username },

            { "inloggen", ChatObject.Inloggen}
        };

        public static readonly Dictionary<ChatIntent, string> IntentToAnswerLookup = new()
        {
            {ChatIntent.ChangeBankAccount, "You can change your bank account via the link: LINK"},
            {ChatIntent.ChangeDirectDebitBankAccount, "You can change your direct debit (automatische incasso) bank account via the link: LINK"},
            {ChatIntent.PasswordChange, "You can change or restore your password via the link: LINK"},        
        };

        public static readonly Dictionary<ChatIntent, string> IntentToQuestionLookup = new()
        {
            {ChatIntent.PasswordSee, "Ik wil mijn wachtwoord inzien"},// Beschrijving van de intent blijft behouden, ook als deze intent niet ondersteund wordt
            {ChatIntent.PasswordChange, "Ik wil mijn wachtwoord wijzigen"},
            {ChatIntent.ChangeBankAccount, "Ik wil mijn rekeningnummer wijzigen"},
            {ChatIntent.ChangeDirectDebitBankAccount, "Ik wil mijn automatische incasso rekeningnummer wijzigen"}
        };


        public static readonly HashSet<string> ExitCommands = new()
        {
            "quit",
            "exit",
            "stop",
            "stoppen"
        };
    }
}