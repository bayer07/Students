using Microsoft.EntityFrameworkCore;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public class GroupStudentRepository : BaseRepository<GroupStudent>
    {
        public GroupStudentRepository(StudentsContext ctx) : base(ctx)
        {
            DbSet = ctx.GroupStudents;
        }

        public override void Include()
        {
            ctx.GroupStudents.Include(x => x.Group).Include(x => x.Student);
        }

        protected override DbSet<GroupStudent> DbSet { get; }
    }
}