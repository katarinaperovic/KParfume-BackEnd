
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKomentarRepository
    {
        Komentar Create(Komentar komentar);
        Komentar Get(long id);
        List<Komentar> GetAll();
        List<Komentar> GetByVestId(long vestId);
        void Remove(Komentar komentar);

    }
}
