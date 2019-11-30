using CryptoBankBackend.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBankBackend.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IConfiguration _configuration = null;

        #endregion

        #region ----- PROPERTIES ------------------------------------------------------

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OperationEntity> Operations { get; set; }

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        #endregion

        #region ----- OVERRIDE --------------------------------------------------------

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Use List<string> with EF Core 2.1+ from https://stackoverflow.com/questions/20711986/entity-framework-code-first-cant-store-liststring

            // Seed data.

            builder.Entity<UserEntity>().HasData(SeedUsers());
            builder.Entity<OperationEntity>().HasData(SeedOperations());
        }

        #endregion

        #region ----- SEED DATA -------------------------------------------------------

        private List<UserEntity> SeedUsers()
        {
            var source = new List<UserEntity>();

            // User Stephan Arnas.
            source.Add(new UserEntity()
            {
                Id = 1,
                FirstName = "Stephan",
                LastName = "Arnas",
                Email = "stephan.arnas@gmail.com",
                Password = "Aze123",
                Credits = 2265,
                CreatedDate = DateTimeOffset.UtcNow,
            });

            // User Stephan Arnas.
            source.Add(new UserEntity()
            {
                Id = 2,
                FirstName = "Remond",
                LastName = "Dumond",
                Email = "remond.dumond@gmail.com",
                Password = "Aze123",
                Credits = 125,
                CreatedDate = DateTimeOffset.UtcNow,
            });

            return source;
        }

        private List<OperationEntity> SeedOperations()
        {
            var source = new List<OperationEntity>();

            source.Add(new OperationEntity()
            {
                Id = 1,
                Name = "Argent pour OnePlus 5T",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "maman@gmail.com",
                Amount = -466.54,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 2,
                Name = "Remboursement des courses Auchant",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "copine@gmail.com",
                Amount = -466.54,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 3,
                Name = "Tomate et citronade",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "mamy@gmail.com",
                Amount = -12.01,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 4,
                Name = "Bière entre poto",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "benjamin@gmail.com",
                Amount = -7.29,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 5,
                Name = "Bière entre poto",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "timothee@gmail.com",
                Amount = -10.5,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 6,
                Name = "Bière entre poto",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "jon@gmail.com",
                Amount = -5,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 7,
                Name = "Voyage Argentine",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "manon@gmail.com",
                Amount = -594,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 8,
                Name = "Nourriture Lecler courses",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "aurore@gmail.com",
                Amount = -84,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 9,
                Name = "Café pause boulot",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "collegue@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 10,
                Name = "Encore un autre café pause boulot",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "collegue_sympa@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 11,
                Name = "Encore Encore un autre café pause boulot",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "collegue_sympa_2@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 12,
                Name = "En route vers la promotion en offrant une biere au patron",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "patron@gmail.com",
                Amount = -8,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 13,
                Name = "Pour le resto de lundi au boulot ! Merci !",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "jepaiemesdettes@gmail.com",
                Amount = 20,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 14,
                Name = "Café du matin",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "machineacafe@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 15,
                Name = "Café de l'après midi",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "machineacafe@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 16,
                Name = "Café du soir",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "machineacafe@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 17,
                Name = "Café de la nuit",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "machineacafe@gmail.com",
                Amount = -2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 18,
                Name = "C'est pour le café de mardi",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "collegueacafe@gmail.com",
                Amount = 2,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 19,
                Name = "Repas CE",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "cedelaboite@gmail.com",
                Amount = 50,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 20,
                Name = "Noel pour mon cherie !",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "cedelaboite@gmail.com",
                Amount = 500,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 21,
                Name = "Tranche de pain",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "jaifaim@gmail.com",
                Amount = -1.62,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 22,
                Name = "Tranche de pain le retour",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "jaitresfaim@gmail.com",
                Amount = -1.45,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 23,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -4.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 24,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -3.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 25,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -3.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 26,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -3.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 27,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -3.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 28,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -3.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 29,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -4.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 30,
                Name = "Location de film",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "rentdvd@gmail.com",
                Amount = -7.99,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 31,
                Name = "Courses Auchant",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "encouple@gmail.com",
                Amount = 24.12,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 32,
                Name = "Remboursement resto soirée",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "encouple@gmail.com",
                Amount = 24.12,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 33,
                Name = "Verre en ville",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "copain@gmail.com",
                Amount = -7.30,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 34,
                Name = "Kebab",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "copain@gmail.com",
                Amount = -6.50,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 35,
                Name = "Cadeau Montre",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "wow@gmail.com",
                Amount = 120,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 36,
                Name = "Soirée Kebab",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "copain@gmail.com",
                Amount = -28,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 37,
                Name = "Salle de sport",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "workout@gmail.com",
                Amount = -16,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 38,
                Name = "Soiré ciné",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "copain@gmail.com",
                Amount = -12.50,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 39,
                Name = "Kebab",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "copain@gmail.com",
                Amount = -6.50,
                UserId = 1,
            });

            source.Add(new OperationEntity()
            {
                Id = 40,
                Name = "Rembousement pro",
                TransactionNumber = Guid.NewGuid().ToString(),
                RecipientEmail = "company@gmail.com",
                Amount = 50.50,
                UserId = 1,
            });

            return source;
        }


        #endregion
    }
}
