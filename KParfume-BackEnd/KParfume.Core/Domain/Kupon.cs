using KParfume.BuildingBlocks.Core.Domain;

namespace KParfume.Core.Domain
{
    public class Kupon : Entity
    {
        public long kpn_kor_id { get; private set; }
        public virtual User User { get; private set; }
        public string kpn_kod { get; private set; }
        public string kpn_opis { get; private set; }
        public double kpn_popust { get; private set; }
        public Boolean kpn_aktivan { get; private set; }
        public Boolean kpn_pk_valid { get; private set; }


        public Kupon(long kpn_kor_id, string kpn_kod, string kpn_opis, double kpn_popust, bool kpn_aktivan, bool kpn_pk_valid)
        {
            this.kpn_kor_id = kpn_kor_id;
            this.kpn_kod = kpn_kod;
            this.kpn_opis = kpn_opis;
            this.kpn_popust = kpn_popust;
            this.kpn_aktivan = kpn_aktivan;
            this.kpn_pk_valid = kpn_pk_valid;
        }

        public void SetKuponIskoriscen()
        {
            kpn_aktivan = false;
        }

    }
}
