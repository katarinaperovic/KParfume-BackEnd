using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _dbContext;
         public UserRepository(Context dbContext) {
            _dbContext = dbContext;
        }

        public User GetById(long id)
        {
            User user = _dbContext.Korisnik.FirstOrDefault(user => user.Id == id);
            if (user == null) throw new KeyNotFoundException("Not found.");
            return user;
        }

        public List<User> GetAll()
        {
            return _dbContext.Korisnik.ToList();
        }
        public User? GetActiveByName(string username)
        {
            return _dbContext.Korisnik.FirstOrDefault(user => user.kor_email == username );
        }

        public bool Exists(string username)
        {
            return _dbContext.Korisnik.Any(user => user.kor_email == username);
        }
        public User Get(long id)
        {
            return _dbContext.Korisnik.Find(id);
        }
        public User Create(User user)
        {
            _dbContext.Korisnik.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
