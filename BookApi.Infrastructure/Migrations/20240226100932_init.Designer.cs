﻿// <auto-generated />
using System;
using BookApi.Infrastructure.Book.Persistence.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookApi.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240226100932_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Books")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookApi.Domain.Book.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Book", "Books");
                });

            modelBuilder.Entity("BookApi.Domain.Book.Book", b =>
                {
                    b.OwnsOne("BookApi.Domain.Book.Entities.Lending", "Lending", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ID");

                            b1.Property<DateTime>("LendingDate")
                                .HasPrecision(2, 2)
                                .HasColumnType("datetime2(2)");

                            b1.Property<DateTime>("Return")
                                .HasPrecision(2, 2)
                                .HasColumnType("datetime2(2)");

                            b1.HasKey("Id");

                            b1.ToTable("Lending", "Books");

                            b1.WithOwner("Book")
                                .HasForeignKey("Id");

                            b1.Navigation("Book");
                        });

                    b.OwnsOne("BookApi.Domain.Book.Entities.Stock", "Stock", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ID");

                            b1.Property<string>("Author")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("nvarchar");

                            b1.Property<string>("Description")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar");

                            b1.Property<string>("Genre")
                                .HasMaxLength(40)
                                .HasColumnType("nvarchar");

                            b1.Property<string>("Isbn")
                                .IsRequired()
                                .HasMaxLength(17)
                                .HasColumnType("char");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar");

                            b1.HasKey("Id");

                            b1.HasIndex("Isbn")
                                .IsUnique()
                                .HasDatabaseName("UK_Isbn");

                            SqlServerIndexBuilderExtensions.IsClustered(b1.HasIndex("Isbn"), false);

                            b1.ToTable("Stock", "Books");

                            b1.WithOwner("Book")
                                .HasForeignKey("Id");

                            b1.Navigation("Book");
                        });

                    b.Navigation("Lending")
                        .IsRequired();

                    b.Navigation("Stock")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
