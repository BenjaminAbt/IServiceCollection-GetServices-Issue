using System.Threading.Tasks;

namespace MicroCQRS
{
    public interface IMicroCqrsEngine
    {
        TQuery Resolve<TQuery>() where TQuery : IQuery;
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}