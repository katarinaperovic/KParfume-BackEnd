using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface IKomentarRepository
    {
        Komentar Create(Komentar komentar);
        Komentar Get(long id);
        List<Komentar> GetAll();
        void Remove(Komentar komentar);

    }
}
