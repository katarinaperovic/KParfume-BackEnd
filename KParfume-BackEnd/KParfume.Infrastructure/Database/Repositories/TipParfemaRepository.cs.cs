using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class TipParfemaRepository : ITipParfemaRepository
    {
        private readonly Context _dbContext;

        public TipParfemaRepository(Context context)
        {
            _dbContext = context;
        }

        public TipParfema Get(long id)
        {
            return _dbContext.Tip_parfema.Find(id);
        }

        public List<TipParfema> GetAll()
        {
            return _dbContext.Tip_parfema.ToList();
        }

    }
}
