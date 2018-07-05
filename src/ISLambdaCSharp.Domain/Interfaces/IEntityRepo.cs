using System;
using System.Collections.Generic;
using System.Text;

namespace ISLambdaCSharp.Domain.Interfaces
{
    public interface IEntityRepo<T>
    {
        List<T> GetAll();
        T GetByName(string name);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);

        void UpdateEntity(T entity);
    }
}
