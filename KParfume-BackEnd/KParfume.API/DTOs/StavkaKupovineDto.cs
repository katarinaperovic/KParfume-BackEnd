using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class StavkaKupovineDto
    {
        public long Id { get; set; }
        public double sk_cena_pj { get; set; }
        public long sk_par_id { get; set; }
        public long sk_kup_id { get; set; }
        public int sk_kolicina { get; set; }
    }
}
