using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Kupovina : Entity
    {
        public long kup_kor_id { get; private set; }
        public virtual User Korisnik { get; private set; }
        public long kup_fab_id { get; private set; }
        public virtual Fabrika Fabrika { get; private set; }
        public DateTime kup_datum { get; private set; }
        public long? kup_kpn_id { get; private set; }
        public virtual Kupon Kupon { get; private set; }

        //PAYPAL FIELDS
        public double uk_cena { get; private set; } // Amount
        public string kup_valuta { get; private set; } // Currency
        public string kup_status { get; private set; } // PaymentStatus
        public string kup_pp_id { get; private set; } // PayPalPaymentIntentId

        /*        
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = "USD";
        public string PaymentStatus { get; private set; }
        public string PayPalPaymentIntentId { get; private set; }*/

        public Kupovina(long kup_kor_id, long kup_fab_id, DateTime kup_datum, long? kup_kpn_id, double uk_cena, string kup_valuta, string kup_status, string kup_pp_id)
        {
            this.kup_kor_id = kup_kor_id;
            this.kup_fab_id = kup_fab_id;
            this.kup_datum = kup_datum;
            this.kup_kpn_id = kup_kpn_id;
            this.uk_cena = uk_cena;
            this.kup_valuta = kup_valuta;
            this.kup_status = kup_status;
            this.kup_pp_id = kup_pp_id;
        }

    }
}
