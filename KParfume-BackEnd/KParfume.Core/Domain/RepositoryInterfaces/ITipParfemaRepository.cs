using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain.RepositoryInterfaces
{
    public interface ITipParfemaRepository
    {
        TipParfema Get(long id);
        List<TipParfema> GetAll();


    }
}
