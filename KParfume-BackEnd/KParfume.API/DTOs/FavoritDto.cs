
namespace KParfume.API.DTOs
{
    public class FavoritDto
    {
        public long Id { get; set; }
        public long fav_kor_id { get; set; }
        public DateOnly fav_dat { get; set; }

        public long fav_par_id { get; set; }
    }
}
