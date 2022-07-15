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

        public void Add(Loan entity)
        {
            db.Loans.Add(entity);
        }

        public void AddRange(IEnumerable<Loan> entities)
        {
            db.Loans.AddRange(entities);
        }

        public IEnumerable<Loan> GetAll()
        {
            return db.Loans.ToList<Loan>();
        }

        public async Task<Loan> GetById(int id)
        {
            return db.Loans.FirstOrDefault<Loan>(x => x.UserId == id);
        }

        public void Remove(Loan entity)
        {
            db.Loans.Remove(entity);
        }

        public async void SaveChanges()
        {
            await db.SaveChangesAsync();
        }


        public async Task<Loan> GetByCondition(Expression<Func<Loan, bool>> expression)
        {
            return db.Loans.FirstOrDefault(expression);
        }
    }
}
