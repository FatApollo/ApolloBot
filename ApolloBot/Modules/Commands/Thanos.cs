using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace ApolloBot.Modules
{
    public static class Thanos
    {
        public static EmbedBuilder Decide(EmbedBuilder builder,SocketCommandContext Context)
        {
            int numUsers = Context.Guild.Users.Count;
            int numDead = numUsers / 2;
            int numAlive = numUsers - numDead;
            int currentNumDead = 0;
            int currentNumAlive = 0;
            Random rnd = new Random();

            List<string> usersList = new List<string>();
            List<string> aliveList = new List<string>();
            List<string> deadList = new List<string>();

            var guild = Context.Guild as SocketGuild; // Instance of the server

            usersList = DiscordFunctions.GetUsers(guild); //Get Users from server

             // Build/Format the GUI
            builder.WithTitle("Apollo commited genocide!");
            builder.WithDescription("Who has Apollo Killed?");
            builder.WithColor(Color.Teal);

            foreach (string user in usersList)
            {
                int i = rnd.Next(0, 1);
                if (i == 0 && currentNumDead != numDead)
                {
                    currentNumDead += 1;
                    deadList.Add(user);
                }
                else
                {
                    if (currentNumAlive != numAlive)
                    {
                        currentNumAlive += 1;
                        aliveList.Add(user);
                    }
                    else
                    {
                        currentNumDead += 1;
                        deadList.Add(user);
                    }
                }
            }

            string alive = "";
            string dead = "";
            foreach (string user in aliveList)
            {
                string temp = alive;
                alive = $"{temp}  {user}  "; //create string for alive users
            }

            foreach (string user in deadList)
            {
                string temp = dead;
                dead = $"{temp}  {user}  "; // create string for dead users.
            }

            builder.AddField("Total Spared:", $"{aliveList.Count.ToString()}");
            builder.AddField("Total Killed:", $"{deadList.Count.ToString()}");
            builder.AddField("Alive: ", alive);       // finish adding strings to the formatted message
            builder.AddField("Dead: ", dead);
            builder.WithAuthor(Context.User);
            builder.WithImageUrl("https://nerdist.com/wp-content/uploads/2018/05/Thanos.jpg"); //Image of Thanos

            return builder;
            
        }
    }
    
}
