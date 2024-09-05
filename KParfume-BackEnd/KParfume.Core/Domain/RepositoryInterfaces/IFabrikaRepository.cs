using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
