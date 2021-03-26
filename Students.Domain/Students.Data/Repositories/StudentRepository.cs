using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentsContext ctx) : base(ctx)
        {
            DbSet = ctx.Students;
        }

        protected override DbSet<Student> DbSet { get; }

        public override Task<List<Student>> GetAll() =>
            ctx.Students.Include(x => x.GroupStudents).ThenInclude(x => x.Group).ToListAsync();

        public override Task<Student> GetById(int id) =>
            ctx.Students.Include(x => x.GroupStudents).SingleOrDefaultAsync(x => x.Id == id);
    }
}
