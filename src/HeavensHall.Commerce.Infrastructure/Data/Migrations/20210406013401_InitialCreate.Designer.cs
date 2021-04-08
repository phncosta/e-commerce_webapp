﻿// <auto-generated />
using System;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HeavensHall.Commerce.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210406013401_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address_1")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address_1");

                    b.Property<string>("Address_2")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address_2");

                    b.Property<string>("City")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(60)")
                        .HasColumnName("country");

                    b.Property<string>("Postal_Code")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("postal_code");

                    b.Property<string>("State")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("state");

                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Corda"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Percursão"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sopro"
                        });
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Creation_Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("creation_date");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric")
                        .HasColumnName("discount");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("status");

                    b.Property<decimal>("Total_Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amout");

                    b.Property<int>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int?>("payment_id")
                        .HasColumnType("integer");

                    b.Property<int?>("shipping_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("payment_id");

                    b.HasIndex("shipping_id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Payment_Method_IdId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Payment_Method_IdId");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("payment_methods");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int?>("brand_id")
                        .HasColumnType("integer");

                    b.Property<int?>("category_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("brand_id");

                    b.HasIndex("category_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("color");

                    b.Property<float>("Rating")
                        .HasColumnType("REAL")
                        .HasColumnName("rating");

                    b.Property<int?>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("product_details");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Main")
                        .HasColumnType("boolean")
                        .HasColumnName("main");

                    b.Property<string>("Path")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("path");

                    b.Property<int?>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("product_images");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Billing_Address_Id")
                        .HasColumnType("integer")
                        .HasColumnName("billing_address_id");

                    b.Property<int>("Shipping_Address_Id")
                        .HasColumnType("integer")
                        .HasColumnName("shipping_address_id");

                    b.Property<decimal>("Shipping_Charge")
                        .HasColumnType("numeric")
                        .HasColumnName("shipping_charge");

                    b.HasKey("Id");

                    b.ToTable("shippings");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<int?>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("stock");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Order", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("payment_id");

                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Shipping", "Shipping")
                        .WithMany()
                        .HasForeignKey("shipping_id");

                    b.Navigation("Payment");

                    b.Navigation("Shipping");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Payment", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Domain.Entities.PaymentMethod", "Payment_Method_Id")
                        .WithMany()
                        .HasForeignKey("Payment_Method_IdId");

                    b.Navigation("Payment_Method_Id");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Product", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("brand_id");

                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("category_id");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HeavensHall.Commerce.Domain.Entities.Stock", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeavensHall.Commerce.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HeavensHall.Commerce.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
