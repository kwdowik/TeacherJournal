using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TeacherJournal.BusinessLogic
{
    public class SubjectService
    {
        private readonly IRepository<Subject> _subjectService;

        public SubjectService(IRepository<Subject>  subjectService)
        {
             _subjectService = subjectService;
        } 

        public async Task<Subject> GetByNameAsync(string subjectName)
        {
            var subjects = await GetAll();
            return subjects.Where(s => s.Name == subjectName).FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<Subject>> GetAll() => await _subjectService.GetAllAsync();

        public async Task<int> Create(string name)
        {
            if(await GetByNameAsync(name) != null)
                return 0;
            var random = new Random();
            var subject = new Subject{SubjectID = random.Next(1, int.MaxValue), Name = name};
            await _subjectService.Add(subject);
            return subject.SubjectID;
        }
    }
}