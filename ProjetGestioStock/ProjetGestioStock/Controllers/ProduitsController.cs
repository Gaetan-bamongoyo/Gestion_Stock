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
    public class ProduitsController : Controller
    {
        private readonly GestionDeStockContext _context;

        public ProduitsController(GestionDeStockContext context)
        {
            _context = context;
        }

        // GET: Produits
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProduits.ToListAsync());
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduit = await _context.TblProduits
                .FirstOrDefaultAsync(m => m.IdProduit == id);
            if (tblProduit == null)
            {
                return NotFound();
            }

            return View(tblProduit);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduit,Designation,PrixVente,Dateday")] TblProduit tblProduit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProduit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProduit);
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduit = await _context.TblProduits.FindAsync(id);
            if (tblProduit == null)
            {
                return NotFound();
            }
            return View(tblProduit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduit,Designation,PrixVente,Dateday")] TblProduit tblProduit)
        {
            if (id != tblProduit.IdProduit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProduitExists(tblProduit.IdProduit))
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
            return View(tblProduit);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduit = await _context.TblProduits
                .FirstOrDefaultAsync(m => m.IdProduit == id);
            if (tblProduit == null)
            {
                return NotFound();
            }

            return View(tblProduit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduit = await _context.TblProduits.FindAsync(id);
            _context.TblProduits.Remove(tblProduit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProduitExists(int id)
        {
            return _context.TblProduits.Any(e => e.IdProduit == id);
        }
    }
}
