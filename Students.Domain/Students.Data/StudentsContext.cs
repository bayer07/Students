using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.Enums;
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
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new GroupConfiguration());
            builder.ApplyConfiguration(new GroupStudentConfiguration());

            builder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FirstName = "Bair",
                LastName = "Dongak",
                Gender = Gender.Male,
                UniqIdentity = "bayer07",
                Patronymic = "Orlanovich"
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 2,
                FirstName = "Roman",
                LastName = "X",
                Gender = Gender.Male,
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 3,
                FirstName = "Some",
                LastName = "Girl",
                Gender = Gender.Female,
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 4,
                FirstName = "Student",
                LastName = "4",
                Gender = Gender.Female,
            });

            builder.Entity<Group>().HasData(new Group
            {
                Id = 1,
                Name = "Developers"
            });
            builder.Entity<Group>().HasData(new Group
            {
                Id = 2,
                Name = "QA"
            });
            builder.Entity<Group>().HasData(new Group
            {
                Id = 3,
                Name = "RnD"
            });

            builder.Entity<GroupStudent>().HasData(new GroupStudent
            {
                Id = 1,
                GroupId = 1,
                StudentId = 1
            });
            builder.Entity<GroupStudent>().HasData(new GroupStudent
            {
                Id = 2,
                GroupId = 2,
                StudentId = 1
            });
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
            builder.HasKey(x => new { x.Id, x.GroupId, x.StudentId });

            builder.HasOne(x => x.Student)
                .WithMany(x => x.GroupStudents)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupStudents)
                .HasForeignKey(x => x.GroupId);
        }
    }
}