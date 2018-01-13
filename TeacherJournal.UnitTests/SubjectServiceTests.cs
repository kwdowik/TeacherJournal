using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using System.Collections.Generic;

namespace TeacherJournal.UnitTests
{
    public class SubjectServiceTests
    {
        [Fact]
        public async Task Create_WhenSubjectWasCreated_NewSubjectIsInRepository()
        {
            // Arrange
            var fakeSubjectRepository = new FakeRepository<Subject>();
            var subjectService = new SubjectService(fakeSubjectRepository);
            var subject = new Subject { Name= "Math" };

            // Act
            var id = await subjectService.Create(subject.Name);
            var allSubjects = await subjectService.GetAll();

            // Assert
            Assert.True(id > 0);
            Assert.Equal(1, allSubjects.Count);
        }

        [Fact]
        public async Task Create_WhenThreeSubjectsWereCreated_NewThreeSubjectsAreInRepository()
        {
            // Arrange
            var fakeSubjectRepository = new FakeRepository<Subject>();
            var subjectService = new SubjectService(fakeSubjectRepository);
            List<Subject> subjects = new List<Subject>() {
                new Subject { Name = "Math"},
                new Subject { Name = "Chemistry"},
                new Subject { Name =  "PE"}
            };
            
            // Act
            foreach (var subject in subjects)
            {
                await subjectService.Create(subject.Name);
            }
            var allSubjects = await subjectService.GetAll();

            // Assert
            Assert.Equal(3, allSubjects.Count);
        }

        [Fact]
        public async Task GetByIdAsync_FindSubjectInRepository()
        {
            // Arrange
            var fakeSubjectRepository = new FakeRepository<Subject>();
            var subjectService = new SubjectService(fakeSubjectRepository);
            var expectedSubjectName = "Math";
            List<Subject> subjects = new List<Subject>() {
                new Subject { Name = "Math"},
                new Subject { Name = "Chemistry"},
                new Subject { Name =  "PE"}
            };
            
            // Act
            foreach (var subject in subjects)
            {
                await subjectService.Create(subject.Name);
            }
            var result  = await subjectService.GetByNameAsync(expectedSubjectName);

            // Assert
            Assert.True(result.ID > 0);            
            Assert.Equal(expectedSubjectName, result.Name);
        }
    }
}