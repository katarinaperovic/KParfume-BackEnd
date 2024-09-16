using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Stavka_kupovine.Add(stavkaKupovine);
            _dbContext.SaveChanges();
            return stavkaKupovine;
        }

        public StavkaKupovine Get(long id)
        {
            return _dbContext.Stavka_kupovine.Find(id);
        }

        public List<StavkaKupovine> GetAll()
        {
            return _dbContext.Stavka_kupovine.ToList();
        }

        public List<StavkaKupovine> GetAllByKupovinaId(long id)
        {
            return _dbContext.Stavka_kupovine.Where(x => x.sk_kup_id == id).ToList();
        }

        /*        public List<StavkaKupovine> GetAllByFabrikaId(long fabrikaId)
                {
                    // Assuming you have access to the DbContext and your StavkaKupovine entity is mapped correctly.
                    return _dbContext.Stavka_kupovine
                                     .Where(sk => sk.Kupovina.kup_fab_id == fabrikaId)
                                     .ToList();
                }*/
        public List<StavkaKupovine> GetAllByFabrikaId(long fabrikaId)
        {
            return _dbContext.Stavka_kupovine
                             .Include(sk => sk.Kupovina)  // Ensure Kupovina is loaded
                             .ThenInclude(k => k.Kupon)   // Optionally load Kupon if it's directly accessible from Kupovina
                             .Where(sk => sk.Kupovina.kup_fab_id == fabrikaId)
                             .ToList();
        }


    }
}
