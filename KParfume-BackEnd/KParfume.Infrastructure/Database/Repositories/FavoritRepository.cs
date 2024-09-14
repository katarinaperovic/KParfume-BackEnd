using KParfume.Core.Domain.RepositoryInterfaces;
using KParfume.Core.Domain;
using KParfume.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KParfume.Infrastructure.Database.Repositories
{
    public class FavoritRepository : IFavoritRepository
    {
        private readonly Context _dbContext;

        public FavoritRepository(Context context)
        {
            _dbContext = context;
        }

        public Favorit Create(Favorit f)
        {
            _dbContext.Favorit.Add(f);
            _dbContext.SaveChanges();
            return f;
        }

        public Favorit FindByParfemIdAndUserId(long parfemId, long userId)
        {
            return _dbContext.Favorit
                .FirstOrDefault(f => f.fav_par_id == parfemId && f.fav_kor_id == userId);
        }

        public void Delete(Favorit favorit)
        {
            _dbContext.Favorit.Remove(favorit);
        }

        public List<Favorit> GetAll()
        {
            return _dbContext.Favorit.ToList();
        }
    public IEnumerable<Favorit> GetByUserIdWithParfem(long userId)
    {
        return _dbContext.Favorit
                       .Include(f => f.Parfem) // Include Parfem data
                       .Where(f => f.fav_kor_id == userId)
                       .ToList();
    }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
