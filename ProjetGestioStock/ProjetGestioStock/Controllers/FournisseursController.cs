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
    public class FournisseursController : Controller
    {
        private readonly GestionDeStockContext _context;

        public FournisseursController(GestionDeStockContext context)
        {
            _context = context;
        }

        // GET: Fournisseurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblFournisseurs.ToListAsync());
        }

        // GET: Fournisseurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFournisseur = await _context.TblFournisseurs
                .FirstOrDefaultAsync(m => m.IdFournisseur == id);
            if (tblFournisseur == null)
            {
                return NotFound();
            }

            return View(tblFournisseur);
        }

        // GET: Fournisseurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fournisseurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFournisseur,NomFournisseur,AdresseFournisseur")] TblFournisseur tblFournisseur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFournisseur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFournisseur);
        }

        // GET: Fournisseurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFournisseur = await _context.TblFournisseurs.FindAsync(id);
            if (tblFournisseur == null)
            {
                return NotFound();
            }
            return View(tblFournisseur);
        }

        // POST: Fournisseurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFournisseur,NomFournisseur,AdresseFournisseur")] TblFournisseur tblFournisseur)
        {
            if (id != tblFournisseur.IdFournisseur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFournisseur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFournisseurExists(tblFournisseur.IdFournisseur))
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
            return View(tblFournisseur);
        }

        // GET: Fournisseurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFournisseur = await _context.TblFournisseurs
                .FirstOrDefaultAsync(m => m.IdFournisseur == id);
            if (tblFournisseur == null)
            {
                return NotFound();
            }

            return View(tblFournisseur);
        }

        // POST: Fournisseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblFournisseur = await _context.TblFournisseurs.FindAsync(id);
            _context.TblFournisseurs.Remove(tblFournisseur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFournisseurExists(int id)
        {
            return _context.TblFournisseurs.Any(e => e.IdFournisseur == id);
        }
    }
}
