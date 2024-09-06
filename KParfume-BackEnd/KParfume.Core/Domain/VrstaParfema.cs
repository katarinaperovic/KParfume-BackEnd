using KParfume.BuildingBlocks.Core.Domain;

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
