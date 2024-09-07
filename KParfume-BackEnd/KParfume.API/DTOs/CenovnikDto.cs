using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class CenovnikDto
    {
        public long Id { get; set; }
        public DateOnly cen_dat_poc { get; set; }
        public long cen_fab_id { get; set; }
    }
}
