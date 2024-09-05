using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKategorijaParfemaRepository
    {
        KategorijaParfema Get(long id);
        List<KategorijaParfema> GetAll();

    }
}
