using Students.Data.Interfaces;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public class StudentRepository : IRepository<int>
    {
        public int Create(Model<int> model)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Model<int> model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Model<int> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
