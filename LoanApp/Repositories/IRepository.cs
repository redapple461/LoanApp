namespace LoanApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);

        void SaveChanges();
    }
}
