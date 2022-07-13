﻿namespace LoanApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        void SaveChanges();
    }
}
