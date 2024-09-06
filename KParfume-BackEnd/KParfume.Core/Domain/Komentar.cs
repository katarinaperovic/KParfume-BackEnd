using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Komentar : Entity
    {
        public long kom_kor_id { get; private set; }
        public virtual User User { get; private set; }
        public long kom_ves_id { get; private set; }
        public virtual Vest Vest { get; private set; }
        public DateOnly kom_datum { get; private set; }
        public string kom_tekst { get; private set; }

        public Komentar(string kom_tekst, DateOnly kom_datum, long kom_kor_id, long kom_ves_id)
        {
            this.kom_kor_id = kom_kor_id;
            this.kom_ves_id = kom_ves_id;
            this.kom_tekst = kom_tekst;
            this.kom_datum = kom_datum;
        }
    }
}
