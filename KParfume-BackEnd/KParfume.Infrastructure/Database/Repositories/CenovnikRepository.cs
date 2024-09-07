using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class CenovnikRepository : ICenovnikRepository
    {
        private readonly Context _dbContext;

        public CenovnikRepository(Context context)
        {
            _dbContext = context;
        }

        public Cenovnik Create(Cenovnik cenovnik)
        {
            _dbContext.Cenovnik.Add(cenovnik);
            _dbContext.SaveChanges();
            return cenovnik;
        }

        public Cenovnik Get(long id)
        {
            return _dbContext.Cenovnik.Find(id);
        }

        public Cenovnik GetByFabrikaId(long id)
        {
            return _dbContext.Cenovnik
                                 .Where(c => c.cen_fab_id == id)
                                 .FirstOrDefault();
        }

        public List<Cenovnik> GetAll()
        {
            return _dbContext.Cenovnik.ToList();
        }

        public void Remove(Cenovnik cenovnik)
        {
            _dbContext.Cenovnik.Remove(cenovnik);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
