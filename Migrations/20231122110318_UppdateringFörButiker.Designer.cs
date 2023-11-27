﻿// <auto-generated />
using System;
using BokhandelGBG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BokhandelGBG.Migrations
{
    [DbContext(typeof(BokhandelDBContext))]
    [Migration("20231122110318_UppdateringFörButiker")]
    partial class UppdateringFörButiker
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BokFörlag", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("FörlagId")
                        .HasColumnType("int");

                    b.HasKey("Isbn", "FörlagId")
                        .HasName("PK__BokFörla__999B9EB9CD8DD297");

                    b.HasIndex("FörlagId");

                    b.ToTable("BokFörlag", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.Butiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Butiksnamn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Butiker__3214EC27CF608227");

                    b.ToTable("Butiker", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.Böcker", b =>
                {
                    b.Property<string>("Isbn13")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ISBN13");

                    b.Property<int?>("FörfattareId")
                        .HasColumnType("int")
                        .HasColumnName("FörfattareID");

                    b.Property<decimal?>("Pris")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Språk")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Titel")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Utgivningsdatum")
                        .HasColumnType("date");

                    b.HasKey("Isbn13")
                        .HasName("PK__Böcker__3BF79E036095685B");

                    b.HasIndex("FörfattareId");

                    b.ToTable("Böcker", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.Författare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Efternamn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Födelsedatum")
                        .HasColumnType("date");

                    b.Property<string>("Förnamn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Författa__3214EC273577E4F4");

                    b.ToTable("Författare", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.Förlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Förlagsnam")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Förlag__3214EC2781E2078D");

                    b.ToTable("Förlag", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.Kunder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Efternamn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Förnamn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Kunder__3214EC27A2EA265E");

                    b.ToTable("Kunder", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.LagerStatus", b =>
                {
                    b.Property<int>("ButikId")
                        .HasColumnType("int")
                        .HasColumnName("ButikID");

                    b.Property<string>("Isbn")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ISBN");

                    b.Property<int?>("Antal")
                        .HasColumnType("int");

                    b.HasKey("ButikId", "Isbn")
                        .HasName("PK__LagerSta__1191B8948D5CE6CE");

                    b.HasIndex("Isbn");

                    b.ToTable("LagerStatus", (string)null);
                });

            modelBuilder.Entity("BokhandelGBG.Models.Ordrar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("date");

                    b.Property<int?>("KundId")
                        .HasColumnType("int")
                        .HasColumnName("KundID");

                    b.HasKey("Id")
                        .HasName("PK__Ordrar__3214EC2798287976");

                    b.HasIndex("KundId");

                    b.ToTable("Ordrar", (string)null);
                });

            modelBuilder.Entity("BokFörlag", b =>
                {
                    b.HasOne("BokhandelGBG.Models.Förlag", null)
                        .WithMany()
                        .HasForeignKey("FörlagId")
                        .IsRequired()
                        .HasConstraintName("FK__BokFörlag__Förla__36B12243");

                    b.HasOne("BokhandelGBG.Models.Böcker", null)
                        .WithMany()
                        .HasForeignKey("Isbn")
                        .IsRequired()
                        .HasConstraintName("FK__BokFörlag__ISBN__35BCFE0A");
                });

            modelBuilder.Entity("BokhandelGBG.Models.Böcker", b =>
                {
                    b.HasOne("BokhandelGBG.Models.Författare", "Författare")
                        .WithMany("Böckers")
                        .HasForeignKey("FörfattareId")
                        .HasConstraintName("FK__Böcker__Författa__267ABA7A");

                    b.Navigation("Författare");
                });

            modelBuilder.Entity("BokhandelGBG.Models.LagerStatus", b =>
                {
                    b.HasOne("BokhandelGBG.Models.Butiker", "Butik")
                        .WithMany("LagerStatuses")
                        .HasForeignKey("ButikId")
                        .IsRequired()
                        .HasConstraintName("FK__LagerStat__Butik__2B3F6F97");

                    b.HasOne("BokhandelGBG.Models.Böcker", "IsbnNavigation")
                        .WithMany("LagerStatuses")
                        .HasForeignKey("Isbn")
                        .IsRequired()
                        .HasConstraintName("FK__LagerStatu__ISBN__2C3393D0");

                    b.Navigation("Butik");

                    b.Navigation("IsbnNavigation");
                });

            modelBuilder.Entity("BokhandelGBG.Models.Ordrar", b =>
                {
                    b.HasOne("BokhandelGBG.Models.Kunder", "Kund")
                        .WithMany("Ordrars")
                        .HasForeignKey("KundId")
                        .HasConstraintName("FK__Ordrar__KundID__30F848ED");

                    b.Navigation("Kund");
                });

            modelBuilder.Entity("BokhandelGBG.Models.Butiker", b =>
                {
                    b.Navigation("LagerStatuses");
                });

            modelBuilder.Entity("BokhandelGBG.Models.Böcker", b =>
                {
                    b.Navigation("LagerStatuses");
                });

            modelBuilder.Entity("BokhandelGBG.Models.Författare", b =>
                {
                    b.Navigation("Böckers");
                });

            modelBuilder.Entity("BokhandelGBG.Models.Kunder", b =>
                {
                    b.Navigation("Ordrars");
                });
#pragma warning restore 612, 618
        }
    }
}
