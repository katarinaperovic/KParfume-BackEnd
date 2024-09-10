using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Recenzija : Entity
    {
        public int rec_ocena { get; private set; }
        public string rec_tekst { get; private set; }
        public StatusRecenzije rec_status { get; private set; }
        public long rec_kor_id { get; private set; }
        public virtual User User { get; private set; }
        public long rec_kup_id { get; private set; }
        public virtual Kupovina Kupovina { get; private set; }

        public Recenzija(int rec_ocena, string rec_tekst, StatusRecenzije rec_status, long rec_kor_id, long rec_kup_id)
        {
            this.rec_ocena = rec_ocena;
            this.rec_tekst = rec_tekst;
            this.rec_status = rec_status;
            this.rec_kor_id = rec_kor_id;
            this.rec_kup_id = rec_kup_id;
            
        }

        public void Update(int rec_ocena, string rec_tekst, StatusRecenzije rec_status, long rec_kor_id, long rec_kup_id)
        {
            this.rec_ocena = rec_ocena;
            this.rec_tekst = rec_tekst;
            this.rec_status = rec_status;
            this.rec_kor_id = rec_kor_id;
            this.rec_kup_id = rec_kup_id;

        }



        public enum StatusRecenzije
        {
            obrada,
            odobreno,
            odbijeno
        }

    }
}
