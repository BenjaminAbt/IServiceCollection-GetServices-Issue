using System.IO;
using System.Threading.Tasks;
using MicroCQRS;

namespace CqrsDemo.CommandLine.CommandsHandlers
{
    public abstract class BaseCommandLineAsyncCommandHandler<TCommand, IWriter> : IAsyncCommandHandler<TCommand>
        where TCommand : ICommand
        where IWriter : TextWriter
    {

        protected BaseCommandLineAsyncCommandHandler(IWriter writer)
        {
            Writer = writer;
        }

        public IWriter Writer { get; }


        public abstract Task ExecuteAsync(TCommand command);
    }
}
