using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    internal class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> m_DbSet;
        private readonly XgagDbContext m_DbContext;

        public Repository(XgagDbContext dbContext)
        {
            m_DbContext = dbContext;
            m_DbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            m_DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            m_DbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return m_DbSet.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            m_DbSet.Attach(entity);
            m_DbContext.Entry(entity).State = EntityState.Modified;
        }

        public Task SaveChangesAsync()
        {
            return m_DbContext.SaveChangesAsync();
        }
    }
}
