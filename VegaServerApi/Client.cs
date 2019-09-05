using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
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

        public string Auth()
        {
            AuthRequest request = new AuthRequest()
            {
                Login = "root",
                Password = "123"
            };
            byte[] buffer = new byte[1024];
            
            clientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(request))), WebSocketMessageType.Binary, true, CancellationToken.None);
            clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);


            return JsonConvert.DeserializeObject<AuthResponse>(Encoding.Unicode.GetString(buffer)).Command;
        }
    }
}
