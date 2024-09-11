using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class KupovinaDto
    {
        public long Id { get; set; }
        public long kup_kor_id { get; set; }
        public long kup_fab_id { get; set; }
        public DateTime kup_datum { get; set; }
        public long? kup_kpn_id { get; set; }
        
        //PAYPAL FIELDS
        public double uk_cena { get; set; } // Amount
        public string kup_valuta { get; set; } // Currency
        public string kup_status { get; set; } // PaymentStatus
        public string kup_pp_id { get; set; } // PayPalPaymentIntentId
    }
}
