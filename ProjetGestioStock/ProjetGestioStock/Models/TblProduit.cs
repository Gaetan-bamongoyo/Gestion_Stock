using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetGestioStock.Models
{
    public partial class TblProduit
    {
        public int IdProduit { get; set; }
        public string Designation { get; set; }
        public double? PrixVente { get; set; }
        public DateTime? Dateday { get; set; }
    }
}
