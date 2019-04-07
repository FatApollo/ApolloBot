using ApolloBot.Modules;
using ApolloBot.Modules.Settings;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ApolloBot
{
    class Program
    {
        static void Main(string[] args) => new Program().Run_Bot_Async().GetAwaiter().GetResult();       

        Events discordEvents = new Events();
        XML XMLReader = new XML();
        BotSettings settings = new BotSettings();
        BotInformation info = new BotInformation();
        DiscordSocketClient client = new DiscordSocketClient();
        CommandService commands = new CommandService();

        public async Task Run_Bot_Async()
        {
            XMLReader.LoadXML(settings);
            
            IServiceProvider services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();
            
            info.Init(settings.GetBotToken(), settings.GetBotPrefix(), client, commands, services);
                
            discordEvents.Init(info);

            await discordEvents.Register_Commands_Async();
            await info._client.LoginAsync(TokenType.Bot, info._bot_token);
            await info._client.StartAsync();
            await Task.Delay(-1);
        }        
    }
}
