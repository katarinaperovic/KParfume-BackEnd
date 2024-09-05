using KParfume.Core.Domain;
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

        }
    }
}
