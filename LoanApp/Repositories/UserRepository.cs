using LoanApp.Models;

namespace LoanApp.Repositories
{
    public class UserRepository : IRepository<User>
    {
        ApplicationContext db;

        public UserRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Add(User entity)
        {
            db.Users.Add(entity);
        }

        public void AddRange(IEnumerable<User> entities)
        {
            db.Users.AddRange(entities);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList<User>();
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault<User>(x => x.UserId == id);
        }

        public void Remove(User entity)
        {
            db.Users.Remove(entity);
        }

        public async void SaveChanges()
        {
            await db.SaveChangesAsync();
        }
    }
}
