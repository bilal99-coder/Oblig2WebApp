using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oblig2Webapp.DAL
{
    public class Brukere
    {
        [Key]
        public int BId { get; set; }
        public string Brukernavn { get; set; }
        public Byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
    }




    public class Havner
    {
        [Key]
        public int HavnId { get; set; }
        public string HavnNavn { get; set; }



        public virtual List<ankomstHavner> AnkomstHavner { get; set; }



    }



    public class ankomstHavner
    {
        [Key]
        public int HavnId { get; set; }
        public string HavnNavn { get; set; }
        public int pris { get; set; }
    }


    public class Reiser
    {
        [Key]
        public int ReiseId { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public int Pris { get; set; }

    }




        public class BrukerContext : DbContext
    {

        public BrukerContext(DbContextOptions<BrukerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Brukere> Brukere { get; set; }
        public DbSet<Havner> Havner { get; set; }
        public DbSet<ankomstHavner> ankomstHavner { get; set; }
        public DbSet<Reiser> Reiser { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); 
        }
    }
}
