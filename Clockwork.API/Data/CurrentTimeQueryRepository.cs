using Clockwork.API.Core;
using Clockwork.API.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clockwork.API.Data
{
    public class CurrentTimeQueryRepository : ICurrentTimeQueryRepository
    {
        private readonly ClockworkDbContext context;

        public CurrentTimeQueryRepository(ClockworkDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CurrentTimeQuery> Find(Expression<Func<CurrentTimeQuery, bool>> whereExpression)
        {
            return this.context.CurrentTimeQueries.Where(whereExpression);
        }

        public void Add(CurrentTimeQuery item)
        {
            this.context.CurrentTimeQueries.Add(item);
        }
    }
}
