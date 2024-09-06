
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKomentarRepository
    {
        Komentar Create(Komentar komentar);
        Komentar Get(long id);
        List<Komentar> GetAll();
        void Remove(Komentar komentar);

    }
}
