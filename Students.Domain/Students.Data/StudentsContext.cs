using System.Linq;
using Microsoft.EntityFrameworkCore;
using Students.Domain.Models;

namespace Students.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(
                new Student { Id = 0, FirstName = "Bair", LastName = "Dongak" });

            builder.Entity<Group>().ToTable("Groups");
            builder.Entity<Student>().ToTable("Students")
                .HasIndex(u => u.UniqIdentity)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=students.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}