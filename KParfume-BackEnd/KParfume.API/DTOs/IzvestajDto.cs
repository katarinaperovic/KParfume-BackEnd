using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class IzvestajDto
    {
        public long Id { get; set; }
        public DateOnly izv_datum { get; set; }
        public long izv_kor_id { get; set; }
        public string izv_putanja { get; set; }
    }
}
