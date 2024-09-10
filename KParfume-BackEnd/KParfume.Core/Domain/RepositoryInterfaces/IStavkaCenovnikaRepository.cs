using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IStavkaCenovnikaRepository
    {
        StavkaCenovnika Create(StavkaCenovnika stavkaCenovnika);
        StavkaCenovnika Get(long id);
        StavkaCenovnika getByParfemId(long parfemId);
        List<StavkaCenovnika> GetAll();
        StavkaCenovnika GetByParfemId(long id);
        List<StavkaCenovnika> GetAllByCenovnikId(long cenovnikId);
        void Remove(StavkaCenovnika stavkaCenovnika);
        void Save();

    }
}
