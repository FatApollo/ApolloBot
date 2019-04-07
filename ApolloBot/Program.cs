using ApolloBot.Modules;
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

        public async Task Run_Bot_Async()
        {
            BotInformation info = new BotInformation();

            DiscordSocketClient client = new DiscordSocketClient();
            CommandService commands = new CommandService();
            IServiceProvider services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();


            info.Init("NDgzNjE3NDMyNTk0ODA4ODM0.XKniWQ.kB_fcEKyi6pOIaynD_J7FbPH6vs", "££", client, commands, services);
                
            discordEvents.Init(info);

            await discordEvents.Register_Commands_Async();
            await info._client.LoginAsync(TokenType.Bot, info._bot_token);
            await info._client.StartAsync();
            await Task.Delay(-1);

        }        

    }
}
