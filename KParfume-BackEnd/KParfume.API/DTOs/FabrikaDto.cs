
namespace KParfume.API.DTOs
{
    public class FabrikaDto
    {
        public long Id { get; set; }
        public string fab_naziv { get; set; }
        public string fab_adresa { get; set; }
        public string fab_grad { get; set; }
        public int fab_pos_br { get; set; }
        public string fab_drzava { get; set; }
        public string fab_vreme_od { get; set; }
        public string fab_vreme_do { get; set; }
        public string fab_tel { get; set; }
        public string fab_logo { get; set; }
    }
}
