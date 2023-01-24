using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Insert(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
