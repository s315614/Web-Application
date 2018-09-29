﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

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
        public string Telefon { get; set; }
        public string Fødselsdato { get; set; }
    }

    public class Filmer
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }

        public virtual List<Kategori> KategoriId { get; set; }
    }

    public class Kategorier
    {
        [Key]
        public int KategoriId { get; set; }
        public string KatgoriNavn { get; set; }
    }

    public class DBContext : DbContext
    {
        public DBContext() :
            base("name=Database")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Filmer> Filmer { get; set; }
        public DbSet<Brukere> Brukere { get; set; }
        public DbSet<Kategorier> Kategorier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}