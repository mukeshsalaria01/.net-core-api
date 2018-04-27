using Microsoft.EntityFrameworkCore;
using NexusCanadaTech.Web.API.Core.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NexusCanadaTech.Web.API.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected INexusRepository db;
        protected readonly DbSet<T> dbSet;

        protected GenericRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<NexusRepository>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-UU6RSPJM;Initial Catalog=whatrocks;Persist Security Info=False;Integrated Security=True;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            db = new NexusRepository(optionsBuilder.Options);
            dbSet = db.DbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            db.DbContext.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T getObjById = dbSet.Find(id);
            dbSet.Remove(getObjById);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}
