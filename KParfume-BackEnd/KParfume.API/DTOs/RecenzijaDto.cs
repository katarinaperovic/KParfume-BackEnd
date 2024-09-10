
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class RecenzijaDto
    {
        public long Id { get; set; }
        public int rec_ocena { get; set; }
        public string rec_tekst { get; set; }
        public StatusRecenzijeDto rec_status { get; set; }
        public long rec_kor_id { get; set; }
        public long rec_kup_id { get; set; }
    }

    public enum StatusRecenzijeDto
    {
        obrada,
        odobreno,
        odbijeno
    }
}
