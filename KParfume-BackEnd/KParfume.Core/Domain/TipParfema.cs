using KParfume.BuildingBlocks.Core.Domain;

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
