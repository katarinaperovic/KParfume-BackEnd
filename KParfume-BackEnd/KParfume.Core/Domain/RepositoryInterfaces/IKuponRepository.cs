
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKuponRepository
    {
        Kupon Create(Kupon kupon);
        Kupon Get(long id);
        void Remove(Kupon kupon);
        List<Kupon> GetAll();
        void Save();
    }
}
