using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class VrstaParfema : Entity
    {
        public string vp_naziv { get; private set; }

        public VrstaParfema(string vp_naziv)
        {
            this.vp_naziv = vp_naziv;
        }
    }
}
