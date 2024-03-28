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
    public class TblUsuariosController : Controller
    {
        private readonly RentCarContext _context;

        public TblUsuariosController(RentCarContext context)
        {
            _context = context;
        }

        // GET: TblUsuarios
        public async Task<IActionResult> Index()
        {
            var rentCarContext = _context.TblUsuarios.Include(t => t.IdRolNavigation);
            return View(await rentCarContext.ToListAsync());
        }

        // GET: TblUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios
                .Include(t => t.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarios == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // GET: TblUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.TblRols, "IdRol", "IdRol");
            return View();
        }

        // POST: TblUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarios,IdRol,Nombre,Apellidos,Email")] TblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.TblRols, "IdRol", "IdRol", tblUsuario.IdRol);
            return View(tblUsuario);
        }

        // GET: TblUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.TblRols, "IdRol", "IdRol", tblUsuario.IdRol);
            return View(tblUsuario);
        }

        // POST: TblUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarios,IdRol,Nombre,Apellidos,Email")] TblUsuario tblUsuario)
        {
            if (id != tblUsuario.IdUsuarios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUsuarioExists(tblUsuario.IdUsuarios))
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
            ViewData["IdRol"] = new SelectList(_context.TblRols, "IdRol", "IdRol", tblUsuario.IdRol);
            return View(tblUsuario);
        }

        // GET: TblUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios
                .Include(t => t.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuarios == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // POST: TblUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            if (tblUsuario != null)
            {
                _context.TblUsuarios.Remove(tblUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUsuarioExists(int id)
        {
            return _context.TblUsuarios.Any(e => e.IdUsuarios == id);
        }
    }
}
