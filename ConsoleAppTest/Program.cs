using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using VegaServerApi;
using VegaServerApi.Dto.UserAuthorization;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            AuthRequest request = new AuthRequest()
            {
                Login = "root",
                Password = "123"
            };

            WebSocketSharp.WebSocket wsClient = new WebSocketSharp.WebSocket("ws://127.0.0.1:8002");

            wsClient.Connect();
            wsClient.Send(JsonConvert.SerializeObject(request));


            byte[] buffer = new byte[1024];

            //await clientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(request))), WebSocketMessageType.Binary, true, CancellationToken.None);


            wsClient.OnOpen += (sender, e) =>
            {
                Console.WriteLine("OnOpen : server msg : " + e);
            };

            wsClient.OnMessage += (sender, e) =>
            {
                Console.WriteLine("New Message Received From Server : " + e.Data);
            };

            wsClient.OnClose += (sender, e) =>
            {
                Console.WriteLine("OnClose : server msg : " + e);
            };

            wsClient.OnError += (sender, e) =>
            {
                Console.WriteLine("OnError : server msg : " + e);
            };



            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
