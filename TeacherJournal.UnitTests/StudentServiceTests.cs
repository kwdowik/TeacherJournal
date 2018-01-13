using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using System.Collections.Generic;

namespace TeacherJournal.UnitTests
{
    public class StudentServiceTests
    {
        [Fact]
        public async Task Create_WhenStudnetWasCreated_NewStudnetIsInRepository()
        {
            // Arrange
            var fakeStudentRepository = new FakeRepository<Student>();
            var studentService = new StudentService(fakeStudentRepository);
            var student = new Student { FirstName = "Jan", LastName = "Kowalski" }; 
            
            // Act
            await studentService.Create(student.FirstName, student.LastName);
            var allStudents = await studentService.GetAll();            

            // Assert
            Assert.Equal(1, allStudents.Count);
        }

        [Fact]
        public async Task Create_WhenThreeStudentsWereCreated_ThreeNewStudentsAreInRepository()
        {
            // Arrange
            var fakeStudentRepository = new FakeRepository<Student>();
            var studentService = new StudentService(fakeStudentRepository);
            List<Student> students = new List<Student> {
                new Student{ FirstName = "Jan", LastName = "Kowalski" },
                new Student { FirstName = "Luke", LastName = "Smith" },
                new Student { FirstName = "Pablo", LastName = "Perry" }
            };
            
            // Act
            foreach (var student in students)
            {
                await studentService.Create(student.FirstName, student.LastName);
            }
            var allStudents = await studentService.GetAll();

            // Assert
            Assert.Equal(3, allStudents.Count);
        }

        [Fact]
        public async Task Remove_WhenStudentRemoved_OneStudentLessInRepository()
        {
            // Arrange
            var firstStudent = new Student { ID = 123 ,FirstName = "Luke", LastName = "Smith" };
            var secondStudent = new Student { ID = 321 ,FirstName = "Pablo", LastName = "Perry" };            
            var fakeStudentRepository = new FakeRepository<Student>();
            await fakeStudentRepository.Add(firstStudent);
            await fakeStudentRepository.Add(secondStudent);
            var studentService = new StudentService(fakeStudentRepository);
            
            // Act
            await studentService.Remove(123);
            var allStudents = await studentService.GetAll();
            
            // Assert
            Assert.Equal(1, allStudents.Count);
        }

        [Fact]
        public async Task GetByIdAsync_FindStudentFromRepository()
        {
            // Arrange
            var expectedStudent = new Student { ID = 123 ,FirstName = "Luke", LastName = "Smith" };
            var fakeStudentRepository = new FakeRepository<Student>();
            await fakeStudentRepository.Add(expectedStudent);
            var studentService = new StudentService(fakeStudentRepository);
            
            // Act
            var student = await studentService.GetByIdAsync(123);
            
            // Assert
            Assert.Same(student, expectedStudent);
        }

        
        
    }
}

