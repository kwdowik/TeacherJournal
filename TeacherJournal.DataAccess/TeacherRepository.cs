using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherJournal.BusinessLogic;

namespace TeacherJournal.DataAccess
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly JournalDbContext _journalDbContext;

        public TeacherRepository(JournalDbContext journalDbContext)
        {
            _journalDbContext = journalDbContext;
        }

        public Task Add(Teacher item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Teacher>> GetAllAsync() => await _journalDbContext.Teachers.ToListAsync();

        public Task<Teacher> GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Teacher item)
        {
            throw new System.NotImplementedException();
        }
    }
}