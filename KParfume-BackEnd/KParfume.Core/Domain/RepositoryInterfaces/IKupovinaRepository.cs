using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKupovinaRepository
    {
        Kupovina Create(Kupovina kupovina);
        Kupovina Get(long id);
        List<Kupovina> GetAll();
        List<Kupovina> GetAllByUserId(long id);

    }
}
