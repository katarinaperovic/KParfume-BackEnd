using KParfume.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KParfume.Core.Domain
{
    public class Parfem : Entity
    {
        public string par_naziv { get; private set; }
        public string par_opis { get; private set; }
        public string par_slika { get; private set; }
        public int par_kolicina { get; private set; }
        public double par_mililitraza { get; private set; }
        public bool par_dostupan { get; private set; }
        public bool par_obrisan { get; private set; }
        public long par_fab_id { get; private set; }
        public virtual Fabrika Fabrika { get; private set; }
        public long par_vp_id { get; private set; }
        public virtual VrstaParfema VrstaParfema { get; private set; }
        public long par_tp_id { get; private set; }
        public virtual TipParfema TipParfema { get; private set; }
        public long par_kp_id { get; private set; }
        public virtual KategorijaParfema KategorijaParfema { get; private set; }

        public Parfem(string par_naziv, string par_opis, string par_slika, int par_kolicina, double par_mililitraza, bool par_dostupan, bool par_obrisan, long par_fab_id, long par_vp_id, long par_tp_id, long par_kp_id)
        {
            this.par_naziv = par_naziv;
            this.par_opis = par_opis;
            this.par_slika = par_slika;
            this.par_kolicina = par_kolicina;
            this.par_mililitraza = par_mililitraza;
            this.par_dostupan = par_dostupan;
            this.par_obrisan = par_obrisan;
            this.par_fab_id = par_fab_id;
            this.par_vp_id = par_vp_id;
            this.par_tp_id = par_tp_id;
            this.par_kp_id = par_kp_id;
        }

        public void Delete()
        {
            par_obrisan = true;
        }

       public void UpdateKolicina(int par_kolicina)
        {
            this.par_kolicina = par_kolicina;
            if (par_kolicina == 0)
            {
                par_dostupan = false;
            }
            else { par_dostupan = true; }
        }

        public void Update(string par_naziv, string par_opis, string par_slika, int par_kolicina, double par_mililitraza, bool par_dostupan, bool par_obrisan, long par_fab_id, long par_vp_id, long par_tp_id, long par_kp_id)
        {
            if (par_kolicina == 0)
            {
                par_dostupan = false;
            }
            else { par_dostupan = true; }

            this.par_naziv = par_naziv;
            this.par_opis = par_opis;
            this.par_slika = par_slika;
            this.par_kolicina = par_kolicina;
            this.par_mililitraza = par_mililitraza;
            this.par_dostupan = par_dostupan;
            this.par_obrisan = par_obrisan;
            this.par_fab_id = par_fab_id;
            this.par_vp_id = par_vp_id;
            this.par_tp_id = par_tp_id;
            this.par_kp_id = par_kp_id;
        }   


    }
}
