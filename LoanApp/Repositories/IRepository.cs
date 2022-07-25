using System.Linq.Expressions;

namespace LoanApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetRangeByCondition(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        Task<T> SaveChanges();
    }
}
