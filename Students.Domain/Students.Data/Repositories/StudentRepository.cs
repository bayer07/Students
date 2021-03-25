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

        public override void Include()
        {
            ctx.Students.Include(x => x.GroupStudents);
        }

        protected override DbSet<Student> DbSet { get; }
    }
}
