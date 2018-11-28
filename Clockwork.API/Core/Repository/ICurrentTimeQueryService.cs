using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Core.Repository
{
    public interface ICurrentTimeQueryService
    {
        IEnumerable<CurrentTimeQuery> GetAllQueries();
        void Log(CurrentTimeQuery item);
    }
}
