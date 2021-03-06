﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaceSite.Models;

namespace RaceSite.Migrations
{
    [DbContext(typeof(RaceContext))]
    [Migration("20201203151001_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RaceSite.Models.Race", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("RaceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("ID");

                    b.ToTable("Race");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Traverse City",
                            RaceDate = new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RaceName = "Bayshore Marathon Half Marathon & 10K",
                            State = "MI"
                        },
                        new
                        {
                            ID = 2,
                            City = "Grand Rapids",
                            RaceDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RaceName = "Gazelle Girl Half Marathon 10K & 5K",
                            State = "MI"
                        },
                        new
                        {
                            ID = 3,
                            City = "Indianapolis",
                            RaceDate = new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RaceName = "Turkey Legs Trifecta & Half Marathon",
                            State = "IN"
                        },
                        new
                        {
                            ID = 4,
                            City = "Cocoa",
                            RaceDate = new DateTime(2021, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RaceName = "Space Coast Marathon",
                            State = "FL"
                        },
                        new
                        {
                            ID = 5,
                            City = "Jackson",
                            RaceDate = new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RaceName = "Grand Teton Half Marathon",
                            State = "WY"
                        });
                });

            modelBuilder.Entity("RaceSite.Models.RaceRegistrant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RaceID")
                        .HasColumnType("int");

                    b.Property<int>("RegistrantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RaceID");

                    b.HasIndex("RegistrantID");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("RaceSite.Models.Registrant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("ShoeId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("RaceId");

                    b.HasIndex("ShoeId");

                    b.ToTable("Registrant");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "100 Willow St.",
                            Age = 34,
                            City = "Traverse City",
                            Email = "runnerguy12@gmail.com",
                            FirstName = "Adam",
                            LastName = "Anderson",
                            PhoneNumber = "(231)123-2222",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "MI",
                            Zip = "49696"
                        },
                        new
                        {
                            ID = 2,
                            Address = "345 Park Ave.",
                            Age = 47,
                            City = "Clare",
                            Email = "maryh@gmail.com",
                            FirstName = "Mary",
                            LastName = "Hall",
                            PhoneNumber = "(231)123-2345",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "MI",
                            Zip = "49696"
                        },
                        new
                        {
                            ID = 3,
                            Address = "5687 Pine St.",
                            Age = 63,
                            City = "Inaianapolis",
                            Email = "bobtheman12@gmail.com",
                            FirstName = "Bob",
                            LastName = "Wilson",
                            PhoneNumber = "(231)123-3456",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "IN",
                            Zip = "46298"
                        },
                        new
                        {
                            ID = 4,
                            Address = "43 Bark Rd.",
                            Age = 26,
                            City = "Belleville",
                            Email = "runnersam56@gmail.com",
                            FirstName = "Sam",
                            LastName = "Richards",
                            PhoneNumber = "(231)123-4567",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "AR",
                            Zip = "72824"
                        },
                        new
                        {
                            ID = 5,
                            Address = "785 Washer Ln.",
                            Age = 51,
                            City = "Cocoa Beach",
                            Email = "claire543@gmail.com",
                            FirstName = "Claire",
                            LastName = "Rice",
                            PhoneNumber = "(231)123-5678",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "FL",
                            Zip = "32932"
                        },
                        new
                        {
                            ID = 6,
                            Address = "41 Stark Rd.",
                            Age = 19,
                            City = "Jackson",
                            Email = "alexb77@gmail.com",
                            FirstName = "Alex",
                            LastName = "Berkley",
                            PhoneNumber = "(231)123-6789",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "WY",
                            Zip = "83002"
                        },
                        new
                        {
                            ID = 7,
                            Address = "634 Ridge Hwy",
                            Age = 37,
                            City = "Kalkaska",
                            Email = "emmarunnergirl@gmail.com",
                            FirstName = "Emma",
                            LastName = "Rogers",
                            PhoneNumber = "(231)123-7891",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "MI",
                            Zip = "49646"
                        },
                        new
                        {
                            ID = 8,
                            Address = "790 Valley Rd",
                            Age = 49,
                            City = "Bude",
                            Email = "lanea1@gmail.com",
                            FirstName = "April",
                            LastName = "Lane",
                            PhoneNumber = "(231)123-8912",
                            RaceId = 1,
                            ShoeId = 2,
                            State = "MS",
                            Zip = "39630"
                        });
                });

            modelBuilder.Entity("RaceSite.Models.Shoe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Support")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Use")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Shoe");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Brand = "Brooks",
                            Name = "Ghost 13",
                            Support = "Neutral",
                            Use = "Road Running"
                        },
                        new
                        {
                            ID = 2,
                            Brand = "Hoka",
                            Name = "Tennine",
                            Support = "Stability",
                            Use = "Trail Running"
                        },
                        new
                        {
                            ID = 3,
                            Brand = "Saucany",
                            Name = "Triumph 17 LE",
                            Support = "Neutral",
                            Use = "Road Running"
                        },
                        new
                        {
                            ID = 4,
                            Brand = "Brooks",
                            Name = "Glycerin",
                            Support = "Neutral",
                            Use = "Road Running"
                        });
                });

            modelBuilder.Entity("RaceSite.Models.RaceRegistrant", b =>
                {
                    b.HasOne("RaceSite.Models.Race", "Race")
                        .WithMany("Registrant")
                        .HasForeignKey("RaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaceSite.Models.Registrant", "Registrant")
                        .WithMany("Races")
                        .HasForeignKey("RegistrantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RaceSite.Models.Registrant", b =>
                {
                    b.HasOne("RaceSite.Models.Race", "Race")
                        .WithMany("Registrants")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaceSite.Models.Shoe", "Shoe")
                        .WithMany("Registrants")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
