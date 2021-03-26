using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Domain.Models;

namespace Students.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : StudentModel
    {
        void Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        Task<TModel> GetById(int id);
        Task<List<TModel>> GetAll();
        IQueryable<TModel> AsQueryable();
    }
}