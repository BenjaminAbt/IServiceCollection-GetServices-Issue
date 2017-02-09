using System.Threading.Tasks;
using MicroCQRS;

namespace CqrsDemo
{
    public interface IDemoEngine
    {
        TQuery Resolve<TQuery>() where TQuery : IQuery;
        Task ExecuteAsync(ICommand command);
    }
}