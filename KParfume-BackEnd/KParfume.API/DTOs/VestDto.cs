
namespace KParfume.API.DTOs
{
    public class VestDto
    {
        public long Id { get; set; }

        public long ves_admin_id { get; set; }
        public DateOnly ves_datum { get; set; }
        public string ves_slika { get; set; }
        public string ves_tekst { get; set; }
        public string ves_naslov { get; set; }
    }
}
