﻿// <auto-generated />
using IdentityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IdentityApp.Models.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230311174830_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdentityApp.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Category = "Watersports",
                            Name = "Kayak",
                            Price = 275m
                        },
                        new
                        {
                            Id = 2L,
                            Category = "Watersports",
                            Name = "Lifejacket",
                            Price = 48.95m
                        },
                        new
                        {
                            Id = 3L,
                            Category = "Soccer",
                            Name = "Soccer Ball",
                            Price = 19.50m
                        },
                        new
                        {
                            Id = 4L,
                            Category = "Soccer",
                            Name = "Corner Flags",
                            Price = 34.95m
                        },
                        new
                        {
                            Id = 5L,
                            Category = "Soccer",
                            Name = "Stadium",
                            Price = 79500m
                        },
                        new
                        {
                            Id = 6L,
                            Category = "Chess",
                            Name = "Thinking Cap",
                            Price = 16m
                        },
                        new
                        {
                            Id = 7L,
                            Category = "Chess",
                            Name = "Unsteady Chair",
                            Price = 29.95m
                        },
                        new
                        {
                            Id = 8L,
                            Category = "Chess",
                            Name = "Human Chess Board",
                            Price = 75m
                        },
                        new
                        {
                            Id = 9L,
                            Category = "Chess",
                            Name = "Bling-Bling King",
                            Price = 1200m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
