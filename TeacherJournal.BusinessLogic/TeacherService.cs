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

        public async Task<Teacher> GetByLoginAsync(string teacherLogin)
        {
            var teachers = await GetAll();
            return teachers.Where(s => s.Login == teacherLogin).FirstOrDefault();
        }

         public async Task<IReadOnlyCollection<Teacher>> GetAll() => await _teacherRepository.GetAllAsync();

    }
}