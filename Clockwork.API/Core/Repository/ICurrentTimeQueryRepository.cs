using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Clockwork.API.Core.Repository
{
    public interface ICurrentTimeQueryRepository
    {
        IEnumerable<CurrentTimeQuery> Find(Expression<Func<CurrentTimeQuery, bool>> whereExpression);
        void Add(CurrentTimeQuery item);
    }
}
