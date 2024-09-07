using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class StavkaCenovnikaDto
    {
        public long Id { get; set; }
        public int sc_cena { get; set; }
        public long sc_par_id { get; set; }
        public long sc_cen_id { get; set; }        
    }
}
