using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class VestRepository : IVestRepository
    {
        private readonly Context _dbContext;

        public VestRepository(Context context)
        {
            _dbContext = context;
        }

        public Vest Create(Vest vest)
        {
            _dbContext.Vest.Add(vest);
            _dbContext.SaveChanges();
            return vest;
        }

        public Vest Get(long id)
        {
            return _dbContext.Vest.Find(id);
        }

        public void Remove(Vest vest)
        {
            _dbContext.Vest.Remove(vest);
            _dbContext.SaveChanges();
        }

        public List<Vest> GetAll()
        {
            return _dbContext.Vest.ToList();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
