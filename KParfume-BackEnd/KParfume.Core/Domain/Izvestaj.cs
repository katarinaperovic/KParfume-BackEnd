using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Izvestaj : Entity
    {
        public DateOnly izv_datum { get; private set; }
        public long izv_kor_id { get; private set; }
        public virtual User User { get; private set; }
        public string izv_putanja { get; private set; }

        public Izvestaj(DateOnly izv_datum, long izv_kor_id,string izv_putanja)
        {
            this.izv_datum = izv_datum;
            this.izv_kor_id=izv_kor_id;
            this.izv_putanja = izv_putanja;
        }
    }
}
