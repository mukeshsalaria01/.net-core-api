using NexusCanadaTech.Web.API.Core.Contracts.Services;
using System.Collections.Generic;
using NexusCanadaTech.Web.API.Core.DbModels;
using NexusCanadaTech.Web.API.Core.Contracts.Repositories;

namespace NexusCanadaTech.Web.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(int id)
        {
            this._userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return this._userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return this._userRepository.GetById(id);
        }

        public User GetByName(string name)
        {
            return this._userRepository.GetByName(name);
        }

        public void Insert(User obj)
        {
            this._userRepository.Insert(obj);
        }

        public void Save()
        {
            this._userRepository.Save();
        }


        public void Update(User user)
        {
            this._userRepository.Update(user);
        }
    }
}
