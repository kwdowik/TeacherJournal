using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeacherJournal.BusinessLogic
{
    public interface IRepository<T>
    {
         Task<T> GetById(int? id);
         Task<IReadOnlyCollection<T>> GetAllAsync();
         Task Add(T item);
         Task Remove(int id);
         Task Update(T item);          
    }
}