using System.Threading.Tasks;

namespace MicroCQRS
{
    /// <summary>
    /// Contract for command handlers. Implements the logic to run.
    /// </summary>
    public interface IAsyncCommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}