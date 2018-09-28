using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;



namespace Gruppeoppgave1.Models
{
    public class Brukere
    {
        [Key]
        public string Epost { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Passord { get; set; }
        public int Telefon { get; set; }
        public string Følsesdato { get; set; }
    }

    public class Kategorier
    {
        [Key]
        public int KategoriId { get; set; }
        public string KatgoriNavn { get; set; }
    }

    public class Filmer
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }

        public virtual List<Kategori> KategoriId { get; set; }
    }
    public class DB: DbContext
    {
        public DB()
            : base("name=DB")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }
        public virtual DbSet<Bruker> Bruker { get; set; }
        public virtual DbSet<Film> Filme { get; set; }
        public virtual DbSet<Kategori> Kategorie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
        
    
}