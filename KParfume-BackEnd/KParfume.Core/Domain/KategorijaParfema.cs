using KParfume.BuildingBlocks.Core.Domain;

namespace KParfume.Core.Domain
{
    public class KategorijaParfema : Entity
    {
        public string kp_naziv { get;private set; }

        public KategorijaParfema(string kp_naziv)
        {
            this.kp_naziv = kp_naziv;
        }

    }
}
