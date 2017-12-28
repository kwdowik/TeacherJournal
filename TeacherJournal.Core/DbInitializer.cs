using System.Collections.Generic;
using System.Linq;
using TeacherJournal.BusinessLogic;
using TeacherJournal.DataAccess;

namespace TeacherJournal.Core
{
    public static class DbInitializer
    {
         public static void Initialize(JournalDbContext context)//SchoolContext is EF context
        {
           
            context.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing .

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var subjects = new List<Subject>();
            subjects.Add(new Subject(1, "Math", new List<Mark>{ new Mark(4, 3), new Mark(1, 4)}));
            var student1 = new Student(1, "Jan", "Kowlaski", subjects);
            subjects = new List<Subject>();
            subjects.Add(new Subject(2, "English", new List<Mark>{ new Mark(5, 3), new Mark(2, 3)}));
            var student2 = new Student(2, "Jakub", "Wede", subjects);
            subjects = new List<Subject>();
            subjects.Add(new Subject(3, "PE", new List<Mark>{ new Mark(6, 3), new Mark(3, 3)}));
            var student3 = new Student(3, "Olaf", "Wat", subjects);
            var students = new Student[]
            {
                student1, 
                student2, 
                student3
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}