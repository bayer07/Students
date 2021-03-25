using Microsoft.EntityFrameworkCore;
using Students.Domain.Models;

namespace Students.Data.Repositories
{
    public class GroupRepository : BaseRepository<Group>
    {
        public GroupRepository(StudentsContext ctx) : base(ctx)
        {
            DbSet = ctx.Groups;
        }

        protected override DbSet<Group> DbSet { get; }

        public override void Include()
        {
            ctx.Groups.Include(x => x.GroupStudents);
        }
    }
}