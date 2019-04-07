using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using ApolloBot.Modules;

namespace ApolloBot.Modules
{
    public class Events
    {

        BotInformation info;

        public void Init(BotInformation information)
        {
            info = new BotInformation();

            info._bot_token = information._bot_token;
            info._bot_prefix = information._bot_prefix;
            info._client = information._client;
            info._commands = information._commands;
            info._services = information._services;

            EventSubscriptions();

        }

        public void EventSubscriptions()
        {
            //event supscriptions
            info._client.Log += Log;
            info._client.UserJoined += Announced_User_Joined;
        }

        public async Task Register_Commands_Async()
        {
            info._client.MessageReceived += Handle_Command_Async;
            await info._commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        public async Task Handle_Command_Async(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix(info._bot_prefix, ref argPos) || message.HasMentionPrefix(info._client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(info._client, message);
                var result = await info._commands.ExecuteAsync(context, argPos, info._services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        public async Task Announced_User_Joined(SocketGuildUser user)
        {
            var guild = user.Guild;//guild info stored in the user
            var channel = guild.DefaultChannel; //SocketTextChannel 
            await channel.SendMessageAsync($"Welcome, {user.Mention}");

        }

        public static Task Log(LogMessage logMessage)
        {
            Console.WriteLine(logMessage);

            return Task.CompletedTask;

        }
    }
}
