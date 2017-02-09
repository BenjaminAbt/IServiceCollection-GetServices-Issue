using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MicroCQRS.DefaultFactories
{
    public class AssemblyCachedQueryHandlerFactory : IQueryFactory
    {
        private readonly IServiceProvider _register;

        public AssemblyCachedQueryHandlerFactory(IServiceProvider register)
        {
            _register = register;
        }

        public TQuery Resolve<TQuery>() where TQuery : IQuery
        { 
            IList<TQuery> queries = _register.GetServices<TQuery>().ToList();
            if (queries.Count > 1)
            {
                throw new MultipleQueryHandlersFoundException(typeof(TQuery));
            }

            return queries.SingleOrDefault();
        }
    }
}