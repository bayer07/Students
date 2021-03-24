using Students.Domain.Models;

namespace Students.Data.Interfaces
{
    public interface IRepository<T>
    {
        int Create(Model<T> model);
        void Update(Model<T> model);
        void Delete(T id);
        Model<T> GetById(T id);
    }
}