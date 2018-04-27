using System.Collections.Generic;

namespace NexusCanadaTech.Web.API.Core.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        void Save();
    }
}
