﻿using KParfume.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KParfume.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<User> Korisnik { get; set; }
        public DbSet<Fabrika> Fabrika { get; set; }
        public DbSet<Parfem> Parfem { get; set; }
        public DbSet<VrstaParfema> Vrsta_parfema { get; set; }
        public DbSet<TipParfema> Tip_parfema { get; set; }
        public DbSet<KategorijaParfema> Kategorija_parfema { get; set; }
        public DbSet<Vest> Vest { get; set; }
        public DbSet<Komentar> Komentar { get; set; }
        public DbSet<Kupon> Kupon { get; set; }
        public DbSet<Ocena> Ocena { get; set; }
        public DbSet<Cenovnik> Cenovnik { get; set; }
        public DbSet<StavkaCenovnika> Stavka_cenovnika { get; set; }
        public DbSet<Korpa> Korpa { get; set; }
        public DbSet<StavkaKorpe> Stavka_korpe { get; set; }
        public DbSet<Kupovina> Kupovina { get; set; }
        public DbSet<StavkaKupovine> Stavka_kupovine { get; set; }

        public DbSet<Izvestaj> Izvestaj { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }

        public DbSet<Favorit> Favorit { get; set; }

        public Context(DbContextOptions<Context> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("KParfumeSchema");

            modelBuilder.Entity<User>().HasIndex(u => u.kor_email).IsUnique();

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.kor_email).IsUnique();
                // Setting up the foreign key relationship
                entity.HasOne(u => u.Fabrika)
                      .WithMany()
                      .HasForeignKey(u => u.kor_fab_id)
                      .IsRequired(false); // This line ensures the FK is optional
            });


            Configure(modelBuilder);
        }

        private static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parfem>(entity =>
            {
                // Set foreign key for Fabrika
                entity.HasOne(p => p.Fabrika)
                      .WithMany()  // If Fabrika has a collection of Parfem, use .WithMany(f => f.Parfemi)
                      .HasForeignKey(p => p.par_fab_id)
                      .IsRequired();

                // Set foreign key for VrstaParfema
                entity.HasOne(p => p.VrstaParfema)
                      .WithMany()  // Adjust according to your model if VrstaParfema has a collection of Parfem
                      .HasForeignKey(p => p.par_vp_id)
                      .IsRequired();

                // Set foreign key for TipParfema
                entity.HasOne(p => p.TipParfema)
                      .WithMany()  // Adjust according to your model if TipParfema has a collection of Parfem
                      .HasForeignKey(p => p.par_tp_id)
                      .IsRequired();

                // Set foreign key for KategorijaParfema
                entity.HasOne(p => p.KategorijaParfema)
                      .WithMany()  // Adjust according to your model if KategorijaParfema has a collection of Parfem
                      .HasForeignKey(p => p.par_kp_id)
                      .IsRequired();

                // Additional configuration for Parfem
                entity.Property(p => p.par_naziv).IsRequired().HasMaxLength(255);
                entity.Property(p => p.par_opis).IsRequired();
                entity.Property(p => p.par_slika).IsRequired();
                entity.Property(p => p.par_kolicina).IsRequired();
                entity.Property(p => p.par_mililitraza).IsRequired();
                entity.Property(p => p.par_dostupan).IsRequired();
                entity.Property(p => p.par_obrisan).IsRequired();

            });

            modelBuilder.Entity<Vest>(entity =>
            {
                entity.HasOne(v => v.User)
                      .WithMany()
                      .HasForeignKey(v => v.ves_admin_id)
                      .IsRequired();

                entity.Property(v => v.ves_datum).IsRequired();
                //entity.Property(v => v.ves_slika).IsRequired();
                entity.Property(v => v.ves_tekst).IsRequired();
                entity.Property(v => v.ves_naslov).IsRequired();
            });


            modelBuilder.Entity<Komentar>(entity =>
            {
                entity.HasOne(k => k.User)
                      .WithMany()
                      .HasForeignKey(k => k.kom_kor_id)
                      .IsRequired();

                entity.HasOne(k => k.Vest)
                      .WithMany()
                      .HasForeignKey(k => k.kom_ves_id)
                      .IsRequired();

                entity.Property(k => k.kom_datum).IsRequired();
                entity.Property(k => k.kom_tekst).IsRequired();
            });


            modelBuilder.Entity<Kupon>(entity =>
            {
                entity.HasOne(v => v.User)
                      .WithMany()
                      .HasForeignKey(v => v.kpn_kor_id)
                      .IsRequired();

                entity.Property(v => v.kpn_opis).IsRequired();
                entity.Property(v => v.kpn_pk_valid).IsRequired();
                entity.Property(v => v.kpn_popust).IsRequired();
                entity.Property(v => v.kpn_kod).IsRequired();
            });


            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.HasOne(v => v.User)
                      .WithMany()
                      .HasForeignKey(v => v.ocn_kor_id)
                      .IsRequired();

                entity.Property(v => v.ocn_vrednost).IsRequired();
                entity.Property(v => v.ocn_kom).IsRequired();
            });

            modelBuilder.Entity<Cenovnik>(entity =>
            {
                entity.HasOne(c => c.Fabrika)
                      .WithMany()
                      .HasForeignKey(c => c.cen_fab_id)
                      .IsRequired();

                entity.Property(c => c.cen_dat_poc).IsRequired();
            });

            modelBuilder.Entity<StavkaCenovnika>(entity =>
            {
                entity.HasOne(s => s.Parfem)
                      .WithMany()
                      .HasForeignKey(s => s.sc_par_id)
                      .IsRequired();

                entity.HasOne(s => s.Cenovnik)
                      .WithMany()
                      .HasForeignKey(s => s.sc_cen_id)
                      .IsRequired();

                entity.Property(s => s.sc_cena).IsRequired();
            });

            modelBuilder.Entity<Korpa>(entity =>
            {
                entity.HasOne(k => k.Korisnik)
                      .WithMany()
                      .HasForeignKey(k => k.krp_kor_id)
                      .IsRequired();

                entity.Property(k => k.krp_prazna).IsRequired();
            });

            modelBuilder.Entity<StavkaKorpe>(entity =>
            {
                entity.HasOne(s => s.Parfem)
                      .WithMany()
                      .HasForeignKey(s => s.skrp_par_id)
                      .IsRequired();

                entity.HasOne(s => s.Korpa)
                      .WithMany()
                      .HasForeignKey(s => s.skrp_krp_id)
                      .IsRequired();

                entity.Property(s => s.skrp_cena_pj).IsRequired();
                entity.Property(s => s.skrp_kolicina).IsRequired();
            });

            modelBuilder.Entity<Kupovina>(entity =>
            {
                entity.HasOne(k => k.Korisnik)
                      .WithMany()
                      .HasForeignKey(k => k.kup_kor_id)
                      .IsRequired();

                entity.HasOne(k => k.Fabrika)
                      .WithMany()
                      .HasForeignKey(k => k.kup_fab_id)
                      .IsRequired();

                entity.HasOne(k => k.Kupon)
                      .WithMany()
                      .HasForeignKey(k => k.kup_kpn_id)
                      .IsRequired(false);

                entity.Property(k => k.kup_uk_cena).IsRequired();
                entity.Property(k => k.kup_valuta).IsRequired();
                entity.Property(k => k.kup_status).IsRequired();
                entity.Property(k => k.kup_pp_id).IsRequired();
            });

            modelBuilder.Entity<StavkaKupovine>(entity =>
            {
                entity.HasOne(s => s.Parfem)
                      .WithMany()
                      .HasForeignKey(s => s.sk_par_id)
                      .IsRequired();
                
                entity.HasOne(s => s.Kupovina)
                      .WithMany()
                      .HasForeignKey(s => s.sk_kup_id)
                      .IsRequired();

            });

            modelBuilder.Entity<Izvestaj>(entity =>
            {
                entity.HasOne(i => i.User)
                      .WithMany()
                      .HasForeignKey(i => i.izv_kor_id)
                      .IsRequired();

                entity.Property(i=>i.izv_datum).IsRequired();
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.HasOne(r => r.User)
                      .WithMany()
                      .HasForeignKey(r => r.rec_kor_id)
                      .IsRequired();

                entity.HasOne(r => r.Kupovina)
                     .WithMany()
                     .HasForeignKey(r=>r.rec_kup_id)
                     .IsRequired();

                entity.Property(r => r.rec_tekst).IsRequired();
                entity.Property(r => r.rec_ocena).IsRequired();
                entity.Property(r => r.rec_status).IsRequired();
            });


            modelBuilder.Entity<Favorit>(entity =>
            {
                entity.HasOne(f => f.User)
                      .WithMany()
                      .HasForeignKey(f => f.fav_kor_id)
                      .IsRequired();

                entity.HasOne(f => f.Parfem)
                      .WithMany()
                      .HasForeignKey(f => f.fav_par_id)
                      .IsRequired();

                entity.Property(f => f.fav_dat).IsRequired();
            });


        }
    }
}
