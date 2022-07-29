using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetGestioStock.Data;
using ProjetGestioStock.Models;

namespace ProjetGestioStock.Controllers
{
    public class SortiesController : Controller
    {
        private readonly GestionDeStockContext _context;

        public SortiesController(GestionDeStockContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Month()
        {
            string query = "SELECT id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client Where (SELECT (DATENAME(month, tbl_sortie.dateday)) AS mois ) = (SELECT DATENAME(month, GETDATE()) ); ";

            List<TblSortie> sorties = _context.TblSorties.FromSqlRaw(query).ToList();

            return View(sorties);
        }
        public async Task<IActionResult> Day()
        {
            //string querie = "SELECT sum(montant) as montant from tbl_sortie Where (SELECT (CONVERT(DATE, dateday)) AS dateA ) = (SELECT CONVERT(DATE, GETDATE()) dateDay1)";

            //TblSortie tblSortie = await _context.TblSorties.FromSqlRaw(querie).ToList();

            string query = "SELECT id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client Where (SELECT (CONVERT(DATE, tbl_sortie.dateday)) AS dateA ) = (SELECT CONVERT(DATE, GETDATE()) dateDay1); ";

            List<TblSortie> sorties = _context.TblSorties.FromSqlRaw(query).ToList();

            //ViewBag.Somme = tblSortie;

            return View(sorties);
        }
        // GET: Sorties
        public async Task<IActionResult> Index()
        {
            string query = "select id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client";

            List<TblSortie> sorties = _context.TblSorties.FromSqlRaw(query).ToList();

            return View(sorties);
        }

        // GET: Sorties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "select id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client WHERE id_sortie = @p0";

            List<TblSortie> tblSortie = _context.TblSorties.FromSqlRaw(query, id).ToList();

            if (tblSortie == null)
            {
                return NotFound();
            }

            return View(tblSortie);
        }
        public List<TblProduit> GetProduitList()
        {
            List<TblProduit> produit = _context.TblProduits.ToList();
            return produit;
        }
        public List<TblClient> GetClientList()
        {
            List<TblClient> client = _context.TblClients.ToList();
            return client;
        }

        // GET: Sorties/Create
        public IActionResult Create()
        {
            ViewBag.ProduitList = new SelectList(GetProduitList(), "IdProduit", "Designation");
            ViewBag.ClientList = new SelectList(GetClientList(), "IdClient", "NomClient");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSortie,Qte,Montant,Dateday,Produit,Client")] TblSortie tblSortie)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("addNewSortie {0},{1},{2},{3}", tblSortie.Qte,tblSortie.Dateday, tblSortie.Produit, tblSortie.Client);
                //_context.Add(tblSortie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSortie);
        }

        // GET: Sorties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "select id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client WHERE id_sortie = @p0";

            TblSortie tblSortie = await _context.TblSorties.FromSqlRaw(query, id).SingleOrDefaultAsync();
            if (tblSortie == null)
            {
                return NotFound();
            }
            ViewBag.ProduitList = new SelectList(GetProduitList(), "IdProduit", "Designation");
            ViewBag.ClientList = new SelectList(GetClientList(), "IdClient", "NomClient");
            return View(tblSortie);
        }

        // POST: Sorties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSortie,Qte,Montant,Dateday,Produit,Client")] TblSortie tblSortie)
        {
            if (id != tblSortie.IdSortie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSortie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSortieExists(tblSortie.IdSortie))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblSortie);
        }

        // GET: Sorties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "select id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client WHERE id_sortie = @p0";

            TblSortie tblSortie = await _context.TblSorties.FromSqlRaw(query, id).SingleOrDefaultAsync();

            if (tblSortie == null)
            {
                return NotFound();
            }

            return View(tblSortie);
        }

        // POST: Sorties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string query = "select id_sortie,nom_client,qte,montant,tbl_sortie.dateday as dateday,designation,prix_vente,client,produit from tbl_produit inner join tbl_sortie on id_produit = produit inner join tbl_client on client = id_client WHERE id_sortie = @p0";

            TblSortie tblSortie = await _context.TblSorties.FromSqlRaw(query, id).SingleOrDefaultAsync();
            _context.TblSorties.Remove(tblSortie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSortieExists(int id)
        {
            return _context.TblSorties.Any(e => e.IdSortie == id);
        }
    }
}
