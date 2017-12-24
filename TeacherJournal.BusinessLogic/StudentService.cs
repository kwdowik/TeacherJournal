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

        public async Task<Student> GetByIdAsync(int id) => await _studentRepository.GetById(id);

        public async Task<IReadOnlyCollection<Student>> GetAll() => await _studentRepository.GetAllAsync();

        public async Task Create(string firstName, string lastName, Dictionary<string, List<int>> subjects)
        {
            var random = new Random();
            var student = new Student(random.Next(1, int.MaxValue), firstName, lastName, subjects);
            await _studentRepository.Add(student);
        }

        public async Task Remove(int id) => await _studentRepository.Remove(id);

        public async Task Update(Student student) => await _studentRepository.Update(student);

        public double CalculateMarksAvarage(List<int> marks) => ((double)marks.Sum() / (double)marks.Count);

        public bool AddMark(Student student, string subject, int mark)
        {
            List<int> marks;
            if(!student.Subjects.TryGetValue(subject, out marks))
                return false;
            marks.Add(mark);
            student.Subjects[subject] = marks;
            return true;
        }

        public bool RemoveMark(Student student, string subject, int markIndex)
        {
            List<int> marks;
            if(!student.Subjects.TryGetValue(subject, out marks))
                return false;
            marks.RemoveAt(markIndex);
            student.Subjects[subject] = marks;
            return true;
        }
    }
}