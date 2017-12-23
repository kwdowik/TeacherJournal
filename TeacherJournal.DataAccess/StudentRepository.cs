using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherJournal.BusinessLogic;

namespace TeacherJournal.DataAccess
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly JournalDbContext _journalDbContext;
        public StudentRepository(JournalDbContext journalDbContext)
        {
            _journalDbContext = journalDbContext;
        }
        public async Task Add(Student item)
        {
            _journalDbContext.Students.Add(item);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Student>> GetAllAsync()
        {
            return await _journalDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _journalDbContext.Students.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var student = await GetById(id);
            _journalDbContext.Students.Remove(student);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task Update(Student item)
        {
            _journalDbContext.Students.Update(item);
            await _journalDbContext.SaveChangesAsync();
        }
    }
}