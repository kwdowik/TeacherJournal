﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using TeacherJournal.DataAccess;

namespace TeacherJournal.DataAccess.Migrations
{
    [DbContext(typeof(JournalDbContext))]
    partial class JournalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("TeacherJournal.BusinessLogic.Mark", b =>
                {
                    b.Property<int>("MarkID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.Property<int>("SubjectID");

                    b.HasKey("MarkID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("TeacherJournal.BusinessLogic.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TeacherJournal.BusinessLogic.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("TeacherJournal.BusinessLogic.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TeacherJournal.BusinessLogic.Mark", b =>
                {
                    b.HasOne("TeacherJournal.BusinessLogic.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TeacherJournal.BusinessLogic.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
