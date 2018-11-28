using System;
using Clockwork.API.Core;
using Clockwork.API.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Data
{
    public class ClockworkDbContext : DbContext, ICurrentTimeQueryUnitOfWork
    {
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }

        ICurrentTimeQueryRepository ICurrentTimeQueryUnitOfWork.Queries
        {
            get
            {
                return new CurrentTimeQueryRepository(this);
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
