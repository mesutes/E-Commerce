using E_Commerce.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new E_CommerceContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new E_CommerceContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new E_CommerceContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            using var context = new E_CommerceContext();
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetEntity(int id)
        {
            using var context = new E_CommerceContext();
            return context.Set<TEntity>().Find(id);
        }


    }
}
