using TeacherJournal.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;

namespace TeacherJournal.DataAccess
{
    public class JournalDbContext : DbContext
    {
        public JournalDbContext(DbContextOptions<JournalDbContext> options)
            : base(options)
        {
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var teacherMapping = modelBuilder.Entity<Teacher>();
            
            teacherMapping.HasKey(p => p.Id);
            teacherMapping.Property(p => p.Login).IsRequired();
            teacherMapping.Property(p => p.Password).IsRequired();

            var studentMapping = modelBuilder.Entity<Student>();
            studentMapping.HasKey(p => p.Id);
            studentMapping.Property(p => p.FirstName).IsRequired();
            studentMapping.Property(p => p.LastName).IsRequired();
        }

        public DbSet<Teacher> Teachers {get; set;}
        public DbSet<Student> Students {get; set;}
        
    }
}