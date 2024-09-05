using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class TipParfema : Entity
    {
        public string tp_naziv { get; private set; }

        public TipParfema(string tp_naziv)
        {
            this.tp_naziv = tp_naziv;
        }
    }
}
