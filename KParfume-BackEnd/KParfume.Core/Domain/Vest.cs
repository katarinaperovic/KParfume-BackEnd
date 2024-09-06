using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Vest : Entity
    {
        public long ves_admin_id { get; private set; }
        public virtual User User { get; private set; }
        public DateOnly ves_datum { get; private set; }
        public string ves_slika { get; private set; }
        public string ves_tekst { get; private set; }
        public string ves_naslov { get; private set; }

        public Vest(long ves_admin_id, DateOnly ves_datum, string ves_slika, string ves_tekst, string ves_naslov)
        {
            this.ves_admin_id = ves_admin_id;
            this.ves_datum = ves_datum;
            this.ves_slika = ves_slika;
            this.ves_tekst = ves_tekst;
            this.ves_naslov = ves_naslov;
        }

        public void Update(long ves_admin_id, DateOnly ves_datum, string ves_slika, string ves_tekst, string ves_naslov)
        {
            this.ves_admin_id = ves_admin_id;
            this.ves_datum = ves_datum;
            this.ves_slika = ves_slika;
            this.ves_tekst = ves_tekst;
            this.ves_naslov = ves_naslov;
        }
    }
}
