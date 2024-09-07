using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class StavkaKorpe : Entity
    {
        public long skrp_par_id { get; private set; }
        public virtual Parfem Parfem { get; private set; }
        public double skrp_cena_pj { get; private set; }
        public long skrp_krp_id { get; private set; }
        public virtual Korpa Korpa { get; private set; }
        public int skrp_kolicina { get; private set; }

        public StavkaKorpe(long skrp_par_id, double skrp_cena_pj, long skrp_krp_id, int skrp_kolicina)
        {
            this.skrp_par_id = skrp_par_id;
            this.skrp_cena_pj = skrp_cena_pj;
            this.skrp_krp_id = skrp_krp_id;
            this.skrp_kolicina = skrp_kolicina;
        }

        public void KolicinaInkrement()
        {
            skrp_kolicina += 1;
        }

        public void KolicinaDekrement()
        {
            skrp_kolicina -= 1;
        }

    }
}
