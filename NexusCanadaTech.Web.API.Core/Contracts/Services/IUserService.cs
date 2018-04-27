using NexusCanadaTech.Web.API.Core.DbModels;
using System.Collections.Generic;

namespace NexusCanadaTech.Web.API.Core.Contracts.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Insert(User user);
        void Delete(int id);
        void Update(User user);
        void Save();
        User GetByName(string name);
    }

}
