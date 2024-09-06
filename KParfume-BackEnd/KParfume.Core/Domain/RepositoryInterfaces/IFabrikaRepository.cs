
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IFabrikaRepository
    {
        Fabrika Create(Fabrika fabrika);
        Fabrika Get(long id);
        List<Fabrika> GetAll();
        void Remove(Fabrika fabrika);
        void Save();
        bool Exists(long id);

    }
}
