using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Korpa : Entity
    {
        public bool krp_prazna { get; private set; }
        public long krp_kor_id { get; private set; }
        public virtual User Korisnik { get; private set; }

        public Korpa(bool krp_prazna, long krp_kor_id)
        {
            this.krp_prazna = krp_prazna;
            this.krp_kor_id = krp_kor_id;
        }

        public void KorpaJePrazna()
        {
            krp_prazna = true;
        }

        public void KorpaNijePrazna()
        {
            krp_prazna = false;
        }


    }
}
