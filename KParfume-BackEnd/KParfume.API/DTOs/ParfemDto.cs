using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class ParfemDto
    {
        public long Id { get; set; }
        public string par_naziv { get; set; }
        public string par_opis { get; set; }
        public string par_slika { get; set; }
        public int par_kolicina { get; set; }
        public double par_mililitraza { get; set; }
        public bool par_dostupan { get; set; }
        public bool par_obrisan { get; set; }
        public long par_fab_id { get; set; }
        public long par_vp_id { get; set; }
        public long par_tp_id { get; set; }
        public long par_kp_id { get; set; }
    }
}
