using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace DummySignalRClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var server = "http://localhost:50000/dummy";
            var server = "http://localhost:60000/api/dummy";

            var connection = new HubConnectionBuilder()
                .WithUrl(server)
                .WithConsoleLogger()
                .Build();

            await connection.StartAsync();

            connection.On<string, string>("broadcastMessage", (name, message) =>
            {
                Console.WriteLine($"{name} said: {message}");
            });

            await connection.SendAsync("Send", new[] { "cristian", "dummy message from console app" });

            Console.ReadLine();
            await  connection.DisposeAsync();
        }
    }
}
