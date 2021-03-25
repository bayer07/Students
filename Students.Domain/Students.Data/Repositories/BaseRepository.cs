using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : Model<int>
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

        Task<TModel> IRepository<TModel>.GetById(int id) => DbSet.SingleOrDefaultAsync(x => x.Id == id);

        public Task<List<TModel>> GetAll() => DbSet.ToListAsync();
    }
}