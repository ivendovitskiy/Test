using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VegaServerApi;
using VegaServerApi.Dto.UserAuthorization;

namespace ConsoleAppTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Client client = new Client();

            await client.Auth(new AuthRequest()
            {
                Login = "root",
                Password = "123"
            });

            Console.WriteLine("[ewe");
        }
    }
}
