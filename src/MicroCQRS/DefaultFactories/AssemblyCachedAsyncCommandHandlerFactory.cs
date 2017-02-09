using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MicroCQRS.DefaultFactories
{
    public class AssemblyCachedAsyncCommandHandlerFactory : IAsyncCommandFactory
    {
        private readonly IServiceProvider _register;

        public AssemblyCachedAsyncCommandHandlerFactory(IServiceProvider register)
        {
            _register = register;
        }

        /// <summary>
        /// Executes given command with all handlers defined in the Unity container
        /// </summary>
        public async Task ExecuteAsync<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            IList<IAsyncCommandHandler<TCommand>> commands = _register.GetServices<IAsyncCommandHandler<TCommand>>().ToList();

            if (!commands.Any())
            {
                throw new CommandNotFoundException(command);
            }

            // Execute fire and forget commands
            foreach (IAsyncCommandHandler<TCommand> commandHandler in commands)
            {
                await commandHandler.ExecuteAsync(command);
            }
        }
    }
}
