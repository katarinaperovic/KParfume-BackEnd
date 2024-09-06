using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class KategorijaParfemaRepository : IKategorijaParfemaRepository
    {
        private readonly Context _dbContext;

        public KategorijaParfemaRepository(Context context)
        {
            _dbContext = context;
        }

        public KategorijaParfema Get(long id)
        {
            return _dbContext.Kategorija_parfema.Find(id);
        }

        public List<KategorijaParfema> GetAll()
        {
            return _dbContext.Kategorija_parfema.ToList();
        }
    }
}
