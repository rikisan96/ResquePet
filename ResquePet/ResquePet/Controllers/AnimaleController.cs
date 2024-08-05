using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResquePet.Data;
using ResquePet.Models;

namespace ResquePet.Controllers
{
    public class AnimaleController : Controller
    {
        private readonly VeterinarioContext _context;

        public AnimaleController(VeterinarioContext context)
        {
            _context = context;
        }

        // GET: Animale
        public async Task<IActionResult> Index()
        {
            var veterinarioContext = _context.animale;
            return View(veterinarioContext);
        }

        // GET: Animale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.animale
                .Include(a => a.utente)
                .FirstOrDefaultAsync(m => m.IdAnimale == id);
            if (animale == null)
            {
                return NotFound();
            }

            return View(animale);
        }

        // GET: Animale/Create
        public IActionResult Create()
        {
            ViewData["IdUtente"] = new SelectList(_context.Utente, "IdUtente", "IdUtente");
            return View();
        }

        // POST: Animale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdAnimale,Nome,tipoAnimale,coloreMantello,dataNascita,DataRegistrazione,isMicrochipped,MicrochipID,IdUtente")] Animale animale)

        public async Task<IActionResult> Create([Bind("IdAnimale,Nome,tipoAnimale,coloreMantello,dataNascita,isMicrochipped,MicrochipID,IdUtente")] Animale animale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUtente"] = new SelectList(_context.Utente, "IdUtente", "IdUtente", animale.IdUtente);
            return View(animale);
        }

        // GET: Animale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.animale.FindAsync(id);
            if (animale == null)
            {
                return NotFound();
            }
            ViewData["IdUtente"] = new SelectList(_context.Utente, "IdUtente", "IdUtente", animale.IdUtente);
            return View(animale);
        }

        // POST: Animale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimale,Nome,tipoAnimale,coloreMantello,dataNascita,isMicrochipped,MicrochipID,IdUtente")] Animale animale)
        {
            if (id != animale.IdAnimale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimaleExists(animale.IdAnimale))
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
            ViewData["IdUtente"] = new SelectList(_context.Utente, "IdUtente", "IdUtente", animale.IdUtente);
            return View(animale);
        }

        // GET: Animale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animale = await _context.animale
                .Include(a => a.utente)
                .FirstOrDefaultAsync(m => m.IdAnimale == id);
            if (animale == null)
            {
                return NotFound();
            }

            return View(animale);
        }

        // POST: Animale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animale = await _context.animale.FindAsync(id);
            if (animale != null)
            {
                _context.animale.Remove(animale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimaleExists(int id)
        {
            return _context.animale.Any(e => e.IdAnimale == id);
        }
    }
}
