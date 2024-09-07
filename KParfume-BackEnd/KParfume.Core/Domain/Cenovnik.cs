using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Cenovnik : Entity
    {
        public DateOnly cen_dat_poc { get; private set; }
        public long cen_fab_id { get; private set; }
        public virtual Fabrika Fabrika { get; private set; }

        public Cenovnik(DateOnly cen_dat_poc, long cen_fab_id)
        {
            this.cen_dat_poc = cen_dat_poc;
            this.cen_fab_id = cen_fab_id;
        }
    }
}
