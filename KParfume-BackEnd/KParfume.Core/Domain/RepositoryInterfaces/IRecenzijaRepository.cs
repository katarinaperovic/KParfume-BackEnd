
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IRecenzijaRepository
    {
        Recenzija Create(Recenzija recenzija);
        List<Recenzija> GetAll();
        Recenzija Get(long id);
        void Save();
    }
}
