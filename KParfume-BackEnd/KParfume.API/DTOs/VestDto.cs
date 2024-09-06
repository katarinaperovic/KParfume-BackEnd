using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class VestDto
    {
        public long ves_admin_id { get; set; }
        public DateOnly ves_datum { get; set; }
        public string ves_slika { get; set; }
        public string ves_tekst { get; set; }
        public string ves_naslov { get; set; }
    }
}
