using System;
using VegaServerApi;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            
            Console.WriteLine(client.Auth());
        }
    }
}
