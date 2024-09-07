using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class StavkaKorpeDto
    {
        public long Id { get; set; }
        public long skrp_par_id { get; set; }
        public double skrp_cena_pj { get; set; }
        public long skrp_krp_id { get; set; }
        public int skrp_kolicina { get; set; }
    }
}
