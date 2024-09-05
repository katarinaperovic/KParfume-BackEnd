using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class VrstaParfemaRepository : IVrstaParfemaRepository
    {
        private readonly Context _dbContext;

        public VrstaParfemaRepository(Context context)
        {
            _dbContext = context;
        }

        public VrstaParfema Get(long id)
        {
            return _dbContext.Vrsta_parfema.Find(id);
        }

        public List<VrstaParfema> GetAll()
        {
            return _dbContext.Vrsta_parfema.ToList();
        }

    }
}
