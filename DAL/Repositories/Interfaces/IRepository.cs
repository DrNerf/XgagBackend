using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task SaveChangesAsync();
    }
}
