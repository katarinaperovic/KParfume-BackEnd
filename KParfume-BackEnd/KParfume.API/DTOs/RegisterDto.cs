using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.API.DTOs
{
    public class RegisterDto
    {
        public string kor_email { get; set; }
        public string kor_lozinka { get; set; }
        public UserRoleDto kor_uloga { get; set; }
        public string kor_ime { get; set; }
        public string kor_prezime { get; set; }
        public string kor_adresa { get; set; }
        public string kor_grad { get; set; }
        public int kor_pos_br { get; set; }
        public string kor_drzava { get; set; }
        public string kor_tel { get; set; }
        public long? kor_fab_id { get; set; }
        public string? kor_ime_kompanije { get; set; }
    }
}
