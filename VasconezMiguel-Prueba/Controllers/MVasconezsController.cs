using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VasconezMiguel_Prueba.Models;

namespace VasconezMiguel_Prueba.Controllers
{
    public class MVasconezsController : Controller
    {
        private readonly VasconezMiguelContext _context;

        public MVasconezsController(VasconezMiguelContext context)
        {
            _context = context;
        }

        // GET: MVasconezs
        public async Task<IActionResult> Index()
        {
            var vasconezMiguelContext = _context.MVasconez.Include(m => m.Celular);
            return View(await vasconezMiguelContext.ToListAsync());
        }

        // GET: MVasconezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVasconez = await _context.MVasconez
                .Include(m => m.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mVasconez == null)
            {
                return NotFound();
            }

            return View(mVasconez);
        }

        // GET: MVasconezs/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id");
            return View();
        }

        // POST: MVasconezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,peso,Compra,IdCelular")] MVasconez mVasconez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mVasconez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", mVasconez.IdCelular);
            return View(mVasconez);
        }

        // GET: MVasconezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVasconez = await _context.MVasconez.FindAsync(id);
            if (mVasconez == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", mVasconez.IdCelular);
            return View(mVasconez);
        }

        // POST: MVasconezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,peso,Compra,IdCelular")] MVasconez mVasconez)
        {
            if (id != mVasconez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mVasconez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MVasconezExists(mVasconez.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", mVasconez.IdCelular);
            return View(mVasconez);
        }

        // GET: MVasconezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVasconez = await _context.MVasconez
                .Include(m => m.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mVasconez == null)
            {
                return NotFound();
            }

            return View(mVasconez);
        }

        // POST: MVasconezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mVasconez = await _context.MVasconez.FindAsync(id);
            if (mVasconez != null)
            {
                _context.MVasconez.Remove(mVasconez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MVasconezExists(int id)
        {
            return _context.MVasconez.Any(e => e.Id == id);
        }
    }
}
