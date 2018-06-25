using Prodaja_i_Servis_Racunarske_Opreme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Prodaja_i_Servis_Racunarske_Opreme.DAL
{
    public class MyContext : DbContext
    {
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<EvidencijaDostave> EvidencijeDostve { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<GrupaProizvoda> GrupeProizvoda { get; set; }
        public DbSet<IzvrsenaUsluga> IzvrseneUsluge { get; set; }
        public DbSet<JedinicaMjere> JediniceMjere { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<NazivPlacanja> NaziviPlacanja { get; set; }
        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Popust> Popusti { get; set; }
        public DbSet<Proizvodjac> Proizvodjaci { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Skladiste> Skladisa { get; set; }
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<StrucnaSprema> StrucneSpreme { get; set; }
        public DbSet<TipDostave> TipoviDostava { get; set; }
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }



        public MyContext() : base("MojCS"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Osoba>().HasOptional(x => x.Korisnik).WithRequired(x => x.Osoba);
            modelBuilder.Entity<Osoba>().HasOptional(x => x.Zaposlenik).WithRequired(x => x.Osoba);
        }
    }
}