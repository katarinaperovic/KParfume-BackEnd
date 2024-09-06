
namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        User GetById(long id);
        User? GetActiveByName(string username);
        List<User> GetAll();
        bool Exists(string username);
        User Create(User user);
    }
}
