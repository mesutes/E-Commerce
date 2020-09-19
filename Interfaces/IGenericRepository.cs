using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetEntity(int id);

    }
}
