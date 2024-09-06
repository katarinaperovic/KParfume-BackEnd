using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class ParfemRepository : IParfemRepository
    {
        private readonly Context _dbContext;

        public ParfemRepository(Context context)
        {
            _dbContext = context;
        }

        public Parfem Create(Parfem parfem)
        {
            _dbContext.Parfem.Add(parfem);
            _dbContext.SaveChanges();
            return parfem;
        }

        public Parfem Get(long id)
        {
            return _dbContext.Parfem.Find(id);
        }

        public List<Parfem> GetAll()
        {
            return _dbContext.Parfem.ToList();
        }

        public void Remove(Parfem parfem)
        {
            _dbContext.Parfem.Remove(parfem);
            _dbContext.SaveChanges();
        }
                
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
