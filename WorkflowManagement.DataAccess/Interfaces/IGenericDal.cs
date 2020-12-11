using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Interfaces;

namespace WorkflowManagement.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T: class, ITable, new() 
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();

    }
}
