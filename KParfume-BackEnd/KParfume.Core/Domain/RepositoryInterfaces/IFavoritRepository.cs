
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IFavoritRepository
    {
        Favorit Create(Favorit f);
        Favorit FindByParfemIdAndUserId(long parfemId, long userId);
        List<Favorit> GetAll();
        void Delete(Favorit favorit);
        IEnumerable<Favorit> GetByUserIdWithParfem(long userId);
        void Save();
    }
}
