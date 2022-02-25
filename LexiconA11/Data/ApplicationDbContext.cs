using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconA11.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LexiconA11.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PersonModel> People { get; set; }

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<AppUser> Users { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonModel>()
   .Property(a => a.PersonId).IsConcurrencyToken();

            modelBuilder.Entity<PersonLanguage>().HasKey(p => new { p.PersonId, p.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<PersonModel>(pl => pl.Person)
                .WithMany(p => p.Languages)
                .HasForeignKey(pl => pl.PersonId);


            modelBuilder.Entity<PersonLanguage>()
                .HasOne<LanguageModel>(pl => pl.Language)
                .WithMany(l => l.Persons)
                .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Seed();

        }
    }
}