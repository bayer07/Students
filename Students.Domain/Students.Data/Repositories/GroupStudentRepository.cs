using System.Collections.Generic;
using System.Threading.Tasks;
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

        protected override DbSet<GroupStudent> DbSet { get; }

        public override Task<List<GroupStudent>> GetAll() => 
            ctx.GroupStudents.Include(x => x.Student).Include(x => x.Group).ToListAsync();

        public override Task<GroupStudent> GetById(int id) =>
            ctx.GroupStudents.Include(x => x.Student).Include(x => x.Group).SingleOrDefaultAsync(x => x.Id == id);
    }
}