﻿// <auto-generated />
using System;
using KrMicro.MasterData.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KrMicro.MasterData.Migrations
{
    [DbContext(typeof(MasterDataDbContext))]
    partial class MasterDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KrMicro.MasterData.Models.Asc", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short?>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("Address");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Hotline")
                        .HasColumnType("text")
                        .HasColumnName("Hotline");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Asc");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Brand", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short?>("Id"));

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Category", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short?>("Id"));

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.DeliveryVendor", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short?>("Id"));

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<decimal>("Fee")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("DeliveryVendors");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Product", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short?>("Id"));

                    b.Property<short?>("BrandId")
                        .HasColumnType("smallint");

                    b.Property<short?>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("FragranceDescription")
                        .HasColumnType("text")
                        .HasColumnName("FragranceDescription");

                    b.Property<string>("ImageUrls")
                        .HasColumnType("text")
                        .HasColumnName("ImageUrls");

                    b.Property<string>("ImportFrom")
                        .HasColumnType("text")
                        .HasColumnName("ImportFrom");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<short?>("ReleaseYear")
                        .HasColumnType("smallint")
                        .HasColumnName("ReleaseYear");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<string>("Style")
                        .HasColumnType("text")
                        .HasColumnName("StyleDescription");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.ProductSize", b =>
                {
                    b.Property<short>("SizeId")
                        .HasColumnType("smallint");

                    b.Property<short>("ProductId")
                        .HasColumnType("smallint");

                    b.Property<short?>("Id")
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    b.Property<decimal>("Price")
                        .HasPrecision(16, 2)
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Stock")
                        .HasColumnType("integer")
                        .HasColumnName("Stock");

                    b.HasKey("SizeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSize");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Size", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short?>("Id"));

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("SizeCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("SizeCode");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Product", b =>
                {
                    b.HasOne("KrMicro.MasterData.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("KrMicro.MasterData.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.ProductSize", b =>
                {
                    b.HasOne("KrMicro.MasterData.Models.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KrMicro.MasterData.Models.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Product", b =>
                {
                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Size", b =>
                {
                    b.Navigation("ProductSizes");
                });
#pragma warning restore 612, 618
        }
    }
}
