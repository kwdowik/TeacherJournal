using TeacherJournal.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace TeacherJournal.DataAccess
{

    public class JournalDbContextFactory : IDesignTimeDbContextFactory<JournalDbContext>
    {
        public JournalDbContext CreateDbContext(string[] args)
        {
             var optionsBuilder = new DbContextOptionsBuilder<JournalDbContext>();
            optionsBuilder.UseSqlite("Data Source=journal.db");

            return new JournalDbContext(optionsBuilder.Options);
        }
    }
    public class JournalDbContext : DbContext
    {
        public JournalDbContext(DbContextOptions<JournalDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var teacherMapping = modelBuilder.Entity<Teacher>();
            teacherMapping.HasKey(p => p.TeacherId);
            teacherMapping.Property(p => p.Login).IsRequired();
            teacherMapping.Property(p => p.Password).IsRequired();

            var studentMapping = modelBuilder.Entity<Student>();
            studentMapping.HasKey(p => p.ID);
            studentMapping.Property(p => p.FirstName).IsRequired();
            studentMapping.Property(p => p.LastName).IsRequired();

            var subjectMapping = modelBuilder.Entity<Subject>();
            subjectMapping.HasKey(s => s.SubjectID);
            subjectMapping.Property(s => s.Name).IsRequired();
            
            var markMapping = modelBuilder.Entity<Mark>();
            markMapping.HasKey(s => s.MarkID);
           
        }

        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Subject> Subjects {get; set;}
        public DbSet<Mark> Marks {get; set;}
        
        
    }
}