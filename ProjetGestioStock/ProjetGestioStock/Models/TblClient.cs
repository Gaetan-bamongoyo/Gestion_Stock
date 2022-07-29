using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetGestioStock.Models
{
    public partial class TblClient
    {
        public int IdClient { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public string AdresseClient { get; set; }
    }
}
