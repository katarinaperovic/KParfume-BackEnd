using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class StavkaCenovnikaRepository : IStavkaCenovnikaRepository
    {
        private readonly Context _dbContext;

        public StavkaCenovnikaRepository(Context context)
        {
            _dbContext = context;
        }

        public StavkaCenovnika Create(StavkaCenovnika stavkaCenovnika)
        {
            _dbContext.Stavka_cenovnika.Add(stavkaCenovnika);
            _dbContext.SaveChanges();
            return stavkaCenovnika;
        }

        public StavkaCenovnika GetByParfemId(long id)
        {
            return _dbContext.Stavka_cenovnika
                                 .Where(c => c.sc_par_id == id)
                                 .FirstOrDefault();
        }
        public StavkaCenovnika Get(long id)
        {
            return _dbContext.Stavka_cenovnika.Find(id);
        }

        public StavkaCenovnika getByParfemId(long parfemId)
        {
            return _dbContext.Stavka_cenovnika.Where(s => s.sc_par_id == parfemId).FirstOrDefault();
        }

        public List<StavkaCenovnika> GetAll()
        {
            return _dbContext.Stavka_cenovnika.ToList();
        }

        public List<StavkaCenovnika> GetAllByCenovnikId( long cenovnikId)
        {
            return _dbContext.Stavka_cenovnika.Where(s=> s.sc_cen_id == cenovnikId).ToList();
        }

        public void Remove(StavkaCenovnika stavkaCenovnika)
        {
            _dbContext.Stavka_cenovnika.Remove(stavkaCenovnika);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
