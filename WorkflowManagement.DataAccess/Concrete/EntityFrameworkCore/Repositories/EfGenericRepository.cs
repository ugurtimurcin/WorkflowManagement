using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Interfaces;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity, TContext> : IGenericDal<TEntity> where TEntity : class, ITable, new() where TContext : WorkflowManagementContext, new()
    {
        public void Create(TEntity entity)
        {
            using var db = new TContext();
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var db = new TContext();
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            using var db = new TContext();
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            using var db = new TContext();
            return db.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            using var db = new TContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
