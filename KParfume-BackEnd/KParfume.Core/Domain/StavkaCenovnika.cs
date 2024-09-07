using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class StavkaCenovnika : Entity
    {
        public int sc_cena { get; private set; }
        public long sc_par_id { get; private set; }
        public virtual Parfem Parfem { get; private set; }
        public long sc_cen_id { get; private set; }
        public virtual Cenovnik Cenovnik { get; private set; }

        public StavkaCenovnika(int sc_cena,long sc_par_id,long sc_cen_id)
        {
            this.sc_cena = sc_cena;
            this.sc_par_id = sc_par_id;
            this.sc_cen_id = sc_cen_id;
        }

    }
}
