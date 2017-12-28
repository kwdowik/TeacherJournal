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

        public async Task Create(string firstName, string lastName, List<Subject> subjects)
        {
            var random = new Random();
            var student = new Student(random.Next(1, int.MaxValue), firstName, lastName, subjects);
            await _studentRepository.Add(student);
        }

        public async Task Remove(int id) => await _studentRepository.Remove(id);

        public async Task Update(Student student) => await _studentRepository.Update(student);

        public double CalculateMarksAvarage(List<int> marks) => ((double)marks.Sum() / (double)marks.Count);

        public void AddMark(Student student, string subject, int mark)
        {
            var random = new Random();            
            var currSubject =
                student.Subjects.FirstOrDefault(s => s.Name == subject);
            currSubject.Marks.Add(new Mark(random.Next(1, int.MaxValue), mark));
            student.Subjects.Remove(currSubject);
            student.Subjects.Add(currSubject);            
        }

        public void RemoveMark(Student student, string subject, int markId)
        {
           var currSubject =
                student.Subjects.FirstOrDefault(s => s.Name == subject);
            var markToRemove = currSubject.Marks.FirstOrDefault(m => m.Id == markId);
            currSubject.Marks.Remove(markToRemove);
            student.Subjects.Remove(currSubject);
            student.Subjects.Add(currSubject);   
        }
    }
}