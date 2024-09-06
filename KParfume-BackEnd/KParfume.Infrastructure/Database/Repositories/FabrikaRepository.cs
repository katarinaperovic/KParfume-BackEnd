using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class FabrikaRepository : IFabrikaRepository
    {
        private readonly Context _dbContext;
        public FabrikaRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Fabrika Create(Fabrika fabrika)
        {
            _dbContext.Fabrika.Add(fabrika);
            _dbContext.SaveChanges();
            return fabrika;
        }

        public Fabrika Get(long id)
        {
            return _dbContext.Fabrika.Find(id);
        }

        public List<Fabrika> GetAll()
        {
            return _dbContext.Fabrika.ToList();
        }

        public void Remove(Fabrika fabrika)
        {
            _dbContext.Fabrika.Remove(fabrika);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public bool Exists(long id)
        {
            return _dbContext.Fabrika.Any(fabrika => fabrika.Id == id);
        }

    }
}
