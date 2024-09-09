using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKorpaRepository
    {
        Korpa Create(Korpa korpa);
        Korpa Get(long id);
        Korpa GetByUserId(long id);
        List<Korpa> GetAll();
        void Remove(Korpa korpa);
        void Save();

    }
}
