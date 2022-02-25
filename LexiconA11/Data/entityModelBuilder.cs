using LexiconA11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconA11.Data
{
    public static class entityModelBuilder
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "NissE", CityId = 1, PhoneNr = "09341" });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "HassE", CityId = 2, PhoneNr = "020KNDÖDEN" });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Bojan E", CityId = 3, PhoneNr = "123CALLING" });

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 1, Name = "Turkiet" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 2, Name = "Somaliland" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 3, Name = "Sverige" });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, Name = "Ankara", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2, Name = "Istanbul", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 3, Name = "Malmö", CountryId = 2 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 4, Name = "Oslo", CountryId = 3 });

            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 1, Name = "Swahili" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 2, Name = "Norska" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 3, Name = "Passamaquoddy" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 4, Name = "Xhosa" });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 2, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 3, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 4 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 2, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 1 });

            string aroleId = Guid.NewGuid().ToString();
            string auserId = Guid.NewGuid().ToString();
            string uroleId = Guid.NewGuid().ToString();
            string uuserId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
            {
                Id = aroleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = uroleId,
                Name = "User",
                NormalizedName = "USER"
            });
            PasswordHasher<AppUser> hash = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
            {
                Id = auserId,
                Email = "a@mail.com",
                NormalizedEmail = "A@MAIL.COM",
                UserName = "a",
                NormalizedUserName = "A@MAIL.COM",
                PasswordHash = hash.HashPassword(null, "p"),
                FirstName = "Agent",
                LastName = "Smith"
            },
                new AppUser
            {
                Id = uuserId,
                Email = "u@mail.com",
                NormalizedEmail = "U@MAIL.COM",
                UserName = "u",
                NormalizedUserName = "U@MAIL.COM",
                PasswordHash = hash.HashPassword(null, "p"),
                FirstName = "Thomas",
                LastName = "Anderson"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
            {
                RoleId = aroleId,
                UserId = auserId
            },
            new IdentityUserRole<string>
            {
                RoleId = uroleId,
                UserId = auserId
            },
            new IdentityUserRole<string>
            {
                RoleId = uroleId,
                UserId = uuserId
            });
        }
    }
}
