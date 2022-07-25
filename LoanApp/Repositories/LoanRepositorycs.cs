using LoanApp.Models;
using System.Linq.Expressions;

namespace LoanApp.Repositories
{
    public class LoanRepository : IRepository<Loan>
    {
        ApplicationContext db;

        public LoanRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task<Loan> Add(Loan entity)
        {
            db.Loans.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void AddRange(IEnumerable<Loan> entities)
        {
            db.Loans.AddRange(entities);
        }

        public IEnumerable<Loan> GetAll()
        {
            return db.Loans.ToList();
        }

        public async Task<Loan> GetById(int id)
        {
            return db.Loans.FirstOrDefault<Loan>(x => x.UserId == id);
        }

        public void Remove(Loan entity)
        {
            db.Loans.Remove(entity);
        }

        public async Task<Loan> SaveChanges()
        {
            await db.SaveChangesAsync();
            return new Loan();
        }


        public async Task<Loan> GetByCondition(Expression<Func<Loan, bool>> expression)
        {
            return db.Loans.FirstOrDefault(expression);
        }

        public async Task<IEnumerable<Loan>> GetRangeByCondition(Expression<Func<Loan, bool>> expression)
        {
            return db.Loans.Where<Loan>(expression);
        }
    }
}
