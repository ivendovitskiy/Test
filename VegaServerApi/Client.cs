using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VegaServerApi.Dto.UserAuthorization;

namespace VegaServerApi
{
    public class Client
    {
        public Client()
        {
            clientWebSocket = new ClientWebSocket();
            clientWebSocket.ConnectAsync(new Uri("ws://127.0.0.1:8002"), CancellationToken.None);
        }

        private readonly ClientWebSocket clientWebSocket;

        public async Task<string> Auth()
        {
            AuthRequest request = new AuthRequest()
            {
                Login = "root",
                Password = "123"
            };

            WebSocketSharp.WebSocket wsClient = new WebSocketSharp.WebSocket("ws://127.0.0.1:8002");


            wsClient.Send(JsonConvert.SerializeObject(request));


            byte[] buffer = new byte[1024];

            //await clientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(request))), WebSocketMessageType.Binary, true, CancellationToken.None);


            wsClient.OnMessage += (sender, e) =>
            {
                Console.WriteLine("New Message Received From Server : " + e.Data);
            };

            // return JsonConvert.DeserializeObject<AuthResponse>(Encoding.Unicode.GetString(buffer)).Command;
            return null;
        }
    }
}
