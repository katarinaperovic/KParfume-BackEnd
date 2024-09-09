using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class StavkaKupovine : Entity
    {
        public double sk_cena_pj { get; private set; }
        public long sk_par_id { get; private set; }
        public virtual Parfem Parfem { get; private set; }
        public long sk_kup_id { get; private set; }
        public virtual Kupovina Kupovina { get; private set; }
        public double sk_kolicina { get; private set; }

        public StavkaKupovine(double sk_cena_pj, long sk_par_id, Parfem parfem, long sk_kup_id, Kupovina kupovina, double sk_kolicina)
        {
            this.sk_cena_pj = sk_cena_pj;
            this.sk_par_id = sk_par_id;
            this.Parfem = parfem;
            this.sk_kup_id = sk_kup_id;
            this.Kupovina = kupovina;
            this.sk_kolicina = sk_kolicina;
        }
    }
}
