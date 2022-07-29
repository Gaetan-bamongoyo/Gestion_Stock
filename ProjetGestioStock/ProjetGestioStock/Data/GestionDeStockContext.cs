using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetGestioStock.Models;

#nullable disable

namespace ProjetGestioStock.Data
{
    public partial class GestionDeStockContext : DbContext
    {
        public GestionDeStockContext()
        {
        }

        public GestionDeStockContext(DbContextOptions<GestionDeStockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblClient> TblClients { get; set; }
        public virtual DbSet<TblCommande> TblCommandes { get; set; }
        public virtual DbSet<TblEntre> TblEntres { get; set; }
        public virtual DbSet<TblFournisseur> TblFournisseurs { get; set; }
        public virtual DbSet<TblProduit> TblProduits { get; set; }
        public virtual DbSet<TblSortie> TblSorties { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-694VQCK;Initial Catalog=GestionDeStock;User ID=sa;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__tbl_clie__6EC2B6C0C5E6EC9B");

                entity.ToTable("tbl_client");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.AdresseClient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("adresse_client");

                entity.Property(e => e.NomClient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom_client");

                entity.Property(e => e.PrenomClient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prenom_client");
            });

            modelBuilder.Entity<TblCommande>(entity =>
            {
                entity.HasKey(e => e.IdCommande)
                    .HasName("PK__tbl_comm__385131BFE32EB863");

                entity.ToTable("tbl_commande");

                entity.Property(e => e.IdCommande).HasColumnName("id_commande");

                entity.Property(e => e.NumeroCommande)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("numero_commande");
            });

            modelBuilder.Entity<TblEntre>(entity =>
            {
                entity.HasKey(e => e.IdEntre)
                    .HasName("PK__tbl_entr__8FC36219A2C4D1F2");

                entity.ToTable("tbl_entre");

                entity.Property(e => e.IdEntre).HasColumnName("id_entre");

                entity.Property(e => e.Dateday)
                    .HasColumnType("datetime")
                    .HasColumnName("dateday");

                entity.Property(e => e.Dateexpiration)
                    .HasColumnType("datetime")
                    .HasColumnName("dateexpiration");

                entity.Property(e => e.Fournisseur).HasColumnName("fournisseur");

                entity.Property(e => e.Produit).HasColumnName("produit");

                entity.Property(e => e.Pu).HasColumnName("pu");

                entity.Property(e => e.Qte).HasColumnName("qte");

                entity.Property(e => e.NomFournisseur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom_fournisseur");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("designation");

            });

            modelBuilder.Entity<TblFournisseur>(entity =>
            {
                entity.HasKey(e => e.IdFournisseur)
                    .HasName("PK__tbl_four__5B874F942E9A26BC");

                entity.ToTable("tbl_fournisseur");

                entity.Property(e => e.IdFournisseur).HasColumnName("id_fournisseur");

                entity.Property(e => e.AdresseFournisseur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("adresse_fournisseur");

                entity.Property(e => e.NomFournisseur)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom_fournisseur");

            });

            modelBuilder.Entity<TblProduit>(entity =>
            {
                entity.HasKey(e => e.IdProduit)
                    .HasName("PK__tbl_prod__BA39391B1077DF2F");

                entity.ToTable("tbl_produit");

                entity.Property(e => e.IdProduit).HasColumnName("id_produit");

                entity.Property(e => e.Dateday)
                    .HasColumnType("date")
                    .HasColumnName("dateday");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.PrixVente).HasColumnName("prix_vente");
            });

            modelBuilder.Entity<TblSortie>(entity =>
            {
                entity.HasKey(e => e.IdSortie)
                    .HasName("PK__tbl_sort__54920288B4089391");

                entity.ToTable("tbl_sortie");

                entity.Property(e => e.IdSortie).HasColumnName("id_sortie");

                entity.Property(e => e.Client).HasColumnName("client");

                entity.Property(e => e.Dateday)
                    .HasColumnType("datetime")
                    .HasColumnName("dateday");

                entity.Property(e => e.Montant).HasColumnName("montant");

                entity.Property(e => e.Produit).HasColumnName("produit");

                entity.Property(e => e.Qte).HasColumnName("qte");

                entity.Property(e => e.Designation)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("designation");

                entity.Property(e => e.NomClient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nom_client");

            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__tbl_user");

                entity.ToTable("tbl_user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
