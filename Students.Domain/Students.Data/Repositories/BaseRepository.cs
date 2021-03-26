using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : StudentModel
    {
        protected readonly StudentsContext ctx;
        protected abstract DbSet<TModel> DbSet { get; }

        protected BaseRepository(StudentsContext ctx)
        {
            this.ctx = ctx;
        }
        public virtual void Create(TModel model)
        {
            DbSet.Add(model);
            ctx.SaveChanges();
        }

        public virtual void Update(TModel model)
        {
            DbSet.Update(model);
            ctx.SaveChanges();
        }

        public virtual void Delete(TModel model)
        {
            DbSet.Remove(model);
            ctx.SaveChanges();
        }

        // Override if need include something
        public virtual Task<TModel> GetById(int id) => DbSet.SingleOrDefaultAsync(x => x.Id == id);

        // Override if need include something
        public virtual Task<List<TModel>> GetAll() => DbSet.ToListAsync();

        public virtual IQueryable<TModel> AsQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}