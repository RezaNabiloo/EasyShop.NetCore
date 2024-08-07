﻿// <auto-generated />
using System;
using BSG.EasyShop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSG.EasyShop.Persistence.Migrations
{
    [DbContext(typeof(EasyShopDbContext))]
    [Migration("20240702122922_Init-Database")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BSG.EasyShop.Domain.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "اپل"
                        },
                        new
                        {
                            Id = 2L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "سامسونگ"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Color", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ColorCode = "#FFF",
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "سفید"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "ایران"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Languege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Langueges");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDefault = true,
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalTitle = "پارسی",
                            Title = "پارسی"
                        },
                        new
                        {
                            Id = 2L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDefault = false,
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalTitle = "English",
                            Title = "انگلیسی"
                        },
                        new
                        {
                            Id = 3L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDefault = false,
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginalTitle = "العربیه",
                            Title = "عربی"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Discount")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OutOfSale")
                        .HasColumnType("bit");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BrandId = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            Discount = 0L,
                            IsActive = true,
                            IsConfirmed = true,
                            Keywords = "",
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OutOfSale = false,
                            Price = 1000L,
                            ProductGroupId = 2L,
                            ShortDescription = "",
                            Slug = "",
                            Title = "گوشی موبایل"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("ParentProductGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentProductGroupId");

                    b.ToTable("ProductGroups");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "کالای دیجیتال"
                        },
                        new
                        {
                            Id = 2L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParentProductGroupId = 1L,
                            Title = "گوشی موبایل"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductGroupSize", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ProductGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("ProductGroupSizes");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductGroupTechSpec", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ProductGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("ProductGroupTechSpecs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataType = 1,
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductGroupId = 2L,
                            Title = "وزن",
                            ViewOrder = 1
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePathFingerSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePathNormalSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePathOriginalSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePathThumbnailSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("ViewOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductTechSpec", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ProductGroupTechSpecId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("TechSpecValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupTechSpecId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTechSpecs");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Province", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CountryId = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "تهران"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Township", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCapital")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lng")
                        .HasColumnType("float");

                    b.Property<long>("ProvinceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Townships");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCapital = true,
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lat = 35.721899999999998,
                            Lng = 51.334699999999998,
                            ProvinceId = 1L,
                            Title = "Title"
                        });
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Product", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("BSG.EasyShop.Domain.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductGroup", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.ProductGroup", "ParentProductGroup")
                        .WithMany()
                        .HasForeignKey("ParentProductGroupId");

                    b.Navigation("ParentProductGroup");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductGroupSize", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductGroupTechSpec", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductImage", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.ProductTechSpec", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.ProductGroupTechSpec", "ProductGroupTechSpec")
                        .WithMany()
                        .HasForeignKey("ProductGroupTechSpecId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BSG.EasyShop.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductGroupTechSpec");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Province", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BSG.EasyShop.Domain.Township", b =>
                {
                    b.HasOne("BSG.EasyShop.Domain.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });
#pragma warning restore 612, 618
        }
    }
}
