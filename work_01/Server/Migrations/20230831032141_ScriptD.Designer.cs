﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using work_01.Server;

#nullable disable

namespace work_01.Server.Migrations
{
    [DbContext(typeof(TourDbContext))]
    [Migration("20230831032141_ScriptD")]
    partial class ScriptD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("work_01.Shared.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("work_01.Shared.Models.BookingItem", b =>
                {
                    b.Property<int>("BookingID")
                        .HasColumnType("int");

                    b.Property<int>("SpotID")
                        .HasColumnType("int");

                    b.Property<int>("Travelers")
                        .HasColumnType("int");

                    b.HasKey("BookingID", "SpotID");

                    b.HasIndex("SpotID");

                    b.ToTable("BookingItems");
                });

            modelBuilder.Entity("work_01.Shared.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("work_01.Shared.Models.Spot", b =>
                {
                    b.Property<int>("SpotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpotID"), 1L, 1);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("SpotName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SpotID");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("work_01.Shared.Models.Booking", b =>
                {
                    b.HasOne("work_01.Shared.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("work_01.Shared.Models.BookingItem", b =>
                {
                    b.HasOne("work_01.Shared.Models.Booking", "Booking")
                        .WithMany("BookingItems")
                        .HasForeignKey("BookingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("work_01.Shared.Models.Spot", "Spot")
                        .WithMany("BookingItems")
                        .HasForeignKey("SpotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("work_01.Shared.Models.Booking", b =>
                {
                    b.Navigation("BookingItems");
                });

            modelBuilder.Entity("work_01.Shared.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("work_01.Shared.Models.Spot", b =>
                {
                    b.Navigation("BookingItems");
                });
#pragma warning restore 612, 618
        }
    }
}