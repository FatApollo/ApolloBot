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

        [Command("testfunc")]
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
        }

        [Command("test")]
        public async Task Test_Async()
        {
            await ReplyAsync($"{Context.Client.CurrentUser.Mention} || {Context.User.Mention} sent {Context.Message.Content} in {Context.Guild.Name}!");
        }
        
        [Command("dik")]
        public async Task Context_Test_Async([Remainder] string name = "dom")
        {
            await ReplyAsync($"{name} is a dik");
        }

        [Command("ban"), RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban_User([Remainder] SocketGuildUser username)
        {
            RequestOptions options = new RequestOptions();
            options.AuditLogReason = $"banned by {Context.Client.CurrentUser} using ApolloBot";

            Console.WriteLine($"{username}");

            await Context.Guild.AddBanAsync(username,7,"You are a dick", options);

            await ReplyAsync($"{username} is banned");
        }
        
        [Command("xml")]
        public async Task XML_Print()
        {
            test.InitXML();
            test.CreateXMLFile();

            await ReplyAsync("Xml Is Created");
        }

        [Command("thanos")]
        public async Task Thanos()
        {
            int numUsers = Context.Guild.Users.Count;
            int numDead = numUsers / 2;
            int currentNumDead = 0;
            Random rnd = new Random();

            List<string> usersList = new List<string>();

            //List<IUser> iusers = new List<IUser>();
            var guild = Context.Guild as SocketGuild;

            usersList = DiscordFunctions.GetUsers(guild);

            foreach (string user in usersList)
            {
                int i = rnd.Next(0, 1);
                if (i != 0 && currentNumDead != numDead)
                {
                    await ReplyAsync($"{user} is Dead");
                    currentNumDead += 1;
                }
                else
                {
                    await ReplyAsync($"{user} has Survived");
                }
            }
            await ReplyAsync("Apollo has Decided");
        }
    }
}   
