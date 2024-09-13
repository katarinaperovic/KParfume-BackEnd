using KParfume.BuildingBlocks.Core.Domain;

namespace KParfume.Core.Domain
{
    public class Fabrika : Entity
    {
        public string fab_naziv { get; private set; }
        public string fab_adresa { get; private set; }
        public string fab_grad { get; private set; }
        public int fab_pos_br { get; private set; }
        public string fab_drzava { get; private set; }
        public string fab_vreme_od { get; private set; }
        public string fab_vreme_do { get; private set; }
        public string fab_tel { get; private set; }
        public string fab_logo { get; private set; }
        public double fab_ocena { get; private set; }

        public Fabrika(string fab_naziv, string fab_adresa, string fab_grad, int fab_pos_br, string fab_drzava, string fab_vreme_od, string fab_vreme_do, string fab_tel, string fab_logo, double fab_ocena)
        {
            this.fab_naziv = fab_naziv;
            this.fab_adresa = fab_adresa;
            this.fab_grad = fab_grad;
            this.fab_pos_br = fab_pos_br;
            this.fab_drzava = fab_drzava;
            this.fab_vreme_od = fab_vreme_od;
            this.fab_vreme_do = fab_vreme_do;
            this.fab_tel = fab_tel;
            Validate();
            this.fab_logo = fab_logo;
            this.fab_ocena = fab_ocena;
        }

        public void UpdateRating(double newAverageRating)
        {
            fab_ocena = newAverageRating;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(fab_naziv)) throw new ArgumentException("Invalid fab_naziv");
            if (string.IsNullOrWhiteSpace(fab_adresa)) throw new ArgumentException("Invalid fab_adresa");
            if (string.IsNullOrWhiteSpace(fab_grad)) throw new ArgumentException("Invalid fab_grad");
            if (fab_pos_br <= 0) throw new ArgumentException("Invalid fab_pos_br");
            if (string.IsNullOrWhiteSpace(fab_drzava)) throw new ArgumentException("Invalid fab_drzava");
            if (string.IsNullOrWhiteSpace(fab_vreme_od)) throw new ArgumentException("Invalid fab_vreme_od");
            if (string.IsNullOrWhiteSpace(fab_vreme_do)) throw new ArgumentException("Invalid fab_vreme_do");
            if (string.IsNullOrWhiteSpace(fab_tel)) throw new ArgumentException("Invalid fab_tel");
        }
    }
}
