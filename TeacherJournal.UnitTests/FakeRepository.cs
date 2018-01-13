using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherJournal.BusinessLogic;

namespace TeacherJournal.UnitTests
{
    public class FakeRepository<T> : IRepository<T> where T : IModelObject
    {
        private Dictionary<int, T> _items;

        public FakeRepository()
        {
            if(_items == null)
                _items = new Dictionary<int, T>();
        }
        public Task Add(T item)
        {
            var task = new Task(() => _items.Add(item.ID, item));
            task.Start();
            return task;
        }

        public Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            var items = _items.Values as IReadOnlyCollection<T>;
            var task = new Task<IReadOnlyCollection<T>>(() => items);
            task.Start();
            return task;
        }

        public Task<T> GetById(int? id)
        {
            T item;
            _items.TryGetValue(id.Value, out item);
            var task = new Task<T>(() => item);
            task.Start();
            return task;
        }

        public Task Remove(int id)
        {
            var task = new Task(() => _items.Remove(id));
            task.Start();
            return task;
        }

        public Task Update(T item)
        {
            var task = new Task(() => _items[item.ID] = item);
            task.Start();
            return task;
        }
    }
}