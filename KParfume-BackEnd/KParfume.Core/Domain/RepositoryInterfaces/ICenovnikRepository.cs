using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface ICenovnikRepository
    {
        Cenovnik Create(Cenovnik cenovnik);
        Cenovnik Get(long id);
        Cenovnik GetByFabrikaId(long id);
        List<Cenovnik> GetAll();
        void Remove(Cenovnik cenovnik);
        void Save();

    }
}
