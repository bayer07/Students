using Microsoft.EntityFrameworkCore;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(StudentsContext ctx) : base(ctx)
        {
            DbSet = ctx.Students;
        }

        protected override DbSet<Student> DbSet { get; }
    }
}
