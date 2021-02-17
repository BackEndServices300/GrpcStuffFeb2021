﻿using Grpc.Net.Client;
using GrpcServer;
using System;

namespace GrpcClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Calling GRPC Services!");
            Console.Write("What is your name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Hit Enter to Call the Service");
            Console.ReadLine();

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var greeterClient = new Greeter.GreeterClient(channel);

            var requestMessage = new HelloRequest { Name = name };
            var reply = await greeterClient.SayHelloAsync(requestMessage);

            Console.WriteLine($"The Service Said: {reply.Message}");
            Console.ReadLine();
        }
    }
}