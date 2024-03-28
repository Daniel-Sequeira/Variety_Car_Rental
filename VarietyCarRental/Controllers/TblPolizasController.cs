using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VarietyCarRental.Models;

namespace VarietyCarRental.Controllers
{
    public class TblPolizasController : Controller
    {
        private readonly RentCarContext _context;

        public TblPolizasController(RentCarContext context)
        {
            _context = context;
        }

        // GET: TblPolizas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblPolizas.ToListAsync());
        }

        // GET: TblPolizas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoliza = await _context.TblPolizas
                .FirstOrDefaultAsync(m => m.IdPoliza == id);
            if (tblPoliza == null)
            {
                return NotFound();
            }

            return View(tblPoliza);
        }

        // GET: TblPolizas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPolizas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPoliza,DescripcionPoliza,CostoPoliza")] TblPoliza tblPoliza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPoliza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPoliza);
        }

        // GET: TblPolizas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoliza = await _context.TblPolizas.FindAsync(id);
            if (tblPoliza == null)
            {
                return NotFound();
            }
            return View(tblPoliza);
        }

        // POST: TblPolizas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPoliza,DescripcionPoliza,CostoPoliza")] TblPoliza tblPoliza)
        {
            if (id != tblPoliza.IdPoliza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoliza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPolizaExists(tblPoliza.IdPoliza))
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
            return View(tblPoliza);
        }

        // GET: TblPolizas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoliza = await _context.TblPolizas
                .FirstOrDefaultAsync(m => m.IdPoliza == id);
            if (tblPoliza == null)
            {
                return NotFound();
            }

            return View(tblPoliza);
        }

        // POST: TblPolizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPoliza = await _context.TblPolizas.FindAsync(id);
            if (tblPoliza != null)
            {
                _context.TblPolizas.Remove(tblPoliza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPolizaExists(int id)
        {
            return _context.TblPolizas.Any(e => e.IdPoliza == id);
        }
    }
}
