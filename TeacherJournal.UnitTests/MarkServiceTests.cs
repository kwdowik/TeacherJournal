using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace TeacherJournal.UnitTests
{
    public class MarkServiceTests
    {
        [Fact]
        public async Task Create_WhenMarkWasCreated_NewMarkIsInRepository()
        {
            // Arrange
            var fakeMarkRepository = new FakeRepository<Mark>();
            var markService = new MarkService(fakeMarkRepository);
            var expectedMark = new Mark { SubjectID = 123, StudentID = 1234 }; 
            
            // Act
            await markService.Create(expectedMark.StudentID, expectedMark.SubjectID);
            var allMarks = await markService.GetAll();    
            var mark = allMarks.FirstOrDefault();        

            // Assert
            Assert.Equal(1, allMarks.Count);
            Assert.Equal(mark.SubjectID, expectedMark.SubjectID);
            Assert.Equal(mark.StudentID, expectedMark.StudentID);
        }

        [Fact]
        public async Task Create_WhenThreeMarksWereCreated_ThreeNewMarksAreInRepository()
        {
            // Arrange
            var fakeMarkRepository = new FakeRepository<Mark>();
            var markService = new MarkService(fakeMarkRepository);
            List<Mark> marks = new List<Mark> {
                new Mark { SubjectID = 1, StudentID = 4 },
                new Mark { SubjectID = 2, StudentID = 5 },
                new Mark { SubjectID = 3, StudentID = 6 }
            };
            
            // Act
            foreach (var mark in marks)
            {
                await markService.Create(mark.StudentID, mark.SubjectID);
            }
            var allMarks = await markService.GetAll();

            // Assert
            Assert.Equal(3, allMarks.Count);
        }

        [Fact]
        public async Task Remove_WhenMarkRemoved_OneMarkLessInRepository()
        {
            // Arrange
            var firstMark = new Mark { ID = 123 ,SubjectID = 321, StudentID = 321 };
            var secondMark = new Mark { ID = 321 ,SubjectID = 322, StudentID = 322 };            
            var fakeStudentRepository = new FakeRepository<Mark>();
            await fakeStudentRepository.Add(firstMark);
            await fakeStudentRepository.Add(secondMark);
            var markService = new MarkService(fakeStudentRepository);
            
            // Act
            await markService.Remove(firstMark.ID);
            var allMarks = await markService.GetAll();
            var mark = allMarks.FirstOrDefault();
            
            // Assert
            Assert.Equal(1, allMarks.Count);
            Assert.Same(mark, secondMark);
        }

        [Fact]
        public async Task RemoveGroup_WhenMarkRemoved_OneMarkLessInRepository()
        {
            // Arrange
            var firstMark = new Mark { ID = 123 ,SubjectID = 321, StudentID = 321 };
            var secondMark = new Mark { ID = 321 ,SubjectID = 322, StudentID = 322 };   
            var fakeStudentRepository = new FakeRepository<Mark>();
            await fakeStudentRepository.Add(firstMark);
            await fakeStudentRepository.Add(secondMark);
            var markService = new MarkService(fakeStudentRepository);
            
            // Act
            await markService.RemoveGroup(new List<Mark>{firstMark, secondMark});
            var allMarks = await markService.GetAll();
            
            // Assert
            Assert.Equal(0, allMarks.Count);
        }

        [Fact]
        public async Task GetAll_ReturnsAllMarksFromRepository()
        {
            // Arrange
            var firstMark = new Mark { ID = 123 ,SubjectID = 321, StudentID = 321 };
            var secondMark = new Mark { ID = 321 ,SubjectID = 322, StudentID = 322 };   
            var fakeStudentRepository = new FakeRepository<Mark>();
            await fakeStudentRepository.Add(firstMark);
            await fakeStudentRepository.Add(secondMark);
            var markService = new MarkService(fakeStudentRepository);
            
            // Act
            var allMarks = await markService.GetAll();
            var mark = allMarks.FirstOrDefault(m => m.ID == 123);
            
            // Assert
            Assert.Equal(2, allMarks.Count);
            Assert.Same(firstMark, mark);
        }


    }
}