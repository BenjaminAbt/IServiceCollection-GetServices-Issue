using System;
using System.Threading.Tasks;

namespace MicroCQRS
{
    public abstract class MicroCqrsEngine : IMicroCqrsEngine
    {
        private readonly IQueryFactory _queryFactory;
        private readonly IAsyncCommandFactory _commandFactory;

        protected MicroCqrsEngine(IQueryFactory queryFactory, IAsyncCommandFactory commandFactory)
        {
            _queryFactory = queryFactory;
            _commandFactory = commandFactory;
        }

        public TQuery Resolve<TQuery>() where TQuery : IQuery
        {
            return _queryFactory.Resolve<TQuery>();
        }

        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            return _commandFactory.ExecuteAsync(command);
        }

    }
}