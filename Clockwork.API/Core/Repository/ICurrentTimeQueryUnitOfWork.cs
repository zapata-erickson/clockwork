using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Core.Repository
{
    public interface ICurrentTimeQueryUnitOfWork : IDisposable
    {
        ICurrentTimeQueryRepository Queries { get; }
        void SaveChanges();
    }
}
