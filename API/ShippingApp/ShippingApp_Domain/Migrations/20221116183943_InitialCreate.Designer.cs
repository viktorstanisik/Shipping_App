﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingApp_Domain;

#nullable disable

namespace ShippingAppDomain.Migrations
{
    [DbContext(typeof(ShippingAppDbContext))]
    [Migration("20221116183943_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShippingApp_Domain.Entities.UserOffers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarrierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageDepth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageHeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageOfferPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageWidth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
