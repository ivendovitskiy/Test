using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VegaServerApi.Dto;
using VegaServerApi.Dto.UserAuthorization;

namespace VegaServerApi
{
    public class Client
    {
        public Client()
        {
            unicodeEncoding = new UnicodeEncoding();

            clientWebSocket = new ClientWebSocket();
            clientWebSocket.ConnectAsync(new Uri("ws://127.0.0.1:8002"), CancellationToken.None).Wait();
        }

        private readonly ClientWebSocket clientWebSocket;
        private readonly UnicodeEncoding unicodeEncoding;
        private string token;

        private async Task Send<T>(T type)
        {
            if (clientWebSocket.State == WebSocketState.Open)
            {
                string jsonString = JsonConvert.SerializeObject(type);

                await clientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(jsonString)), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine($"Message sent: {jsonString}");

                await Task.Delay(5000);
            }
        }

        private async Task<T> Receive<T>()
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);

            var result = clientWebSocket.ReceiveAsync(buffer, CancellationToken.None).Result;

            while (result.Count <= 0)
            {
                result =  await clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);
            }


            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(buffer.Array));
        }

        public async Task<AuthResponse> Auth(AuthRequest authRequest)
        {
            //var receive = Receive<AuthResponse>();

           // await Task.WhenAll(Send(authRequest), receive);

            await Task.WhenAll(Send(authRequest), Receive<AuthResponse>());

            // token = receive.Result.Token;

            //return receive.Result;
            return null;
        }
    }

}
