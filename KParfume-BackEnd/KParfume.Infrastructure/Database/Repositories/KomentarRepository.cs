using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class KomentarRepository : IKomentarRepository
    {
        private readonly Context _dbContext;
        public KomentarRepository(Context context) 
        {
            _dbContext = context;
        }

        public Komentar Create(Komentar komentar)
        {
            _dbContext.Komentar.Add(komentar);
            _dbContext.SaveChanges();
            return komentar;
        }

        public Komentar Get(long id)
        {
            return _dbContext.Komentar.Find(id);
        }
        public List<Komentar> GetByVestId(long vestId)
        {
            return _dbContext.Komentar.Where(k => k.kom_ves_id == vestId).ToList();
        }

        public List<Komentar> GetAll()
        {
            return _dbContext.Komentar.ToList();
        }

        public void Remove(Komentar komentar)
        {
            _dbContext.Komentar.Remove(komentar);
            _dbContext.SaveChanges();
        }

    }
}
