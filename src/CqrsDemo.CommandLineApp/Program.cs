using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsDemo.Commands;
using CqrsDemo.Register;
using MicroCQRS;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsDemo.CommandLineApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            {
                // Register
                services.UseDemoEngine();
                services.UseDemoAssemblyFactories();
                services.UseDemoCommandLine();

            }

            IServiceProvider servicesProvider = services.BuildServiceProvider();

            // This works
            var command = servicesProvider.GetService<IAsyncCommandHandler<WriteInfoCommand>>();
            Task.Run(async () => await command.ExecuteAsync(new WriteInfoCommand("Hello World !!!!"))).Wait();

            // This will fail
            Task.Run(async () => await RunAsync(servicesProvider.GetService<IDemoEngine>())).Wait();

            Console.Write("Done");
            Console.ReadKey();
        }

        public static async Task RunAsync(IDemoEngine demoEngine)
        {
            await demoEngine.ExecuteAsync(new WriteInfoCommand("Hello World DI 2"));
        }
    }
}
