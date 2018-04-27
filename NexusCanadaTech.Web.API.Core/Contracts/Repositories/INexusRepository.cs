using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace NexusCanadaTech.Web.API.Core.Contracts.Repositories
{
    public interface INexusRepository : IDisposable
    {
        DbContext DbContext { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

