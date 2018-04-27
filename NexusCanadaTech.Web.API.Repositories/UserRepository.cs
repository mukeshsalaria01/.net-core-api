using System;
using System.Linq;
using NexusCanadaTech.Web.API.Core.Contracts.Repositories;
using NexusCanadaTech.Web.API.Core.DbModels;

namespace NexusCanadaTech.Web.API.Repositories
{
    public  class UserRepository : GenericRepository<User>, IUserRepository
    {
        public User GetByName(string name)
        {
           
            return this.dbSet.FirstOrDefault(x => String.Equals(x.FirstName,name, StringComparison.CurrentCultureIgnoreCase) || String.Equals(x.LastName, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
