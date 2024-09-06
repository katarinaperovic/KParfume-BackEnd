
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IVestRepository
    {
        Vest Create(Vest vest);
        Vest Get(long id);
        void Remove(Vest vest);
        List<Vest> GetAll();
        void Save();
    }
}
