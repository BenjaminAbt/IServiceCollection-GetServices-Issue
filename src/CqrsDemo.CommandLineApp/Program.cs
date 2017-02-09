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


            var cmd = new WriteInfoCommand("Hello World !!!!");

            // This works
            var command = servicesProvider.GetService<IAsyncCommandHandler<WriteInfoCommand>>();
            Task.Run(async () => await command.ExecuteAsync(cmd)).Wait();


            //var fac = servicesProvider.GetService<IAsyncCommandFactory>();
            //Task.Run(async () => await fac.ExecuteAsync(cmd)).Wait();

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
