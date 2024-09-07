using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;
using KParfume.API.DTOs;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class KuponRepository : IKuponRepository
    {
        private readonly Context _dbContext;

        public KuponRepository(Context context)
        {
            _dbContext = context;
        }

        public Kupon Create(Kupon k)
        {
            _dbContext.Kupon.Add(k);
            _dbContext.SaveChanges();
            return k;
        }

        public Kupon Get(long id)
        {
            return _dbContext.Kupon.Find(id);
        }

        public void Remove(Kupon k)
        {
            _dbContext.Kupon.Remove(k);
            _dbContext.SaveChanges();
        }

        public List<Kupon> GetAll()
        {
            return _dbContext.Kupon.ToList();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
