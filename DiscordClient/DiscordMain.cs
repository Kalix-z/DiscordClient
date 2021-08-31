using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;


namespace DiscordClient
{
    class DiscordMain
    {
        public static DiscordSocketClient client;
        public static string token = "ODgxMDU5NzkzOTYyNDMwNDk0.YSnU4A.cCw9N9Kg0Eq8QN0mrD3haZoN1Xo";
        public static void StartApiCommunication()
        {
            Console.WriteLine("Starting Client...");
            client = new DiscordSocketClient();
            /* Starts MainAsync() task and will enable the async events */
            new DiscordMain().MainAsync().GetAwaiter().GetResult();

        }

        public async Task MainAsync()
        {
            /* sets the bots stdout to be the console window */
            client.Log += Log;

            client.Ready += OnReady;
            /* Logs into the bot with the OAUTH2 token */

            await client.LoginAsync(TokenType.User, "ODQ2MTE2NjA5MzQzODgxMjM2.YRg2IQ.PuzY5NjqYFbnELpff2pGKBOxGsU");

            /* Starts the bots events */
            await client.StartAsync();

            /* Block this task until the program is closed. */
            await Task.Delay(-1);
        }

        private async Task OnReady()
        {
            SocketTextChannel channel = (SocketTextChannel)client.GetChannel(854577433579749388);
            await channel.SendMessageAsync("FUCK THE TOS");
        }

        /* This will take the log messages from the API and print them to the console */
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
