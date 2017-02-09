using MicroCQRS;

namespace CqrsDemo
{
    public class DemoEngine : MicroCqrsEngine, IDemoEngine
    {
        public DemoEngine(IQueryFactory queryFactory, IAsyncCommandFactory commandFactory) : base(queryFactory, commandFactory)
        {
        }
    }
}
