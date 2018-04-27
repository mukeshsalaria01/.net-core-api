using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NexusCanadaTech.Web.API.Core.Contracts.Repositories;
using NexusCanadaTech.Web.API.Core.DbModels;
using NexusCanadaTech.Web.API.Repositories.Mapping;

namespace NexusCanadaTech.Web.API.Repositories
{
    public class NexusRepository : DbContext, INexusRepository
    {
        public NexusRepository(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public Task<int> SaveChangesAsync()
        {
            try
            {
                return base.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
        }
    }
}
