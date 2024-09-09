using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class KorpaRepository : IKorpaRepository
    {
        private readonly Context _dbContext;

        public KorpaRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Korpa Create(Korpa korpa)
        {
            _dbContext.Korpa.Add(korpa);
            _dbContext.SaveChanges();
            return korpa;
        }

        public Korpa Get(long id)
        {
            return _dbContext.Korpa.Find(id);
        }

        public Korpa GetByUserId(long id)
        {
            return _dbContext.Korpa.Where(k => k.krp_kor_id == id).FirstOrDefault();
        }

        public List<Korpa> GetAll()
        {
            return _dbContext.Korpa.ToList();
        }

        public void Remove(Korpa korpa)
        {
            _dbContext.Korpa.Remove(korpa);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
