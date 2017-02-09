using System;
using System.IO;
using CqrsDemo.CommandLine.CommandsHandlers;
using CqrsDemo.Commands;
using MicroCQRS;
using MicroCQRS.DefaultFactories;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsDemo.Register
{

    public static class DemoRegister
    {
        public static IServiceCollection UseDemoEngine(this IServiceCollection services)
        {
            services.AddTransient<TextWriter>(provider => Console.Out);
            services.AddTransient<IDemoEngine, DemoEngine>();

            return services;
        }

        public static IServiceCollection UseDemoAssemblyFactories(this IServiceCollection services)
        {
            services.AddSingleton<IQueryFactory, AssemblyCachedQueryHandlerFactory>();
            services.AddSingleton<IAsyncCommandFactory, AssemblyCachedAsyncCommandHandlerFactory>();

            return services;
        }

        public static IServiceCollection UseDemoCommandLine(this IServiceCollection services)
        {
            // Commands

            // Queries
            services.AddTransient<IAsyncCommandHandler<WriteInfoCommand>, WriteInfoToCommandLineHandler>();

            return services;
        }
    }


}
