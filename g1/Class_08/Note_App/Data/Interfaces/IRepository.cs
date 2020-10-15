using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
