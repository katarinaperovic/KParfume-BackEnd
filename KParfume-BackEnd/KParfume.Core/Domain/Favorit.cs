using KParfume.BuildingBlocks.Core.Domain;

namespace KParfume.Core.Domain
{
    public class Favorit : Entity
    {
        public long fav_kor_id { get; private set; }
        public virtual User User { get; private set; }
        public DateOnly fav_dat { get; private set; }
        public long fav_par_id { get; private set; }
        public virtual Parfem Parfem { get; private set; }

        public Favorit(long fav_kor_id, DateOnly fav_dat, long fav_par_id)
        {
           this.fav_kor_id= fav_kor_id;
            this.fav_dat= fav_dat;
            this.fav_par_id= fav_par_id;
        }

    }
}
