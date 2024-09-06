using KParfume.API.DTOs;

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
