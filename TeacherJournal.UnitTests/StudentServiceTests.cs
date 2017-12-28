using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using System.Collections.Generic;

namespace TeacherJournal.Tests
{
    public class StudentServiceTests
    {
        [Fact]
        public async Task WhenStudnetIsAdded_IdIsAssigned()
        {
            // Arrange
            var repoMock = new Mock<IRepository<Student>>();
            var studentService = new StudentService(repoMock.Object);
            var subjects = new List<Subject>();
            subjects.Add(new Subject(123, "Math", new List<Mark>{ new Mark(123, 3), new Mark(1234, 5)}));
            
            // Act
            await studentService.Create("Jan", "Kowalski", subjects);

            // Assert
            repoMock.Verify(r => r.Add(It.Is<Student>(s => s.Id > 0)),Times.Once);
        }

        [Theory]
        [InlineData(3, 4, 3, 3.33)]
        [InlineData(5, 5, 5, 5)]
        [InlineData(2, 4, 2, 2.67)]
        [InlineData(2, 4, 5, 3.67)]        
        public void WhenStudnetHasMarks_AvarageIsCalculated(int mark1, int mark2, int mark3, double expectedAvarage)
        {
            // Arrange
            var repoMock = new Mock<IRepository<Student>>();
            var studentService = new StudentService(repoMock.Object);
            var marks = new List<int>{mark1, mark2, mark3};
            
            // Act
            var avarage = studentService.CalculateMarksAvarage(marks);            

            // Assert
            Assert.Equal(expectedAvarage, avarage, 2);
        }

        [Fact]
        public async Task WhenTeacherAddMarkToStudent_StudentHasNewMark()
        {
             // Arrange
            var repoMock = new Mock<IRepository<Student>>();
            var studentService = new StudentService(repoMock.Object);
            var subjects = new List<Subject>();
            subjects.Add(new Subject(123, "Math", new List<Mark>{ new Mark(123, 3), new Mark(1234, 5)}));
            var student = new Student(123123, "Jan", "Kowlaski", subjects);
            await repoMock.Object.Add(student);
            
            // Act
            studentService.AddMark(student, "Math", 4);

            // Assert
            Assert.Equal(3, student.Subjects.Find(s => s.Name == "Math").Marks.Count);
        }

        [Fact]
        public async Task WhenTeacherRemoveMarkFromStudent_StudentHasOneMarkLess()
        {
             // Arrange
            var repoMock = new Mock<IRepository<Student>>();
            var studentService = new StudentService(repoMock.Object);
             var subjects = new List<Subject>();
            subjects.Add(new Subject(123, "Math", new List<Mark>{ new Mark(123, 3), new Mark(1234, 5)}));
            var student = new Student(123123, "Jan", "Kowlaski", subjects);
            await repoMock.Object.Add(student);
            
            // Act
            studentService.RemoveMark(student, "Math", 1);

            // Assert
            Assert.Equal(1, student.Subjects.Find(s => s.Name == "Math").Marks.Count);
        }
        
    }
}
