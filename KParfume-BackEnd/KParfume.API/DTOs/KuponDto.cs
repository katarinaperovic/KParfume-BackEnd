
namespace KParfume.API.DTOs
{
    public class KuponDto
    {
        public long Id { get; set; }
        public long kpn_kor_id { get; set; }
        public string kpn_kod { get; set; }
        public string kpn_opis { get; set; }
        public double kpn_popust { get; set; }
        public Boolean kpn_aktivan { get; set; }
        public Boolean kpn_pk_valid { get; set; }
    }
}
