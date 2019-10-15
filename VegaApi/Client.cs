using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VegaApi
{
    public class Client
    {
        public Client()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(new Uri("ws://127.0.0.1:8002"))
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private readonly HubConnection connection;

        public void Connect()
        {
            connection.On<string>()
        }
    }
}
