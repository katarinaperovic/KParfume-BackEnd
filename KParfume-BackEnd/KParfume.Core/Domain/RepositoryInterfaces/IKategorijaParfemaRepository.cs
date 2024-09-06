
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKategorijaParfemaRepository
    {
        KategorijaParfema Get(long id);
        List<KategorijaParfema> GetAll();

    }
}
