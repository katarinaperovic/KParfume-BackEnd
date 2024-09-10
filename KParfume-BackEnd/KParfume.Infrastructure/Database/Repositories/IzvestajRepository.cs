using KParfume.Core.Domain;
using KParfume.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class IzvestajRepository : IIzvestajRepository
    {
        private readonly Context _dbContext;

        public IzvestajRepository(Context context)
        {
            _dbContext = context;
        }

        public Izvestaj Create(Izvestaj izvestaj)
        {
            _dbContext.Izvestaj.Add(izvestaj);
            _dbContext.SaveChanges();
            return izvestaj;
        }


        public List<Izvestaj> GetAllForAuthor(long authorId)
        {
            return _dbContext.Izvestaj.Where(i => i.izv_kor_id == authorId).ToList();
        }


    }
}
