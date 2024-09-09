using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class KupovinaRepository : IKupovinaRepository
    {
        private readonly Context _dbContext;

        public KupovinaRepository(Context context)
        {
            _dbContext = context;
        }

        public Kupovina Create(Kupovina kupovina)
        {
            _dbContext.Kupovina.Add(kupovina);
            _dbContext.SaveChanges();
            return kupovina;
        }

        public Kupovina Get(long id)
        {
            return _dbContext.Kupovina.Find(id);
        }

        public List<Kupovina> GetAll()
        {
            return _dbContext.Kupovina.ToList();
        }

        public List<Kupovina> GetAllByUserId(long id)
        {
            return _dbContext.Kupovina.Where(x => x.kup_kor_id == id).ToList();
        }



    }
}
