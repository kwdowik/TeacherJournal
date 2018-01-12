using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public class TeacherService
    {   
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<bool> IsAuthenticated(string login, string password)
        {
            var teachers = await GetAll();
            return teachers.Where(t => t.Login == login && t.Password == password)
                .FirstOrDefault() != null;
        }

         public async Task<IReadOnlyCollection<Teacher>> GetAll() => await _teacherRepository.GetAllAsync();

    }
}