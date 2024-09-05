﻿using KParfume.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
