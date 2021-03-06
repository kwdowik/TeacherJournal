using System.Collections.Generic;
using System.Linq;
using TeacherJournal.BusinessLogic;
using TeacherJournal.DataAccess;

namespace TeacherJournal.Core
{
    public static class DbInitializer
    {
         public static void Initialize(JournalDbContext context)
        {
           
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any() && context.Teachers.Any())
            {
                return;   // DB has been seeded
            }

            var teachers = new Teacher[]
            {
                new Teacher{Login="Luke", Password="password"},
                new Teacher{Login="Andrew", Password="password123"}
            };
            context.Teachers.AddRange(teachers);
            context.SaveChanges();            

           var students = new Student[]
            {
                new Student{FirstName="Carson",LastName="Alexander"},
                new Student{FirstName="Meredith",LastName="Alonso"},
                new Student{FirstName="Arturo",LastName="Anand"},
                new Student{FirstName="Gytis",LastName="Barzdukas"},
                new Student{FirstName="Yan",LastName="Li"},
                new Student{FirstName="Peggy",LastName="Justice"},
                new Student{FirstName="Laura",LastName="Norman"},
                new Student{FirstName="Nino",LastName="Olivetto"}
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject{ID=1050,Name="Chemistry"},
                new Subject{ID=4022,Name="Microeconomics"},
                new Subject{ID=4041,Name="Macroeconomics"},
                new Subject{ID=1045,Name="Calculus"},
                new Subject{ID=3141,Name="Trigonometry"},
                new Subject{ID=2021,Name="Composition"},
                new Subject{ID=2042,Name="Literature"}
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            var marks = new Mark[]
            {
                new Mark{ID=1,SubjectID=1050,Grade=3},
                new Mark{ID=1,SubjectID=4022,Grade=4},
                new Mark{ID=1,SubjectID=4041,Grade=3},
                new Mark{ID=2,SubjectID=1045,Grade=4},
                new Mark{ID=2,SubjectID=3141,Grade=4},
                new Mark{ID=2,SubjectID=2021,Grade=3},
                new Mark{ID=3,SubjectID=1050,Grade=2},
                new Mark{ID=4,SubjectID=1050,Grade=5},
                new Mark{ID=4,SubjectID=4022,Grade=5},
                new Mark{ID=5,SubjectID=4041,Grade=5},
                new Mark{ID=6,SubjectID=1045,Grade=6},
                new Mark{ID=7,SubjectID=3141,Grade=4},
            };
            context.Marks.AddRange(marks);
            context.SaveChanges();
        }
    }
}