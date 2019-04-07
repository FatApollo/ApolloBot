using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloBot.Modules.Settings
{
    public class BotSettings
    {
        private string _bot_token;
        private string _bot_prefix;
        
        public BotSettings()
        {
            _bot_prefix = "££";
            _bot_token = "";
        }
        
        public string GetBotToken()
        {
            return _bot_token;
        }

        public void SetBotToken(string Token)
        {
            _bot_token = Token;
        }

        public string GetBotPrefix()
        {
            return _bot_prefix;
        }

        public void SetBotPrefix(string Prefix)
        {
            _bot_prefix = Prefix;
        }

    }
}
