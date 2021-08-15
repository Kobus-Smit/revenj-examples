using Grpc.Net.Client;
using MagicOnion.Client;
using System;
using System.Threading.Tasks;
using AspNetTutorial.Customers;
using MessagePack;
using MessagePack.Resolvers;
using tutorial;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(1000);
            MessagePackSerializer.DefaultOptions =  ContractlessStandardResolverAllowPrivate.Options;
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = MagicOnionClient.Create<ICustomerService>(channel);
            Customer customer = await client.Lookup("b7e5a8bfd7864c0");
            Console.WriteLine(customer.name);
            Console.ReadKey();
        }
    }
}
