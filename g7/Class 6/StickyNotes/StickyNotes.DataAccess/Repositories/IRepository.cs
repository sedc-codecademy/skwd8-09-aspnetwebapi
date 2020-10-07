using System.Collections.Generic;

namespace StickyNotes.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
