using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class StavkaKupovineRepository : IStavkaKupovineRepository
    {
        private readonly Context _dbContext;

        public StavkaKupovineRepository(Context context)
        {
            _dbContext = context;
        }

        public StavkaKupovine Create(StavkaKupovine stavkaKupovine)
        {
            _dbContext.StavkaKupovine.Add(stavkaKupovine);
            _dbContext.SaveChanges();
            return stavkaKupovine;
        }

        public StavkaKupovine Get(long id)
        {
            return _dbContext.StavkaKupovine.Find(id);
        }

        public List<StavkaKupovine> GetAll()
        {
            return _dbContext.StavkaKupovine.ToList();
        }

        public List<StavkaKupovine> GetAllByKupovinaId(long id)
        {
            return _dbContext.StavkaKupovine.Where(x => x.sk_kup_id == id).ToList();
        }

    }
}
