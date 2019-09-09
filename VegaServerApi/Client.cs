using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VegaServerApi.Dto;
using VegaServerApi.Dto.ManageDevices;
using VegaServerApi.Dto.UserAuthorization;

namespace VegaServerApi
{
    public class Client
    {
        public Client()
        {
            clientWebSocket = new ClientWebSocket();
            clientWebSocket.ConnectAsync(new Uri("ws://127.0.0.1:8002"), CancellationToken.None).Wait();
        }

        private readonly ClientWebSocket clientWebSocket;

        private async Task Send<T>(T type)
        {
            if (clientWebSocket.State == WebSocketState.Open)
            {
                string jsonString = JsonConvert.SerializeObject(type);

                await clientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(jsonString)), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine($"Message sent: {jsonString}");
            }
        }

        private async Task<T> Receive<T>()
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            string res = string.Empty;

            //var result = clientWebSocket.ReceiveAsync(buffer, CancellationToken.None).Result;

            //while (result.Count <= 0)
            //{
            //    result =  await clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);
            //}

            do
            {
                WebSocketReceiveResult result;
                using (var ms = new MemoryStream())
                {
                    do
                    {
                        result = clientWebSocket.ReceiveAsync(buffer, CancellationToken.None).Result;
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                    } while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(ms, Encoding.UTF8))
                    {
                        res = reader.ReadToEnd();
                    }
                }
            } while (true);


            return JsonConvert.DeserializeObject<T>(res);
        }

        public async Task<string> Auth(AuthRequest authRequest)
        {
            var receive = Receive<AuthResponse>();
            await Task.WhenAll(Send(authRequest), receive);
            return receive.Result.Token;
        }

        public async Task<ManageDevicesResponse> AddOrUpdateDevices(ICollection<Device> devices)
        {
            var receive = Receive<ManageDevicesResponse>();
            var send = Send(new ManageDevicesRequest() { Devices = devices });
            await Task.WhenAll(receive, send);

            return receive.Result;
        }
    }

}
