﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250403113247_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Domain.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Domain.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entity.EmailVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailVerifications");
                });

            modelBuilder.Entity("Domain.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("integer");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entity.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Domain.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("SkinType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Entity.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entity.Cart", b =>
                {
                    b.HasOne("Domain.Entity.UserAccount", "UserAccount")
                        .WithOne("Cart")
                        .HasForeignKey("Domain.Entity.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Domain.Entity.CartItem", b =>
                {
                    b.HasOne("Domain.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entity.EmailVerification", b =>
                {
                    b.HasOne("Domain.Entity.UserAccount", "User")
                        .WithMany("EmailVerifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.Order", b =>
                {
                    b.HasOne("Domain.Entity.UserAccount", "UserAccount")
                        .WithMany("Order")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Domain.Entity.OrderDetail", b =>
                {
                    b.HasOne("Domain.Entity.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entity.Product", b =>
                {
                    b.HasOne("Domain.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entity.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Domain.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entity.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Domain.Entity.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Domain.Entity.UserAccount", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("EmailVerifications");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
