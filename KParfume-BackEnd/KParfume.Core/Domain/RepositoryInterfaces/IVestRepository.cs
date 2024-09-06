using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IVestRepository
    {
        Vest Create(Vest vest);
        Vest Get(long id);
        void Remove(Vest vest);
        List<Vest> GetAll();
        void Save();
    }
}
