﻿// <auto-generated />
using System;
using FleetManagement_MW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetManagement_MW.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230902114511_done")]
    partial class done
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FleetManagement_MW.Models.AddOnMaster", b =>
                {
                    b.Property<long>("addOnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("addOnId"));

                    b.Property<string>("addOnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("addOnRate")
                        .HasColumnType("float");

                    b.Property<long>("carId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("rateValidity")
                        .HasColumnType("datetime2");

                    b.HasKey("addOnId");

                    b.HasIndex("carId");

                    b.ToTable("AddOnMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.AirportMaster", b =>
                {
                    b.Property<long>("airportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("airportId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("airportCode")
                        .HasColumnType("bigint");

                    b.Property<string>("airportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("cityId")
                        .HasColumnType("bigint");

                    b.Property<string>("closingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("hubId")
                        .HasColumnType("bigint");

                    b.Property<string>("openingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("stateId")
                        .HasColumnType("bigint");

                    b.HasKey("airportId");

                    b.HasIndex("cityId");

                    b.HasIndex("hubId");

                    b.HasIndex("stateId");

                    b.ToTable("AirportMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.BookingDetails", b =>
                {
                    b.Property<long>("bookingDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("bookingDetailsId"));

                    b.Property<long>("addOnId")
                        .HasColumnType("bigint");

                    b.Property<double>("addOnRate")
                        .HasColumnType("float");

                    b.Property<long>("bookingId")
                        .HasColumnType("bigint");

                    b.HasKey("bookingDetailsId");

                    b.HasIndex("addOnId");

                    b.HasIndex("bookingId");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.BookingHeaderReservation", b =>
                {
                    b.Property<long>("bookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("bookingId"));

                    b.Property<DateTime>("bookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("bookingEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("bookingStartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("carTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("custDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.Property<double>("dailyRate")
                        .HasColumnType("float");

                    b.Property<double>("monthlyRate")
                        .HasColumnType("float");

                    b.Property<double>("weeklyRate")
                        .HasColumnType("float");

                    b.HasKey("bookingId");

                    b.HasIndex("carTypeId");

                    b.HasIndex("customerId");

                    b.ToTable("BookingHeaderReservations");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CarMaster", b =>
                {
                    b.Property<long>("carId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("carId"));

                    b.Property<double>("carCurrentFuelStatus")
                        .HasColumnType("float");

                    b.Property<double>("carFuelCapacity")
                        .HasColumnType("float");

                    b.Property<long>("carTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("hubId")
                        .HasColumnType("bigint");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("maintenanceDueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("carId");

                    b.HasIndex("carTypeId");

                    b.HasIndex("hubId");

                    b.ToTable("CarMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CarTypeMaster", b =>
                {
                    b.Property<long>("carTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("carTypeId"));

                    b.Property<string>("carTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("dailyRate")
                        .HasColumnType("float");

                    b.Property<long>("hubId")
                        .HasColumnType("bigint");

                    b.Property<string>("imagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("monthlyRate")
                        .HasColumnType("float");

                    b.Property<double>("weeklyRate")
                        .HasColumnType("float");

                    b.HasKey("carTypeId");

                    b.HasIndex("hubId");

                    b.ToTable("CarTypeMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CityMaster", b =>
                {
                    b.Property<long>("cityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("cityId"));

                    b.Property<string>("cityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("stateId")
                        .HasColumnType("bigint");

                    b.HasKey("cityId");

                    b.HasIndex("stateId");

                    b.ToTable("CityMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CustomerMaster", b =>
                {
                    b.Property<long>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("customerId"));

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creditCardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dlIssuedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dlValidThrough")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("drivingLicence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passportIssuedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("passportValidUpto")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("CustomerMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.HubMaster", b =>
                {
                    b.Property<long>("hubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("hubId"));

                    b.Property<long>("cityId")
                        .HasColumnType("bigint");

                    b.Property<string>("hubAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hubPhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("openingHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("stateId")
                        .HasColumnType("bigint");

                    b.HasKey("hubId");

                    b.HasIndex("cityId");

                    b.HasIndex("stateId");

                    b.ToTable("HubMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.InvoiceDetailTableReturn", b =>
                {
                    b.Property<long>("invoiceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("invoiceDetailId"));

                    b.Property<double>("addOnAmt")
                        .HasColumnType("float");

                    b.Property<long>("addOnId")
                        .HasColumnType("bigint");

                    b.Property<long>("invoiceId")
                        .HasColumnType("bigint");

                    b.HasKey("invoiceDetailId");

                    b.HasIndex("addOnId");

                    b.HasIndex("invoiceId");

                    b.ToTable("InvoiceDetailTableReturns");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.InvoiceHeaderTableHandover", b =>
                {
                    b.Property<long>("invoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("invoiceId"));

                    b.Property<long>("bookingId")
                        .HasColumnType("bigint");

                    b.Property<long>("carId")
                        .HasColumnType("bigint");

                    b.Property<string>("customerDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("handoverDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("invoiceDate")
                        .HasColumnType("Date");

                    b.Property<double>("invoiceRate")
                        .HasColumnType("float");

                    b.Property<double>("rentalAmt")
                        .HasColumnType("float");

                    b.Property<DateTime>("returnDate")
                        .HasColumnType("Date");

                    b.Property<double>("totalAddonAmt")
                        .HasColumnType("float");

                    b.Property<double>("totalAmt")
                        .HasColumnType("float");

                    b.HasKey("invoiceId");

                    b.HasIndex("bookingId");

                    b.HasIndex("carId");

                    b.HasIndex("customerId");

                    b.ToTable("InvoiceHeaderTableHandovers");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.MembershipRegistration", b =>
                {
                    b.Property<long>("memRegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("memRegId"));

                    b.Property<long>("carTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("memRegId");

                    b.HasIndex("carTypeId");

                    b.HasIndex("customerId");

                    b.ToTable("MembershipRegistrations");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.StateMaster", b =>
                {
                    b.Property<long>("stateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("stateId"));

                    b.Property<string>("stateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stateId");

                    b.ToTable("StateMasters");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.AddOnMaster", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.CarMaster", "car")
                        .WithMany()
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.AirportMaster", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.CityMaster", "city")
                        .WithMany()
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.HubMaster", "hub")
                        .WithMany()
                        .HasForeignKey("hubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.StateMaster", "state")
                        .WithMany()
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("hub");

                    b.Navigation("state");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.BookingDetails", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.AddOnMaster", "addOn")
                        .WithMany()
                        .HasForeignKey("addOnId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.BookingHeaderReservation", "booking")
                        .WithMany()
                        .HasForeignKey("bookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("addOn");

                    b.Navigation("booking");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.BookingHeaderReservation", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.CarTypeMaster", "carType")
                        .WithMany()
                        .HasForeignKey("carTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.CustomerMaster", "cust")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("carType");

                    b.Navigation("cust");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CarMaster", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.CarTypeMaster", "carType")
                        .WithMany()
                        .HasForeignKey("carTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.HubMaster", "hub")
                        .WithMany()
                        .HasForeignKey("hubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("carType");

                    b.Navigation("hub");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CarTypeMaster", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.HubMaster", "hub")
                        .WithMany()
                        .HasForeignKey("hubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("hub");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.CityMaster", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.StateMaster", "state")
                        .WithMany()
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("state");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.HubMaster", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.CityMaster", "city")
                        .WithMany()
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.StateMaster", "state")
                        .WithMany()
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("state");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.InvoiceDetailTableReturn", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.AddOnMaster", "addOn")
                        .WithMany()
                        .HasForeignKey("addOnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.InvoiceHeaderTableHandover", "invoice")
                        .WithMany()
                        .HasForeignKey("invoiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("addOn");

                    b.Navigation("invoice");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.InvoiceHeaderTableHandover", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.BookingHeaderReservation", "booking")
                        .WithMany()
                        .HasForeignKey("bookingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.CarMaster", "car")
                        .WithMany()
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.CustomerMaster", "cust")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("booking");

                    b.Navigation("car");

                    b.Navigation("cust");
                });

            modelBuilder.Entity("FleetManagement_MW.Models.MembershipRegistration", b =>
                {
                    b.HasOne("FleetManagement_MW.Models.CarTypeMaster", "carType")
                        .WithMany()
                        .HasForeignKey("carTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FleetManagement_MW.Models.CustomerMaster", "cust")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("carType");

                    b.Navigation("cust");
                });
#pragma warning restore 612, 618
        }
    }
}
