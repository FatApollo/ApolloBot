nusing Discord;
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
            test.CreateXMLFileUsers();

            await ReplyAsync("Xml Is Created");

            await Context.Message.DeleteAsync(null);
        }

        [Command("thanos"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task ThanosCommand()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder = Thanos.Decide(builder,Context);

            await ReplyAsync("", false, builder.Build());
            await Context.Message.DeleteAsync(null); //Delete the message that called this function
        }
    }
}   
