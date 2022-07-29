using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetGestioStock.Models
{
    public partial class TblSortie
    {
        public int IdSortie { get; set; }
        public int? Qte { get; set; }
        public double? Montant { get; set; }
        public DateTime? Dateday { get; set; }
        public int Produit { get; set; }
        public int Client { get; set; }
        public string Designation { get; set; }
        public string NomClient { get; set; }
    }
}
