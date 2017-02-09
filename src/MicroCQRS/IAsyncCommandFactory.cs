using System.Threading.Tasks;

namespace MicroCQRS
{
    public interface IAsyncCommandFactory
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}