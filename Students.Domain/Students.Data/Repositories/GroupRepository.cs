using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public override Task<List<Group>> GetAll() => 
            ctx.Groups.Include(x => x.GroupStudents).ToListAsync();

        public override Task<Group> GetById(int id) =>
            ctx.Groups.Include(x => x.GroupStudents).SingleOrDefaultAsync(x => x.Id == id);

        public override IQueryable<Group> AsQueryable() =>
            ctx.Groups.Include(x => x.GroupStudents);
    }
}