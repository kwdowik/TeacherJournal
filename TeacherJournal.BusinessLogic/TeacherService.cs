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

        public async Task<IReadOnlyCollection<Teacher>> GetAll() => await _teacherRepository.GetAllAsync();

        public async Task Create(string login, string password, List<string> subjects)
        {
            var random = new Random();
            var teacher = new Teacher(random.Next(1, int.MaxValue), login, password, subjects);
            await _teacherRepository.Add(teacher);
        }

        public async Task Remove(int id) => await _teacherRepository.Remove(id);

        public async Task Update(Teacher teacher) => await _teacherRepository.Update(teacher);
        
    }
}