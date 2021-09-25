﻿// <auto-generated />
using System;
using MalikTraders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MalikTraders.Migrations
{
    [DbContext(typeof(MTDbContext))]
    partial class MTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MalikTraders.Models.AccDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PayingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("payedAmount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AccId");

                    b.ToTable("AccDetails");
                });

            modelBuilder.Entity("MalikTraders.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AmountPayable")
                        .HasColumnType("int");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClosingDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MTServicesid")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyInstalment")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.Property<bool>("isAccClosed")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("MTServicesid");

                    b.HasIndex("Userid");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MalikTraders.Models.MTServices", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MTServices");
                });

            modelBuilder.Entity("MalikTraders.Models.User", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("GUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MalikTraders.Models.UserDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registration_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("userDetails");
                });

            modelBuilder.Entity("MalikTraders.Models.AccDetails", b =>
                {
                    b.HasOne("MalikTraders.Models.Account", null)
                        .WithMany("AccPaymentDetails")
                        .HasForeignKey("AccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MalikTraders.Models.Account", b =>
                {
                    b.HasOne("MalikTraders.Models.MTServices", null)
                        .WithMany("Accounts")
                        .HasForeignKey("MTServicesid");

                    b.HasOne("MalikTraders.Models.User", null)
                        .WithMany("account")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MalikTraders.Models.User", b =>
                {
                    b.HasOne("MalikTraders.Models.UserDetails", "userDetailsId")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userDetailsId");
                });

            modelBuilder.Entity("MalikTraders.Models.Account", b =>
                {
                    b.Navigation("AccPaymentDetails");
                });

            modelBuilder.Entity("MalikTraders.Models.MTServices", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MalikTraders.Models.User", b =>
                {
                    b.Navigation("account");
                });
#pragma warning restore 612, 618
        }
    }
}