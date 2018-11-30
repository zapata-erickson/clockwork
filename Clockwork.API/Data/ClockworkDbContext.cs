using System;
using Clockwork.API.Core;
using Clockwork.API.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Data
{
    public class ClockworkDbContext : DbContext, ICurrentTimeQueryUnitOfWork
    {
        private ICurrentTimeQueryRepository currentTimeQueryRepository;

        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }

        ICurrentTimeQueryRepository ICurrentTimeQueryUnitOfWork.Queries
        {
            get
            {
                if(currentTimeQueryRepository==null)
                {
                    this.currentTimeQueryRepository = new CurrentTimeQueryRepository(this);
                }
                return this.currentTimeQueryRepository;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
        }

        void ICurrentTimeQueryUnitOfWork.SaveChanges()
        {
            this.SaveChanges();
        }
    }    
}
