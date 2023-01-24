using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context) => _context = context;

        public void Delete(int id)
        {
            _context.Remove(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();
            return query.Any() ? query.ToList() : Enumerable.Empty<TEntity>();

        }

        public TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(obj => obj.Id == id);
            return query.Any() ? query.FirstOrDefault() : null;
        }

        public TEntity Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
