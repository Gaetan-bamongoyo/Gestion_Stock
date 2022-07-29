using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetGestioStock.Models
{
    public partial class TblEntre
    {
        public int IdEntre { get; set; }
        public int? Qte { get; set; }
        public double? Pu { get; set; }
        public DateTime? Dateexpiration { get; set; }
        public int Produit { get; set; }
        public DateTime? Dateday { get; set; }
        public int Fournisseur { get; set; }
        public string Designation { get; set; }
        public string NomFournisseur { get; set; }

    }
}
