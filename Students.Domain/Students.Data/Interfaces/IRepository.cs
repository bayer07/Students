using Students.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : Model<int>
    {
        void Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        Task<TModel> GetById(int id);
        Task<List<TModel>> GetAll();
    }
}