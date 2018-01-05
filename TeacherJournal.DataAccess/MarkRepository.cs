using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace TeacherJournal.DataAccess
{
    public class MarkRepository : IRepository<Mark>
    {
        private readonly JournalDbContext _journalDbContext;

        public MarkRepository(JournalDbContext journalDbContext)
        {
            _journalDbContext = journalDbContext;
        }

        public async Task Add(Mark item)
        {
            await _journalDbContext.Marks.AddAsync(item);
            await _journalDbContext.SaveChangesAsync();
        } 

        public async Task<IReadOnlyCollection<Mark>> GetAllAsync() =>  await _journalDbContext.Marks.ToListAsync();

       
        public async Task<Mark> GetById(int? id)
        {
            if(id == null)
                return null;

            return await _journalDbContext.Marks
                .SingleOrDefaultAsync(m => m.MarkID == id);
        }

        public async Task Remove(int id)
        {
            var mark = await GetById(id);
            _journalDbContext.Remove(mark);
            await _journalDbContext.SaveChangesAsync();
        }

        public async Task Update(Mark item)
        {
             _journalDbContext.Marks.Update(item);
            await _journalDbContext.SaveChangesAsync();
        }
    }
}