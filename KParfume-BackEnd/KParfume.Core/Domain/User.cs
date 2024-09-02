using KParfume.BuildingBlocks.Core.Domain;
using System.Diagnostics.CodeAnalysis;

namespace KParfume.Core.Domain
{
    public class User : Entity
    {
        public string kor_email { get; private set; }
        public string kor_lozinka { get; private set; }
        public UserRole kor_uloga { get; private set; }
        public string kor_ime { get; private set; }
        public string kor_prezime { get; private set; }
        public string kor_adresa { get; private set; }
        public string kor_grad { get; private set; }
        public int kor_pos_br { get; private set; }
        public string kor_drzava { get; private set; }
        public string kor_tel { get; private set; }
        public long? kor_fab_id { get; private set; }
        public string? kor_ime_kompanije { get; private set; }
    
        public User(string kor_email, string kor_lozinka, UserRole kor_uloga, string kor_ime, string kor_prezime, string kor_adresa, string kor_grad, int kor_pos_br, string kor_drzava, string kor_tel, long? kor_fab_id, string? kor_ime_kompanije)
        {
            this.kor_email = kor_email;
            this.kor_lozinka = kor_lozinka;
            this.kor_uloga = kor_uloga;
            this.kor_ime = kor_ime;
            this.kor_prezime = kor_prezime;
            this.kor_adresa = kor_adresa;
            this.kor_grad = kor_grad;
            this.kor_pos_br = kor_pos_br;
            this.kor_drzava = kor_drzava;
            this.kor_tel = kor_tel;
            this.kor_fab_id = kor_fab_id;
            this.kor_ime_kompanije = kor_ime_kompanije;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(kor_email)) throw new ArgumentException("Invalid Username");
            if (string.IsNullOrWhiteSpace(kor_lozinka)) throw new ArgumentException("Invalid Password");
        }

        public string GetPrimaryRoleName()
        {
            return kor_uloga.ToString().ToLower();
        }
    }
}

    public enum UserRole
{
    ADMINISTRATOR,
    MENADZER,
    RADNIK,
    KUPAC
}
