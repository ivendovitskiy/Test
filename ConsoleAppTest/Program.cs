using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VegaServerApi;
using VegaServerApi.Dto;
using VegaServerApi.Dto.UserAuthorization;

namespace ConsoleAppTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Client client = new Client();

            var token = await client.Auth(new AuthRequest()
            {
                Login = "root",
                Password = "123"
            });

            Console.WriteLine(token);


            List<Device> devices = new List<Device>()
            {
                new Device
                {
                    DevName="333133377338550C",
                    DevEui = "333133377338550C",
                    Otaa = new Otaa
                    {
                        AppEui = "546F70617A313034",
                        AppKey="7338490C000000007338490C15512F4F"
                    },
                    Abp = new Abp
                    {
                        AppSKey = "40000E00333133373338470C66697A43",
                        DevAddress = 24774976,
                        NwkSKey = "3338470C3331333740000E007338550C"
                    }
                },
                new Device
                {
                    DevName="333133377338550C",
                    DevEui = "333133377338550C",
                    Otaa = new Otaa
                    {
                        AppEui = "546F70617A313034",
                        AppKey="7338490C000000007338490C15512F4F"
                    },
                    Abp = new Abp
                    {
                        AppSKey = "40000E00333133373338470C66697A43",
                        DevAddress = 24774976,
                        NwkSKey = "3338470C3331333740000E007338550C"
                    }
                },
                new Device
                {
                    DevName="333133377338550C",
                    DevEui = "333133377338550C",
                    Otaa = new Otaa
                    {
                        AppEui = "546F70617A313034",
                        AppKey="7338490C000000007338490C15512F4F"
                    },
                    Abp = new Abp
                    {
                        AppSKey = "40000E00333133373338470C66697A43",
                        DevAddress = 24774976,
                        NwkSKey = "3338470C3331333740000E007338550C"
                    }
                }
            };

            Thread.Sleep(10000);

            var result2 = await client.AddOrUpdateDevices(devices: devices);

            foreach (var item in result2.Devices)
            {
                Console.WriteLine(item.DevName);
            }

            Console.WriteLine("[ewe");

            Console.ReadLine();
        }
    }
}
