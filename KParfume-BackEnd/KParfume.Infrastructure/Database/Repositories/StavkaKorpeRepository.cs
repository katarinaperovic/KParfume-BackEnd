using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class StavkaKorpeRepository : IStavkaKorpeRepository
    {
        private readonly Context _dbContext;

        public StavkaKorpeRepository(Context context)
        {
            _dbContext = context;   
        }

        public StavkaKorpe Create(StavkaKorpe stavkaKorpe)
        {
            _dbContext.Stavka_korpe.Add(stavkaKorpe);
            _dbContext.SaveChanges();
            return stavkaKorpe;
        }

        public StavkaKorpe Get(long id)
        {
            return _dbContext.Stavka_korpe.Find(id);
        }

        public List<StavkaKorpe> GetAll()
        {
            return _dbContext.Stavka_korpe.ToList();
        }

        public List<StavkaKorpe> GetAllByKorpaId(long id)
        {
            return _dbContext.Stavka_korpe.Where(sk=> sk.skrp_krp_id == id).ToList();
        }

        public void Remove(StavkaKorpe stavkaKorpe)
        {
            _dbContext.Stavka_korpe.Remove(stavkaKorpe);
            _dbContext.SaveChanges();
        }

        public void RemoveAllByKorpaId(long id)
        {
            var stavkeKorpe = _dbContext.Stavka_korpe.Where(sk => sk.skrp_krp_id == id).ToList();
            foreach (var stavkaKorpe in stavkeKorpe)
            {
                _dbContext.Stavka_korpe.Remove(stavkaKorpe);
            }
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
