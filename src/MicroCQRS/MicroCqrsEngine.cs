using System;
using System.Threading.Tasks;

namespace MicroCQRS
{
    public abstract class MicroCqrsEngine
    {
        private readonly IQueryFactory _queryFactory;
        private readonly IAsyncCommandFactory _commandFactory;
        private readonly IServiceProvider _serviceProvider;

        protected MicroCqrsEngine(IQueryFactory queryFactory, IAsyncCommandFactory commandFactory)
        {
            _queryFactory = queryFactory;
            _commandFactory = commandFactory;
        }

        public TQuery Resolve<TQuery>() where TQuery : IQuery
        {
            return _queryFactory.Resolve<TQuery>();
        }

        public Task ExecuteAsync(ICommand command)
        {
            return _commandFactory.ExecuteAsync(command);
        }

    }
}