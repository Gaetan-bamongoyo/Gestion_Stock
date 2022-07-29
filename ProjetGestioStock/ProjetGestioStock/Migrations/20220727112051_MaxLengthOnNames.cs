using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetGestioStock.Migrations
{
    public partial class MaxLengthOnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_client",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_client = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    prenom_client = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    adresse_client = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_clie__6EC2B6C0C5E6EC9B", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "tbl_commande",
                columns: table => new
                {
                    id_commande = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_commande = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_comm__385131BFE32EB863", x => x.id_commande);
                });

            migrationBuilder.CreateTable(
                name: "tbl_entre",
                columns: table => new
                {
                    id_entre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qte = table.Column<int>(type: "int", nullable: true),
                    pu = table.Column<double>(type: "float", nullable: true),
                    dateexpiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    produit = table.Column<int>(type: "int", nullable: false),
                    dateday = table.Column<DateTime>(type: "datetime", nullable: true),
                    fournisseur = table.Column<int>(type: "int", nullable: false),
                    designation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nom_fournisseur = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_entr__8FC36219A2C4D1F2", x => x.id_entre);
                });

            migrationBuilder.CreateTable(
                name: "tbl_fournisseur",
                columns: table => new
                {
                    id_fournisseur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_fournisseur = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    adresse_fournisseur = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_four__5B874F942E9A26BC", x => x.id_fournisseur);
                });

            migrationBuilder.CreateTable(
                name: "tbl_produit",
                columns: table => new
                {
                    id_produit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    prix_vente = table.Column<double>(type: "float", nullable: true),
                    dateday = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_prod__BA39391B1077DF2F", x => x.id_produit);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sortie",
                columns: table => new
                {
                    id_sortie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qte = table.Column<int>(type: "int", nullable: true),
                    montant = table.Column<double>(type: "float", nullable: true),
                    dateday = table.Column<DateTime>(type: "datetime", nullable: true),
                    produit = table.Column<int>(type: "int", nullable: false),
                    client = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_sort__54920288B4089391", x => x.id_sortie);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_client");

            migrationBuilder.DropTable(
                name: "tbl_commande");

            migrationBuilder.DropTable(
                name: "tbl_entre");

            migrationBuilder.DropTable(
                name: "tbl_fournisseur");

            migrationBuilder.DropTable(
                name: "tbl_produit");

            migrationBuilder.DropTable(
                name: "tbl_sortie");
        }
    }
}
