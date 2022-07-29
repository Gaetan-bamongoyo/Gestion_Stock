﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetGestioStock.Data;

namespace ProjetGestioStock.Migrations
{
    [DbContext(typeof(GestionDeStockContext))]
    [Migration("20220727112051_MaxLengthOnNames")]
    partial class MaxLengthOnNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "French_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ProjetGestioStock.Models.TblClient", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_client")
                        .UseIdentityColumn();

                    b.Property<string>("AdresseClient")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("adresse_client");

                    b.Property<string>("NomClient")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nom_client");

                    b.Property<string>("PrenomClient")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("prenom_client");

                    b.HasKey("IdClient")
                        .HasName("PK__tbl_clie__6EC2B6C0C5E6EC9B");

                    b.ToTable("tbl_client");
                });

            modelBuilder.Entity("ProjetGestioStock.Models.TblCommande", b =>
                {
                    b.Property<int>("IdCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_commande")
                        .UseIdentityColumn();

                    b.Property<string>("NumeroCommande")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("numero_commande");

                    b.HasKey("IdCommande")
                        .HasName("PK__tbl_comm__385131BFE32EB863");

                    b.ToTable("tbl_commande");
                });

            modelBuilder.Entity("ProjetGestioStock.Models.TblEntre", b =>
                {
                    b.Property<int>("IdEntre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_entre")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("Dateday")
                        .HasColumnType("datetime")
                        .HasColumnName("dateday");

                    b.Property<DateTime?>("Dateexpiration")
                        .HasColumnType("datetime")
                        .HasColumnName("dateexpiration");

                    b.Property<string>("Designation")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("designation");

                    b.Property<int>("Fournisseur")
                        .HasColumnType("int")
                        .HasColumnName("fournisseur");

                    b.Property<string>("NomFournisseur")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nom_fournisseur");

                    b.Property<int>("Produit")
                        .HasColumnType("int")
                        .HasColumnName("produit");

                    b.Property<double?>("Pu")
                        .HasColumnType("float")
                        .HasColumnName("pu");

                    b.Property<int?>("Qte")
                        .HasColumnType("int")
                        .HasColumnName("qte");

                    b.HasKey("IdEntre")
                        .HasName("PK__tbl_entr__8FC36219A2C4D1F2");

                    b.ToTable("tbl_entre");
                });

            modelBuilder.Entity("ProjetGestioStock.Models.TblFournisseur", b =>
                {
                    b.Property<int>("IdFournisseur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_fournisseur")
                        .UseIdentityColumn();

                    b.Property<string>("AdresseFournisseur")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("adresse_fournisseur");

                    b.Property<string>("NomFournisseur")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nom_fournisseur");

                    b.HasKey("IdFournisseur")
                        .HasName("PK__tbl_four__5B874F942E9A26BC");

                    b.ToTable("tbl_fournisseur");
                });

            modelBuilder.Entity("ProjetGestioStock.Models.TblProduit", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_produit")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("Dateday")
                        .HasColumnType("date")
                        .HasColumnName("dateday");

                    b.Property<string>("Designation")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("designation");

                    b.Property<double?>("PrixVente")
                        .HasColumnType("float")
                        .HasColumnName("prix_vente");

                    b.HasKey("IdProduit")
                        .HasName("PK__tbl_prod__BA39391B1077DF2F");

                    b.ToTable("tbl_produit");
                });

            modelBuilder.Entity("ProjetGestioStock.Models.TblSortie", b =>
                {
                    b.Property<int>("IdSortie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_sortie")
                        .UseIdentityColumn();

                    b.Property<int>("Client")
                        .HasColumnType("int")
                        .HasColumnName("client");

                    b.Property<DateTime?>("Dateday")
                        .HasColumnType("datetime")
                        .HasColumnName("dateday");

                    b.Property<double?>("Montant")
                        .HasColumnType("float")
                        .HasColumnName("montant");

                    b.Property<int>("Produit")
                        .HasColumnType("int")
                        .HasColumnName("produit");

                    b.Property<int?>("Qte")
                        .HasColumnType("int")
                        .HasColumnName("qte");

                    b.HasKey("IdSortie")
                        .HasName("PK__tbl_sort__54920288B4089391");

                    b.ToTable("tbl_sortie");
                });
#pragma warning restore 612, 618
        }
    }
}
