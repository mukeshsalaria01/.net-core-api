using NexusCanadaTech.Web.API.Core.DbModels;

namespace NexusCanadaTech.Web.API.Core.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string name);
    }
}
