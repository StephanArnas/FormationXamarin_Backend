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


            return source;
        }


        #endregion
    }
}
