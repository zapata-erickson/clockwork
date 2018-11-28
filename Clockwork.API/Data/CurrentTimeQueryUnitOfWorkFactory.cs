using Clockwork.API.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Data
{
    public class CurrentTimeQueryUnitOfWorkFactory : ICurrentTimeQueryUnitOfWorkFactory
    {
        public ICurrentTimeQueryUnitOfWork CreateNew()
        {
            return new ClockworkDbContext();
        }
    }
}
