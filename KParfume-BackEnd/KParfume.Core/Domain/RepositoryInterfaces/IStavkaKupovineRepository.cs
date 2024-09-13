using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IStavkaKupovineRepository
    {
        StavkaKupovine Create(StavkaKupovine stavkaKupovine);
        StavkaKupovine Get(long id);
        List<StavkaKupovine> GetAll();
        List<StavkaKupovine> GetAllByKupovinaId(long id);
        List<StavkaKupovine> GetAllByFabrikaId(long fabrikaId);

    }
}
