using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;
using KParfume.API.DTOs;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class OcenaRepository : IOcenaRepository
    {
        private readonly Context _dbContext;

        public OcenaRepository(Context context)
        {
            _dbContext = context;
        }

        public Ocena Create(Ocena o)
        {
            _dbContext.Ocena.Add(o);
            _dbContext.SaveChanges();
            return o;
        }

        
        public List<Ocena> GetAll()
        {
            return _dbContext.Ocena.ToList();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
