using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public class TeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher>  teacherRepository)
        {
             _teacherRepository = teacherRepository;
        } 

        public async Task<Teacher> GetByIdAsync(int id) => await _teacherRepository.GetById(id);

        public async Task<IReadOnlyCollection<Teacher>> GetAll() => await _teacherRepository.GetAll();

        public async Task Add(string firstName, string lastName, List<string> subjects)
        {
            var random = new Random();
            var student = new Teacher(random.Next(1, int.MaxValue), firstName, lastName, subjects);
            await _teacherRepository.Add(student);
        }

        public async Task Remove(int id) => await _teacherRepository.Remove(id);

        public async Task Update(int id, Teacher teacher) => await _teacherRepository.Update(id, teacher);
        
    }
}