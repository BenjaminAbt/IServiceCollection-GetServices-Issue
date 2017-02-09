using System;
using System.Collections.Generic;

namespace MicroCQRS
{
    public sealed class CommandNotFoundException : Exception
    {
        /// <summary>
        /// Unknown command type
        /// </summary>
        public ICommand Command { get; }

        /// <summary>
        /// Creates an instance of <see cref="CommandNotFoundException"/>
        /// </summary>
        public CommandNotFoundException(ICommand command) : base($@"Unknown command ""{command.GetType().FullName}"".")
        {
            Command = command;
        }
    }
}