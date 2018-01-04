using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public class SubjectService
    {
        private readonly IRepository<Subject> _subjectService;

        public SubjectService(IRepository<Subject>  subjectService)
        {
             _subjectService = subjectService;
        } 

        public async Task<Subject> GetByIdAsync(int id) => await _subjectService.GetById(id);

        public async Task<IReadOnlyCollection<Subject>> GetAll() => await _subjectService.GetAllAsync();

        public async Task Create(string name, List<Mark> marks)
        {
            var random = new Random();
            var subject = new Subject{SubjectID = random.Next(1, int.MaxValue), Name = name};
            await _subjectService.Add(subject);
        }

        public async Task Remove(int id) => await _subjectService.Remove(id);

        public async Task Update(Subject subject) => await _subjectService.Update(subject);
        
    }
}