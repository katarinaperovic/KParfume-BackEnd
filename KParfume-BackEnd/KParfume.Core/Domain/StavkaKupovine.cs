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
        public int sk_kolicina { get; private set; }

        public StavkaKupovine(double sk_cena_pj, long sk_par_id, long sk_kup_id, int sk_kolicina)
        {
            this.sk_cena_pj = sk_cena_pj;
            this.sk_par_id = sk_par_id;            
            this.sk_kup_id = sk_kup_id;            
            this.sk_kolicina = sk_kolicina;
        }

        public void SetParfem(Parfem parfem)
        {
            this.Parfem = parfem;
        }
        public void ApplyDiscount(double discountPercentage)
        {
            sk_cena_pj *= (1 - discountPercentage / 100.0);
        }
    }
}
