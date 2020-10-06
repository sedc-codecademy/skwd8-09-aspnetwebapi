using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T update);
    }
}
