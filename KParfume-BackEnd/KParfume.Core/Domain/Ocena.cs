using KParfume.BuildingBlocks.Core.Domain;

namespace KParfume.Core.Domain
{
    public class Ocena : Entity
    {
        public long ocn_kor_id { get; private set; }
        public virtual User User { get; private set; }
        public DateOnly ocn_dat { get; private set; }
        public string ocn_kom { get; private set; }
        public int ocn_vrednost { get; private set; }


        public Ocena(long ocn_kor_id, DateOnly ocn_dat, string ocn_kom, int ocn_vrednost)
        {
            this.ocn_kor_id = ocn_kor_id;
            this.ocn_dat = ocn_dat;
            this.ocn_kom = ocn_kom;
            this.ocn_vrednost = ocn_vrednost;
        }

    }
}
