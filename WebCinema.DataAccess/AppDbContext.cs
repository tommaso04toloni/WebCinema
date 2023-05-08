using System;
using System.Collections.Generic;
using WebCinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebCinema.DataAccess;

public partial class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Film> Films { get; set; }


    public virtual DbSet<Posti> Postis { get; set; }

    public virtual DbSet<Prenotazioni> Prenotazionis { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Spettacoli> Spettacolis { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    public virtual DbSet<Valutazioni> Valutazionis { get; set; }

    public virtual DbSet<OrdineBiglietti> OrdineBiglietti { get; set; } = null!;


    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("film");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.AnnoProduzione).HasColumnType("int(11)");
            entity.Property(e => e.Descrizione).HasMaxLength(500);
            entity.Property(e => e.Durata).HasColumnType("int(11)");
            entity.Property(e => e.Genere).HasMaxLength(50);
            entity.Property(e => e.Immagine).HasMaxLength(200);
            entity.Property(e => e.Titolo).HasMaxLength(100);
        });

        modelBuilder.Entity<Posti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("posti");

            entity.HasIndex(e => e.Idsala, "IDSala");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Costo).HasPrecision(5, 2);
            entity.Property(e => e.Fila).HasColumnType("int(11)");
            entity.Property(e => e.Idsala)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDSala");
            entity.Property(e => e.Numero).HasColumnType("int(11)");

            entity.HasOne(d => d.IdsalaNavigation).WithMany(p => p.Postis)
                .HasForeignKey(d => d.Idsala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("posti_ibfk_1");
        });

        modelBuilder.Entity<Prenotazioni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("prenotazioni");

            entity.HasIndex(e => e.Idposto, "IDPosto");

            entity.HasIndex(e => e.Idspettacolo, "IDSpettacolo");

            entity.HasIndex(e => e.Idutente, "IDUtente");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Idposto)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDPosto");
            entity.Property(e => e.Idspettacolo)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDSpettacolo");
            entity.Property(e => e.Idutente)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDUtente");

            entity.HasOne(d => d.IdpostoNavigation).WithMany(p => p.Prenotazionis)
                .HasForeignKey(d => d.Idposto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prenotazioni_ibfk_3");

            entity.HasOne(d => d.IdspettacoloNavigation).WithMany(p => p.Prenotazionis)
                .HasForeignKey(d => d.Idspettacolo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prenotazioni_ibfk_2");

            entity.HasOne(d => d.IdutenteNavigation).WithMany(p => p.Prenotazionis)
                .HasForeignKey(d => d.Idutente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prenotazioni_ibfk_1");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sale");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.IsSense).HasColumnType("bit(1)");
            entity.Property(e => e.NumeroSala).HasColumnType("int(11)");
            entity.Property(e => e.PostiDisponibili).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Spettacoli>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("spettacoli");

            entity.HasIndex(e => e.Idfilm, "IDFilm");

            entity.HasIndex(e => e.Idsala, "IDSala");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.DataOra).HasColumnType("datetime");
            entity.Property(e => e.Idfilm)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDFilm");
            entity.Property(e => e.Idsala)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDSala");

            entity.HasOne(d => d.IdfilmNavigation).WithMany(p => p.Spettacolis)
                .HasForeignKey(d => d.Idfilm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("spettacoli_ibfk_1");

            entity.HasOne(d => d.IdsalaNavigation).WithMany(p => p.Spettacolis)
                .HasForeignKey(d => d.Idsala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("spettacoli_ibfk_2");
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("utenti");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.ComuneResidenza).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Sesso)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<Valutazioni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("valutazioni");

            entity.HasIndex(e => e.Idfilm, "IDFilm");

            entity.HasIndex(e => e.Idutente, "IDUtente");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Idfilm)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDFilm");
            entity.Property(e => e.Idutente)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("IDUtente");
            entity.Property(e => e.Voto).HasColumnType("int(11)");

            entity.HasOne(d => d.IdfilmNavigation).WithMany(p => p.Valutazionis)
                .HasForeignKey(d => d.Idfilm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("valutazioni_ibfk_2");

            entity.HasOne(d => d.IdutenteNavigation).WithMany(p => p.Valutazionis)
                .HasForeignKey(d => d.Idutente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("valutazioni_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
