using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloBot.Modules
{
    public class BotInformation
    {
        public string _bot_token;
        public string _bot_prefix;

        public DiscordSocketClient _client;
        public CommandService _commands;
        public IServiceProvider _services;

        public void Init(string BotToken, string BotPrefix, DiscordSocketClient Client, CommandService Commands, IServiceProvider Services)
        {
            _bot_token = BotToken;
            _bot_prefix = BotPrefix;
            _client = Client;
            _commands = Commands;
            _services = Services;

        }
    }

}
