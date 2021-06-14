using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace ApolloBot.Modules
{
    public static class DiscordFunctions
    {
        public static List<string> GetUsers(SocketGuild Guild)
        {
            List<string> usersList = new List<string>();

            var users = Guild.Users;

            foreach (var user in users)
            {
                usersList.Add(user.Username);                
            }

            return usersList;
        }
    }
}
