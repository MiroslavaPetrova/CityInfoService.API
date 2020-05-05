﻿// <auto-generated />
using CityInfoService.API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityInfoService.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20200505221547_SeedInitialData")]
    partial class SeedInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityInfoService.API.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 1, Description = "The one with the bluest sea.", Name = "Varna" },
                        new { Id = 2, Description = "The one with that big park.", Name = "New York City" },
                        new { Id = 3, Description = "The one with the bigest museum.", Name = "Paris" }
                    );
                });

            modelBuilder.Entity("CityInfoService.API.Models.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterests");

                    b.HasData(
                        new { Id = 1, CityId = 1, Description = "Тhe oldest technologically processed gold in the world.", Name = "Chalcolithic necropolis of Varna" },
                        new { Id = 2, CityId = 1, Description = "The largest church building in Varna and the third largest cathedral in Bulgaria.", Name = "Dormition of the Mother of God Cathedral" },
                        new { Id = 3, CityId = 2, Description = "A 102-story skyscraper located in Midtown Manhattan.", Name = "Empire State Building" },
                        new { Id = 4, CityId = 2, Description = "The most visited urban park in the United States.", Name = "Central Park" },
                        new { Id = 5, CityId = 3, Description = "The world's largest museum.", Name = "The Louvre" }
                    );
                });

            modelBuilder.Entity("CityInfoService.API.Models.PointOfInterest", b =>
                {
                    b.HasOne("CityInfoService.API.Models.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}