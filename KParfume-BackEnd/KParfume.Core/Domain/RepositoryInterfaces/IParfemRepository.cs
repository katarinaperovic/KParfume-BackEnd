
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IParfemRepository
    {
        Parfem Create(Parfem parfem);
        Parfem Get(long id);
        List<Parfem> GetAll();
        void Save();

    }
}
