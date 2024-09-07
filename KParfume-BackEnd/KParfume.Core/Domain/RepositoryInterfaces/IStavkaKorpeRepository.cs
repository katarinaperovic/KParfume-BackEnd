using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IStavkaKorpeRepository
    {
        StavkaKorpe Create(StavkaKorpe stavkaKorpe);
        StavkaKorpe Get(long id);
        List<StavkaKorpe> GetAll();
        List<StavkaKorpe> GetAllByKorpaId(long id);
        void Remove(StavkaKorpe stavkaKorpe);
        void Save();

    }
}
