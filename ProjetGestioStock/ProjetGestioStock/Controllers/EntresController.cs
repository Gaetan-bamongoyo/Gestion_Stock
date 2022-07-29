using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetGestioStock.Data;
using ProjetGestioStock.Models;
using ProjetGestioStock.ViewModel;

namespace ProjetGestioStock.Controllers
{
    public class EntresController : Controller
    {
        private readonly GestionDeStockContext _context;

        public EntresController(GestionDeStockContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Month()
        {
            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit Where (SELECT (DATENAME(month, tbl_entre.dateday)) AS mois ) = (SELECT DATENAME(month, GETDATE()) ); ";

            List<TblEntre> sorties = _context.TblEntres.FromSqlRaw(query).ToList();

            return View(sorties);
        }
        public async Task<IActionResult> Day()
        {
            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit Where (SELECT (CONVERT(DATE, tbl_entre.dateday)) AS dateA ) = (SELECT CONVERT(DATE, GETDATE()) dateDay1); ";

            List<TblEntre> entres = _context.TblEntres.FromSqlRaw(query).ToList();
            return View(entres);
        }

        // GET: Entres
        public async Task<IActionResult> Index()
        {
            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit";

            List<TblEntre> entres =  _context.TblEntres.FromSqlRaw(query).ToList();
            return View(entres);
            //return View(await _context.TblEntres.ToListAsync());
        }

        // GET: Entres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit WHERE id_entre = @p0";

            List<TblEntre> tblEntre = _context.TblEntres.FromSqlRaw(query, id).ToList();

            if (tblEntre == null)
            {
                return NotFound();
            }

            return View(tblEntre);
        }

        public List<TblProduit> GetProduitList()
        {
            List<TblProduit> produit = _context.TblProduits.ToList();
            return produit;
        }
        public List<TblFournisseur> GetFournisseurList()
        {
            List<TblFournisseur> fournisseur = _context.TblFournisseurs.ToList();
            return fournisseur;
        }
        // GET: Entres/Create
        public IActionResult Create()
        {
            ViewBag.FournisseurList = new SelectList(GetFournisseurList(), "IdFournisseur", "NomFournisseur");
            ViewBag.ProduitList = new SelectList(GetProduitList(), "IdProduit", "Designation");
            return View();
        }

        // POST: Entres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntre,Qte,Pu,Dateexpiration,Produit,Dateday,Fournisseur")] TblEntre tblEntre)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("addNewEntre {0},{1},{2},{3},{4},{5}", tblEntre.Qte, tblEntre.Pu,tblEntre.Dateexpiration,tblEntre.Produit,tblEntre.Dateexpiration,tblEntre.Fournisseur);
                //_context.Add(tblEntre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEntre);
        }

        // GET: Entres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit WHERE id_entre = @p0";

            //List<TblEntre> tblEntre = _context.TblEntres.FromSqlRaw(query).ToList();

            TblEntre tblEntre = await _context.TblEntres.FromSqlRaw(query,id).SingleOrDefaultAsync();
            if (tblEntre == null)
            {
                return NotFound();
            }
            ViewBag.FournisseurList = new SelectList(GetFournisseurList(), "IdFournisseur", "NomFournisseur");
            ViewBag.ProduitList = new SelectList(GetProduitList(), "IdProduit", "Designation");
            return View(tblEntre);
        }

        // POST: Entres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntre,Qte,Pu,Dateexpiration,Produit,Dateday,Fournisseur")] TblEntre tblEntre)
        {
            if (id != tblEntre.IdEntre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEntre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEntreExists(tblEntre.IdEntre))
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
            return View(tblEntre);
        }

        // GET: Entres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit WHERE id_entre = @p0";
            TblEntre tblEntre = await _context.TblEntres.FromSqlRaw(query, id).SingleOrDefaultAsync();

            if (tblEntre == null)
            {
                return NotFound();
            }

            return View(tblEntre);
        }

        // POST: Entres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var tblEntre = await _context.TblEntres.FindAsync(id);
            string query = "SELECT id_entre, nom_fournisseur, designation, qte, pu, fournisseur, produit, tbl_entre.dateday as dateday, dateexpiration  FROM tbl_fournisseur INNER JOIN tbl_entre ON id_fournisseur=fournisseur INNER JOIN tbl_produit ON produit = id_produit WHERE id_entre = @p0";
            TblEntre tblEntre = await _context.TblEntres.FromSqlRaw(query, id).SingleOrDefaultAsync();
            _context.TblEntres.Remove(tblEntre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEntreExists(int id)
        {
            return _context.TblEntres.Any(e => e.IdEntre == id);
        }
    }
}
