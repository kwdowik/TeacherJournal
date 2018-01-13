using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public class StudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        } 

        public async Task<Student> GetByIdAsync(int? id) => await _studentRepository.GetById(id);

        public async Task<IReadOnlyCollection<Student>> GetAll() => await _studentRepository.GetAllAsync();

        public async Task Create(string firstName, string lastName)
        {
            var random = new Random();
            var student = new Student{ID = random.Next(1, int.MaxValue), FirstName = firstName, LastName = lastName};
            await _studentRepository.Add(student);
        }

        public async Task Remove(int id) => await _studentRepository.Remove(id);

    }
}