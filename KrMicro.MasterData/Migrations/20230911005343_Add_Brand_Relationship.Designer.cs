﻿// <auto-generated />
using System;
using KrMicro.MasterData.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KrMicro.MasterData.Migrations
{
    [DbContext(typeof(MasterDataDbContext))]
    [Migration("20230911005343_Add_Brand_Relationship")]
    partial class Add_Brand_Relationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KrMicro.MasterData.Models.Asc", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short?>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("address");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_at");

                    b.Property<string>("Hotline")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("hotline");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Asc");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Brand", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short?>("Id"), 1L, 1);

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Category", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short?>("Id"), 1L, 1);

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Product", b =>
                {
                    b.Property<short?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short?>("Id"), 1L, 1);

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("FragranceDescription")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fragrance_description");

                    b.Property<string>("ImportFrom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("import_from");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)")
                        .HasColumnName("price");

                    b.Property<short>("ReleaseYear")
                        .HasColumnType("smallint")
                        .HasColumnName("release_year");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("style_description");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("updated_at");

                    b.Property<short>("brand_id")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("brand_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KrMicro.MasterData.Models.Product", b =>
                {
                    b.HasOne("KrMicro.MasterData.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("brand_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });
#pragma warning restore 612, 618
        }
    }
}
