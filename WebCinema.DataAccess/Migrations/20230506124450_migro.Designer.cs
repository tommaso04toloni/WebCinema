﻿// <auto-generated />
using System;
using WebCinema.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebCinema.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230506124450_migro")]
    partial class migro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "latin1");

            modelBuilder.Entity("WebCinema.Models.Categorie", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("categorie", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Film", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<int>("AnnoProduzione")
                        .HasColumnType("int(11)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Durata")
                        .HasColumnType("int(11)");

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Immagine")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("film", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Filmcategorie", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<uint>("Idcategoria")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDCategoria");

                    b.Property<uint>("Idfilm")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDFilm");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Idcategoria" }, "IDCategoria");

                    b.HasIndex(new[] { "Idfilm" }, "IDFilm");

                    b.ToTable("filmcategorie", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Posti", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<decimal>("Costo")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Fila")
                        .HasColumnType("int(11)");

                    b.Property<uint>("Idsala")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDSala");

                    b.Property<int>("Numero")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Idsala" }, "IDSala");

                    b.ToTable("posti", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Prenotazioni", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<uint>("Idposto")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDPosto");

                    b.Property<uint>("Idspettacolo")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDSpettacolo");

                    b.Property<uint>("Idutente")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDUtente");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Idposto" }, "IDPosto");

                    b.HasIndex(new[] { "Idspettacolo" }, "IDSpettacolo");

                    b.HasIndex(new[] { "Idutente" }, "IDUtente");

                    b.ToTable("prenotazioni", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Sale", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<ulong>("IsSense")
                        .HasColumnType("bit(1)");

                    b.Property<int>("NumeroSala")
                        .HasColumnType("int(11)");

                    b.Property<int>("PostiDisponibili")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("sale", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Spettacoli", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DataOra")
                        .HasColumnType("datetime");

                    b.Property<uint>("Idfilm")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDFilm");

                    b.Property<uint>("Idsala")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDSala");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Idfilm" }, "IDFilm")
                        .HasDatabaseName("IDFilm1");

                    b.HasIndex(new[] { "Idsala" }, "IDSala")
                        .HasDatabaseName("IDSala1");

                    b.ToTable("spettacoli", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Utenti", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ComuneResidenza")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly>("DataNascita")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sesso")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("utenti", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.Valutazioni", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("ID");

                    b.Property<uint>("Idfilm")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDFilm");

                    b.Property<uint>("Idutente")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("IDUtente");

                    b.Property<int>("Voto")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Idfilm" }, "IDFilm")
                        .HasDatabaseName("IDFilm2");

                    b.HasIndex(new[] { "Idutente" }, "IDUtente")
                        .HasDatabaseName("IDUtente1");

                    b.ToTable("valutazioni", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebCinema.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("WebCinema.Models.Filmcategorie", b =>
                {
                    b.HasOne("WebCinema.Models.Categorie", "IdcategoriaNavigation")
                        .WithMany("Filmcategories")
                        .HasForeignKey("Idcategoria")
                        .IsRequired()
                        .HasConstraintName("filmcategorie_ibfk_2");

                    b.HasOne("WebCinema.Models.Film", "IdfilmNavigation")
                        .WithMany("Filmcategories")
                        .HasForeignKey("Idfilm")
                        .IsRequired()
                        .HasConstraintName("filmcategorie_ibfk_1");

                    b.Navigation("IdcategoriaNavigation");

                    b.Navigation("IdfilmNavigation");
                });

            modelBuilder.Entity("WebCinema.Models.Posti", b =>
                {
                    b.HasOne("WebCinema.Models.Sale", "IdsalaNavigation")
                        .WithMany("Postis")
                        .HasForeignKey("Idsala")
                        .IsRequired()
                        .HasConstraintName("posti_ibfk_1");

                    b.Navigation("IdsalaNavigation");
                });

            modelBuilder.Entity("WebCinema.Models.Prenotazioni", b =>
                {
                    b.HasOne("WebCinema.Models.Posti", "IdpostoNavigation")
                        .WithMany("Prenotazionis")
                        .HasForeignKey("Idposto")
                        .IsRequired()
                        .HasConstraintName("prenotazioni_ibfk_3");

                    b.HasOne("WebCinema.Models.Spettacoli", "IdspettacoloNavigation")
                        .WithMany("Prenotazionis")
                        .HasForeignKey("Idspettacolo")
                        .IsRequired()
                        .HasConstraintName("prenotazioni_ibfk_2");

                    b.HasOne("WebCinema.Models.Utenti", "IdutenteNavigation")
                        .WithMany("Prenotazionis")
                        .HasForeignKey("Idutente")
                        .IsRequired()
                        .HasConstraintName("prenotazioni_ibfk_1");

                    b.Navigation("IdpostoNavigation");

                    b.Navigation("IdspettacoloNavigation");

                    b.Navigation("IdutenteNavigation");
                });

            modelBuilder.Entity("WebCinema.Models.Spettacoli", b =>
                {
                    b.HasOne("WebCinema.Models.Film", "IdfilmNavigation")
                        .WithMany("Spettacolis")
                        .HasForeignKey("Idfilm")
                        .IsRequired()
                        .HasConstraintName("spettacoli_ibfk_1");

                    b.HasOne("WebCinema.Models.Sale", "IdsalaNavigation")
                        .WithMany("Spettacolis")
                        .HasForeignKey("Idsala")
                        .IsRequired()
                        .HasConstraintName("spettacoli_ibfk_2");

                    b.Navigation("IdfilmNavigation");

                    b.Navigation("IdsalaNavigation");
                });

            modelBuilder.Entity("WebCinema.Models.Valutazioni", b =>
                {
                    b.HasOne("WebCinema.Models.Film", "IdfilmNavigation")
                        .WithMany("Valutazionis")
                        .HasForeignKey("Idfilm")
                        .IsRequired()
                        .HasConstraintName("valutazioni_ibfk_2");

                    b.HasOne("WebCinema.Models.Utenti", "IdutenteNavigation")
                        .WithMany("Valutazionis")
                        .HasForeignKey("Idutente")
                        .IsRequired()
                        .HasConstraintName("valutazioni_ibfk_1");

                    b.Navigation("IdfilmNavigation");

                    b.Navigation("IdutenteNavigation");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebCinema.Models.Categorie", b =>
                {
                    b.Navigation("Filmcategories");
                });

            modelBuilder.Entity("WebCinema.Models.Film", b =>
                {
                    b.Navigation("Filmcategories");

                    b.Navigation("Spettacolis");

                    b.Navigation("Valutazionis");
                });

            modelBuilder.Entity("WebCinema.Models.Posti", b =>
                {
                    b.Navigation("Prenotazionis");
                });

            modelBuilder.Entity("WebCinema.Models.Sale", b =>
                {
                    b.Navigation("Postis");

                    b.Navigation("Spettacolis");
                });

            modelBuilder.Entity("WebCinema.Models.Spettacoli", b =>
                {
                    b.Navigation("Prenotazionis");
                });

            modelBuilder.Entity("WebCinema.Models.Utenti", b =>
                {
                    b.Navigation("Prenotazionis");

                    b.Navigation("Valutazionis");
                });
#pragma warning restore 612, 618
        }
    }
}
