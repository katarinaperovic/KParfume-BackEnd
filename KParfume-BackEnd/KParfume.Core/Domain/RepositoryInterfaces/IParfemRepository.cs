using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
