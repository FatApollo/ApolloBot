using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApolloBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Context.User;
        //Context.Client;
        //Context.Guild;
        //Context.Message;
        XML test = new XML();

        /*[Command("testfunc")]
        public async Task Test_Func()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.WithTitle("Pong!");
            builder.WithDescription("This is a pong!");
            builder.AddField("Field1", "test")
            .AddInlineField("Field2", "test");
            builder.WithColor(Color.Teal);
            builder.WithImageUrl("https://i.ytimg.com/vi/iqPqylKy-bY/maxresdefault.jpg");
            await ReplyAsync("", false, builder.Build());
        }*/

        [Command("test")]
        public async Task Test_Async()
        {
            await ReplyAsync($"{Context.Client.CurrentUser.Mention} || {Context.User.Mention} sent {Context.Message.Content} in {Context.Guild.Name}!");
            await Context.Message.DeleteAsync(null);
        }
        
        [Command("dik")]
        public async Task Context_Test_Async([Remainder] string name = "dom")
        {
            await ReplyAsync($"{name} is a dik");

            await Context.Message.DeleteAsync(null);
        }

        [Command("ban"), RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban_User([Remainder] SocketGuildUser username)
        {
            RequestOptions options = new RequestOptions();
            options.AuditLogReason = $"banned by {Context.Client.CurrentUser} using ApolloBot";

            Console.WriteLine($"{username}");
            
            await Context.Guild.AddBanAsync(username, 7, "You are a dick", options);
                       
            await ReplyAsync($"{username} is banned");
            await Context.Message.DeleteAsync(null);
        }
        
        [Command("xml")]
        public async Task XML_Print()
        {
            test.InitXML();
            test.CreateXMLFile();

            await ReplyAsync("Xml Is Created");

            await Context.Message.DeleteAsync(null);
        }

        [Command("thanos"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task Thanos()
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

            EmbedBuilder builder = new EmbedBuilder(); // Build/Format the GUI
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

            builder.AddInlineField("Total Spared:", $"{aliveList.Count.ToString()}"); 
            builder.AddInlineField("Total Killed:", $"{deadList.Count.ToString()}");
            builder.AddInlineField("Alive: ", alive);       // finish adding strings to the formatted message
            builder.AddInlineField("Dead: ", dead);
            builder.WithAuthor(Context.User);
            builder.WithImageUrl("https://nerdist.com/wp-content/uploads/2018/05/Thanos.jpg"); //Image of Thanos
            await ReplyAsync("", false, builder.Build());

            await Context.Message.DeleteAsync(null); //Delete the message that called this function
        }
    }
}   
