
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IVrstaParfemaRepository
    {
        VrstaParfema Get(long id);
        List<VrstaParfema> GetAll();

    }
}
