﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SisComWebApi.Data;

namespace SisComWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210413112809_CreatedNewEntities")]
    partial class CreatedNewEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SisComWebApi.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<string>("Block")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Complement")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SisComWebApi.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Agency")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("BankName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("BankNumber")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("SisComWebApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SisComWebApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BuyLimit")
                        .HasColumnType("float");

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Contact")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipalRegistration")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("StateRegistration")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SisComWebApi.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("SisComWebApi.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Percent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Since")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("SisComWebApi.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PhoneType")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("SisComWebApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AdditionsPercent")
                        .HasColumnType("float");

                    b.Property<string>("BarCode")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Cfop")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<string>("FiscalClassification")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("IcmsPercent")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IpiPercent")
                        .HasColumnType("float");

                    b.Property<DateTime>("LastBuyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastSaleDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("MaximumStock")
                        .HasColumnType("float");

                    b.Property<string>("Measures")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("MinimumStock")
                        .HasColumnType("float");

                    b.Property<double>("Multiple")
                        .HasColumnType("float");

                    b.Property<double>("Mva")
                        .HasColumnType("float");

                    b.Property<string>("NatOper")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Reference")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("ShippingPercent")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Stock")
                        .HasColumnType("float");

                    b.Property<string>("SupplierCode")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<bool>("TaxSubstitution")
                        .HasColumnType("bit");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("UnitBuyPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SisComWebApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BuyLimit")
                        .HasColumnType("float");

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Contact")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipalRegistration")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("StateRegistration")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SupplierType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SisComWebApi.Models.Address", b =>
                {
                    b.HasOne("SisComWebApi.Models.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisComWebApi.Models.Supplier", "Supplier")
                        .WithMany("Addresses")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SisComWebApi.Models.BankAccount", b =>
                {
                    b.HasOne("SisComWebApi.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisComWebApi.Models.Supplier", "Supplier")
                        .WithMany("BankAccounts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SisComWebApi.Models.Document", b =>
                {
                    b.HasOne("SisComWebApi.Models.Partner", "Partner")
                        .WithMany("Documents")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("SisComWebApi.Models.Partner", b =>
                {
                    b.HasOne("SisComWebApi.Models.Customer", "Customer")
                        .WithMany("Partners")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SisComWebApi.Models.Supplier", "Supplier")
                        .WithMany("Partners")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SisComWebApi.Models.Phone", b =>
                {
                    b.HasOne("SisComWebApi.Models.Customer", null)
                        .WithMany("Phones")
                        .HasForeignKey("CustomerId");

                    b.HasOne("SisComWebApi.Models.Supplier", "Supplier")
                        .WithMany("Phones")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SisComWebApi.Models.Product", b =>
                {
                    b.HasOne("SisComWebApi.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("SisComWebApi.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SisComWebApi.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SisComWebApi.Models.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Partners");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("SisComWebApi.Models.Partner", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("SisComWebApi.Models.Supplier", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("BankAccounts");

                    b.Navigation("Partners");

                    b.Navigation("Phones");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
