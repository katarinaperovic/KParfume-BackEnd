
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        User GetById(long id);
        User? GetActiveByName(string username);
        User Get(long id);
        List<User> GetAll();
        bool Exists(string username);
        void Save();
        User Create(User user);
    }
}
