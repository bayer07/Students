using Students.Data.Interfaces;
using Students.Domain.Interfaces;

namespace Students.Data.Repositories
{
    public class StudentRepository : IRepository<int>
    {
        public int Create(IModel<int> model)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IModel<int> model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IModel<int> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
