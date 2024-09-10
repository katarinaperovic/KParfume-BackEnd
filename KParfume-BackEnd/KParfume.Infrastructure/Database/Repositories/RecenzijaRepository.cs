using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;
using KParfume.API.DTOs;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class RecenzijaRepository : IRecenzijaRepository
    {
        private readonly Context _dbContext;

        public RecenzijaRepository(Context context)
        {
            _dbContext = context;
        }

        public Recenzija Create(Recenzija recenzija)
        {
            _dbContext.Recenzija.Add(recenzija);
            _dbContext.SaveChanges();
            return recenzija;
        }

        public Recenzija Get(long id)
        {
            return _dbContext.Recenzija.Find(id);
        }


        public List<Recenzija> GetAll()
        {
            return _dbContext.Recenzija.ToList();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
