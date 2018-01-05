using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace TeacherJournal.DataAccess
{
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly JournalDbContext _journalDbContext;

        public SubjectRepository(JournalDbContext journalDbContext)
        {
            _journalDbContext = journalDbContext;
        }
        public async Task Add(Subject item)
        {
            _journalDbContext.Subjects.Add(item);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Subject>> GetAllAsync()
        {
            return await _journalDbContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetById(int? id)
        {
            if(id == null)
                return null;
                
            return await _journalDbContext.Subjects
                .Include(s => s.Marks)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SubjectID == id);
        }

        public async Task Remove(int id)
        {
            var subject = await GetById(id);
            _journalDbContext.Subjects.Remove(subject);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task Update(Subject item)
        {
            _journalDbContext.Subjects.Update(item);
            await _journalDbContext.SaveChangesAsync();
        }
    }
}