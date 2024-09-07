
namespace KParfume.API.DTOs
{
    public class KomentarDto
    {
        public long Id { get; set; }
        public long kom_kor_id { get; set; }
        public long kom_ves_id { get; set; }
        public DateOnly kom_datum { get; set; }
        public string kom_tekst { get; set; }
    }
}
