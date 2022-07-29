using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetGestioStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetGestioStock.ViewModel
{
    public class SelectItem
    {
        public TblEntre Entre { get; set; }
        public IEnumerable<SelectListItem> produit { get; set; }
    }
}
