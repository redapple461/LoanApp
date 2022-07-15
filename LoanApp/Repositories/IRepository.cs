using System.Linq.Expressions;

namespace LoanApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        void SaveChanges();
    }
}
