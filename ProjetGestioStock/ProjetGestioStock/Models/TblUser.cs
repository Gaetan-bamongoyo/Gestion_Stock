using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetGestioStock.Models
{
    public partial class TblUser
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
