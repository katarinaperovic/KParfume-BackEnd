
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface ITipParfemaRepository
    {
        TipParfema Get(long id);
        List<TipParfema> GetAll();


    }
}
