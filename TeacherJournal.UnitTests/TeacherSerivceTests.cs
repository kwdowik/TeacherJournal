using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using System.Collections.Generic;

namespace TeacherJournal.UnitTests
{
    public class TeacherSerivceTests
    {
        private readonly FakeRepository<Teacher> _fakeTeacherRepository;
        public TeacherSerivceTests()
        {
            _fakeTeacherRepository = new FakeRepository<Teacher>();
            _fakeTeacherRepository.Add(new Teacher{
                ID = 123,
                Login = "Correct",
                Password = "Correct"
            });
            _fakeTeacherRepository.Add(new Teacher{
                ID = 321,
                Login = "Test2",
                Password = "Test2"
            });
        }
        [Fact]
        public async Task IsAuthenticated_IfTeacherEnterValidDataItIsAuthenticate()
        {
            // Arrange 
            var teacherService = new TeacherService(_fakeTeacherRepository);

            // Act
            var isAuthenticated = await teacherService.IsAuthenticated("Correct", "Correct");

            // Assert
            Assert.True(isAuthenticated);
        }

        [Fact]
        public async Task IsAuthenticated_IfTeacherEnterInvalidDataItIsNotAuthenticate()
        {
            // Arrange 
            var teacherService = new TeacherService(_fakeTeacherRepository);

            // Act
            var isAuthenticated = await teacherService.IsAuthenticated("Wrong", "Wrong");

            // Assert
            Assert.False(isAuthenticated);
        }

        [Fact]
        public async Task GetAll_ReturnsAllTeachersFromRepository()
        {
            // Arragne
            var teacherService = new TeacherService(_fakeTeacherRepository);

            // Act
            var allTeachers = await teacherService.GetAll();

            // Assert
            Assert.Equal(2, allTeachers.Count);
        }
    }
}