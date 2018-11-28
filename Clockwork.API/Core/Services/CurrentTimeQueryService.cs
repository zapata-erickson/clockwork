using Clockwork.API.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Core.Services
{
    public class CurrentTimeQueryService : ICurrentTimeQueryService
    {
        private ICurrentTimeQueryUnitOfWorkFactory uowFactory;

        public CurrentTimeQueryService(ICurrentTimeQueryUnitOfWorkFactory uowFactory)
        {
            this.uowFactory = uowFactory;
        }

        public IEnumerable<CurrentTimeQuery> GetAllQueries()
        {
            using (var uow = uowFactory.CreateNew())
            {
                var queries = uow.Queries.Find(entry => true);
                if(queries != default(IEnumerable<CurrentTimeQuery>))
                {
                    return queries.ToList();
                }
                else
                {
                    return new List<CurrentTimeQuery>();
                }                
            }
        }

        public void Log(CurrentTimeQuery item)
        {
            using (var uow = uowFactory.CreateNew())
            {
                var count = uow.Queries.Find(entry => true).Count();
                var newEntry = new CurrentTimeQuery
                {
                    CurrentTimeQueryId = item.CurrentTimeQueryId,
                    ClientIp = item.ClientIp,
                    Time = item.Time,
                    UTCTime = item.UTCTime
                };

                uow.Queries.Add(newEntry);

                uow.SaveChanges();

                item.CurrentTimeQueryId = newEntry.CurrentTimeQueryId;
            }
        }
    }
}
