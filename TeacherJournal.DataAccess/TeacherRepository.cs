using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace TeacherJournal.DataAccess
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly JournalDbContext _journalDbContext;

        public TeacherRepository(JournalDbContext journalDbContext)
        {
            _journalDbContext = journalDbContext;
        }
        public async Task Add(Teacher item)
        {
            _journalDbContext.Teachers.Add(item);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Teacher>> GetAllAsync()
        {
            return await _journalDbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _journalDbContext.Teachers.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var teacher = await GetById(id);
            _journalDbContext.Teachers.Remove(teacher);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task Update(Teacher item)
        {
            _journalDbContext.Teachers.Update(item);
            await _journalDbContext.SaveChangesAsync();
        }
    }
}