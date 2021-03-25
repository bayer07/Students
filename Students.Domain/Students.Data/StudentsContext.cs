using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new GroupConfiguration());
            builder.ApplyConfiguration(new GroupStudentConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=students.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupStudent> GroupStudents { get; set; }
    }

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(40)");
            builder.Property(x => x.LastName).HasColumnType("nvarchar(40)");
            builder.Property(x => x.Patronymic).HasColumnType("nvarchar(60)");
            builder.Property(x => x.UniqIdentity).HasColumnType("nvarchar(16)");
            builder.HasIndex(x => x.UniqIdentity).IsUnique();
        }
    }

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(25)");
        }
    }

    public class GroupStudentConfiguration : IEntityTypeConfiguration<GroupStudent>
    {
        public void Configure(EntityTypeBuilder<GroupStudent> builder)
        {
            builder.HasKey(x => new { x.GroupId, x.StudentId });

            builder.HasOne(x => x.Student)
                .WithMany(x => x.GroupStudents)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupStudents)
                .HasForeignKey(x => x.GroupId);
        }
    }
}