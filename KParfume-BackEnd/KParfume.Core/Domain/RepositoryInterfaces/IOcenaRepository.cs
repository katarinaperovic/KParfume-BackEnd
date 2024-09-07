
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IOcenaRepository
    {
        Ocena Create(Ocena ocena);
        List<Ocena> GetAll();
        void Save();
    }
}
