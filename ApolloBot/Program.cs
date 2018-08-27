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
        string _bot_token = "";
        string _bot_prefix = "££";
        
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
                       
        public async Task Run_Bot_Async()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();


            //event supscriptions
            _client.Log += Log;
            _client.UserJoined += Announced_User_Joined;

            await Register_Commands_Async();
            await _client.LoginAsync(TokenType.Bot, _bot_token);
            await _client.StartAsync();
            await Task.Delay(-1);

        }

        public async Task Register_Commands_Async()
        {
            _client.MessageReceived += Handle_Command_Async;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task Handle_Command_Async(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            
            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix(_bot_prefix,ref argPos) || message.HasMentionPrefix(_client.CurrentUser,ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        private async Task Announced_User_Joined(SocketGuildUser user)
        {
            var guild = user.Guild;//guild info stored in the user
            var channel = guild.DefaultChannel; //SocketTextChannel 
            await channel.SendMessageAsync($"Welcome, {user.Mention}");
            
        }

        private Task Log(LogMessage logMessage)
        {
            Console.WriteLine(logMessage);

            return Task.CompletedTask;

        }

    }
}
