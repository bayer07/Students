﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Students.Data;

namespace Students.Data.Migrations
{
    [DbContext(typeof(StudentsContext))]
    [Migration("20210326132846_addStudent4")]
    partial class addStudent4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Students.Domain.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Developers"
                        },
                        new
                        {
                            Id = 2,
                            Name = "QA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "RnD"
                        });
                });

            modelBuilder.Entity("Students.Domain.Models.GroupStudent", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id", "GroupId", "StudentId");

                    b.HasIndex("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("GroupStudents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupId = 1,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            GroupId = 2,
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("Students.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("UniqIdentity")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("UniqIdentity")
                        .IsUnique();

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Bair",
                            Gender = 1,
                            LastName = "Dongak",
                            Patronymic = "Orlanovich",
                            UniqIdentity = "bayer07"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Roman",
                            Gender = 1,
                            LastName = "X"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Some",
                            Gender = 2,
                            LastName = "Girl"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Student",
                            Gender = 2,
                            LastName = "4"
                        });
                });

            modelBuilder.Entity("Students.Domain.Models.GroupStudent", b =>
                {
                    b.HasOne("Students.Domain.Models.Group", "Group")
                        .WithMany("GroupStudents")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Students.Domain.Models.Student", "Student")
                        .WithMany("GroupStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Students.Domain.Models.Group", b =>
                {
                    b.Navigation("GroupStudents");
                });

            modelBuilder.Entity("Students.Domain.Models.Student", b =>
                {
                    b.Navigation("GroupStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
