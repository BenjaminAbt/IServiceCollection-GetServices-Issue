
namespace MicroCQRS
{
    public interface IQueryFactory
    {
        TQuery Resolve<TQuery>() where TQuery : IQuery;
    }
}