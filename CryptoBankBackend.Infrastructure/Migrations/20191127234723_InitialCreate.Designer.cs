﻿// <auto-generated />
using System;
using CryptoBankBackend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CryptoBankBackend.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191127234723_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CryptoBankBackend.Core.Models.Entities.OperationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Operation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = -466.54000000000002,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(3162), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Argent pour OnePlus 5T",
                            RecipientEmail = "maman@gmail.com",
                            TransactionNumber = "013f5f8a-ac32-40c9-add2-cf072a860daf",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = -466.54000000000002,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5478), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Remboursement des courses Auchant",
                            RecipientEmail = "copine@gmail.com",
                            TransactionNumber = "de8c8198-4163-45f3-8f2c-bcbc78cb75e7",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = -12.01,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5532), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Tomate et citronade",
                            RecipientEmail = "mamy@gmail.com",
                            TransactionNumber = "d9da389c-7fbd-4a13-aaab-fe703915f39d",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Amount = -7.29,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5536), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Bière entre poto",
                            RecipientEmail = "benjamin@gmail.com",
                            TransactionNumber = "033d925c-0772-492c-a4c3-202624e00ee1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            Amount = -10.5,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5540), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Bière entre poto",
                            RecipientEmail = "timothee@gmail.com",
                            TransactionNumber = "f45d8db4-a9a0-4693-996e-094d25526182",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = -5.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Bière entre poto",
                            RecipientEmail = "jon@gmail.com",
                            TransactionNumber = "d8510f66-3253-40d3-b665-fe317cb84771",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Amount = -594.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Voyage Argentine",
                            RecipientEmail = "manon@gmail.com",
                            TransactionNumber = "c325c285-24ee-4a6b-9bf5-8a2a554ef7bd",
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            Amount = -84.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5562), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Nourriture Lecler courses",
                            RecipientEmail = "aurore@gmail.com",
                            TransactionNumber = "94b66912-df42-4f7e-8ccc-8ceb59ab7158",
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            Amount = -2.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5565), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Café pause boulot",
                            RecipientEmail = "collegue@gmail.com",
                            TransactionNumber = "017206d6-41ed-42fd-8d8d-911036b357a7",
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            Amount = -2.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5570), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Encore un autre café pause boulot",
                            RecipientEmail = "collegue_sympa@gmail.com",
                            TransactionNumber = "ad2f9a30-a9a4-46ca-9002-c900fa9b1969",
                            UserId = 1
                        },
                        new
                        {
                            Id = 11,
                            Amount = -2.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5573), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Encore Encore un autre café pause boulot",
                            RecipientEmail = "collegue_sympa_2@gmail.com",
                            TransactionNumber = "2d7c1866-bd26-4063-aa80-28e95a6cdc11",
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            Amount = -8.0,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 263, DateTimeKind.Unspecified).AddTicks(5577), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "En route vers la promotion en offrant une biere au patron",
                            RecipientEmail = "patron@gmail.com",
                            TransactionNumber = "af063b8f-f721-48e5-b3b4-c72bf70a19c1",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("CryptoBankBackend.Core.Models.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Credits")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 11, 27, 23, 47, 23, 261, DateTimeKind.Unspecified).AddTicks(4590), new TimeSpan(0, 0, 0, 0, 0)),
                            Credits = 2265.0,
                            Email = "stephan.arnas@gmail.com",
                            FirstName = "Stephan",
                            LastName = "Arnas",
                            Password = "Aze123"
                        });
                });

            modelBuilder.Entity("CryptoBankBackend.Core.Models.Entities.OperationEntity", b =>
                {
                    b.HasOne("CryptoBankBackend.Core.Models.Entities.UserEntity", "User")
                        .WithMany("Operations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}