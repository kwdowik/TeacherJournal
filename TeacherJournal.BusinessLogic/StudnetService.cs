using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public class StudnetService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudnetService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        } 

        public async Task<Student> GetByIdAsync(int id) => await _studentRepository.GetById(id);

        public async Task<IReadOnlyCollection<Student>> GetAll() => await _studentRepository.GetAll();

        public async Task Add(string firstName, string lastName, Dictionary<string, List<int>> subjects)
        {
            var random = new Random();
            var student = new Student(random.Next(1, int.MaxValue), firstName, lastName, subjects);
            await _studentRepository.Add(student);
        }

        public async Task Remove(int id) => await _studentRepository.Remove(id);

        public async Task Update(int id, Student student) => await _studentRepository.Update(id, student);

        
    }
}