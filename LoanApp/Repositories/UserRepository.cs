using LoanApp.Models;
using System.Linq.Expressions;

namespace LoanApp.Repositories
{
    public class UserRepository : IRepository<User>
    {
        ApplicationContext db;

        public UserRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task<User> Add(User entity)
        {
            db.Users.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void AddRange(IEnumerable<User> entities)
        {
            db.Users.AddRange(entities);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList<User>();
        }

        public async Task<User> GetById(int id)
        {
            return db.Users.FirstOrDefault<User>(x => x.UserId == id);
        }

        public void Remove(User entity)
        {
            db.Users.Remove(entity);
        }

        public async Task<User> SaveChanges()
        {
            await db.SaveChangesAsync();
            //TODO: move hardcode
            return new User();
        }

        public async Task<User> GetByCondition(Expression<Func<User, bool>> expression)
        {
            return db.Users.FirstOrDefault(expression);
        }

        public async Task<IEnumerable<User>> GetRangeByCondition(Expression<Func<User, bool>> expression)
        {
            return db.Users.Where<User>(expression);
        }
    }
}
