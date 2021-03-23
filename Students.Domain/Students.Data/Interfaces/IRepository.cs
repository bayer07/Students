using Students.Domain.Interfaces;

namespace Students.Data.Interfaces
{
    public interface IRepository<TKey>
    {
        TKey Create(IModel<TKey> model);
        void Update(IModel<TKey> model);
        void Delete(TKey id);
        IModel<TKey> GetById(TKey id);
    }
}