using KParfume.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.Public
{
    public interface ISvojstvaParfemaService 
    {
        List<VrstaParfemaDto> GetAllVrstaParfema();
        List<TipParfemaDto> GetAllTipParfema();
        List<KategorijaParfemaDto> GetAllKategorijaParfema();
        VrstaParfemaDto GetVrstaParfema(long id);
        TipParfemaDto GetTipParfema(long id);
        KategorijaParfemaDto GetKategorijaParfema(long id);

    }
}
