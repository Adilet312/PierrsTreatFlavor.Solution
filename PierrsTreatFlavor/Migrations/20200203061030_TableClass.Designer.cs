﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PierrsTreatFlavor.Models;

namespace PierrsTreatFlavor.Migrations
{
    [DbContext(typeof(TreatFlavorContextDB))]
    [Migration("20200203061030_TableClass")]
    partial class TableClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PierrsTreatFlavor.Models.Flavor", b =>
                {
                    b.Property<int>("FlavorId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FlavorDateExpiration");

                    b.Property<string>("FlavorName");

                    b.Property<double>("FlavorPrice");

                    b.HasKey("FlavorId");

                    b.ToTable("Flavors");
                });

            modelBuilder.Entity("PierrsTreatFlavor.Models.Treat", b =>
                {
                    b.Property<int>("TreatId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("TreatBakedDate");

                    b.Property<string>("TreatName");

                    b.Property<string>("TreatType");

                    b.HasKey("TreatId");

                    b.ToTable("Treats");
                });

            modelBuilder.Entity("PierrsTreatFlavor.Models.TreatFlavor", b =>
                {
                    b.Property<int>("TreatFlavorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlavorId");

                    b.Property<int>("TreatId");

                    b.HasKey("TreatFlavorId");

                    b.HasIndex("FlavorId");

                    b.HasIndex("TreatId");

                    b.ToTable("TreatFlavors");
                });

            modelBuilder.Entity("PierrsTreatFlavor.Models.TreatFlavor", b =>
                {
                    b.HasOne("PierrsTreatFlavor.Models.Flavor", "Flavor")
                        .WithMany("Treats")
                        .HasForeignKey("FlavorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PierrsTreatFlavor.Models.Treat", "Treat")
                        .WithMany("Flavors")
                        .HasForeignKey("TreatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
