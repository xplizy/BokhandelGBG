using System;
using System.Collections.Generic;
using BokhandelGBG.Models;
using Microsoft.EntityFrameworkCore;

namespace BokhandelGBG.Data;

public partial class BokhandelDBContext : DbContext
{
    public BokhandelDBContext()
    {
    }

    public BokhandelDBContext(DbContextOptions<BokhandelDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Förlag> Förlags { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<LagerStatus> LagerStatuses { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bokhandel;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Butiker__3214EC27CF608227");

            entity.ToTable("Butiker");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Butiksnamn)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__Böcker__3BF79E036095685B");

            entity.ToTable("Böcker");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN13");
            entity.Property(e => e.FörfattareId).HasColumnName("FörfattareID");
            entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Språk)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Titel)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Utgivningsdatum).HasColumnType("date");

            entity.HasOne(d => d.Författare).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörfattareId)
                .HasConstraintName("FK__Böcker__Författa__267ABA7A");

            entity.HasMany(d => d.Förlags).WithMany(p => p.Isbns)
                .UsingEntity<Dictionary<string, object>>(
                    "BokFörlag",
                    r => r.HasOne<Förlag>().WithMany()
                        .HasForeignKey("FörlagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BokFörlag__Förla__36B12243"),
                    l => l.HasOne<Böcker>().WithMany()
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BokFörlag__ISBN__35BCFE0A"),
                    j =>
                    {
                        j.HasKey("Isbn", "FörlagId").HasName("PK__BokFörla__999B9EB9CD8DD297");
                        j.ToTable("BokFörlag");
                    });
        });

        modelBuilder.Entity<Författare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Författa__3214EC273577E4F4");

            entity.ToTable("Författare");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Efternamn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Födelsedatum).HasColumnType("date");
            entity.Property(e => e.Förnamn)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Förlag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Förlag__3214EC2781E2078D");

            entity.ToTable("Förlag");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Förlagsnam)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kunder__3214EC27A2EA265E");

            entity.ToTable("Kunder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Efternamn)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Förnamn)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LagerStatus>(entity =>
        {
            entity.HasKey(e => new { e.ButikId, e.Isbn }).HasName("PK__LagerSta__1191B8948D5CE6CE");

            entity.ToTable("LagerStatus");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.Butik).WithMany(p => p.LagerStatuses)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerStat__Butik__2B3F6F97");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerStatuses)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerStatu__ISBN__2C3393D0");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordrar__3214EC2798287976");

            entity.ToTable("Ordrar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.KundId).HasColumnName("KundID");

            entity.HasOne(d => d.Kund).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.KundId)
                .HasConstraintName("FK__Ordrar__KundID__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
