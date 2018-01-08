using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public class MarkService
    {
        private readonly IRepository<Mark> _markRepository;

        public MarkService(IRepository<Mark> markRepository)
        {
            _markRepository = markRepository;
        }

        public async Task<IReadOnlyCollection<Mark>> GetAll() => await _markRepository.GetAllAsync();

        public async Task Create(int? studentID, int? subjectID, int? grade = null)
        {
            if(studentID == null || subjectID == null)
                return;
            var random = new Random();
            
            var mark = grade == null 
                ? new Mark{ MarkID = random.Next(1, int.MaxValue), StudentID = studentID.Value, SubjectID = subjectID.Value } 
                : new Mark{ MarkID = random.Next(1, int.MaxValue), StudentID = studentID.Value, SubjectID = subjectID.Value, Grade = grade.Value };
            await _markRepository.Add(mark);
        }
        
        public async Task Remove(int id) => await _markRepository.Remove(id);

        public async Task RemoveGroup(List<Mark> marks)
        {
            foreach(var mark in marks)
            {
                await Remove(mark.MarkID);
            }
        }
    }
}