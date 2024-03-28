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
    public class TblVehiculoesController : Controller
    {
        private readonly RentCarContext _context;

        public TblVehiculoesController(RentCarContext context)
        {
            _context = context;
        }

        // GET: TblVehiculoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblVehiculos.ToListAsync());
        }

        // GET: TblVehiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehiculo = await _context.TblVehiculos
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (tblVehiculo == null)
            {
                return NotFound();
            }

            return View(tblVehiculo);
        }

        // GET: TblVehiculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblVehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,Modelo,Tipo,Capacidad,PrecioDia,Disponibilidad")] TblVehiculo tblVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblVehiculo);
        }

        // GET: TblVehiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehiculo = await _context.TblVehiculos.FindAsync(id);
            if (tblVehiculo == null)
            {
                return NotFound();
            }
            return View(tblVehiculo);
        }

        // POST: TblVehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,Modelo,Tipo,Capacidad,PrecioDia,Disponibilidad")] TblVehiculo tblVehiculo)
        {
            if (id != tblVehiculo.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblVehiculoExists(tblVehiculo.IdVehiculo))
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
            return View(tblVehiculo);
        }

        // GET: TblVehiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehiculo = await _context.TblVehiculos
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (tblVehiculo == null)
            {
                return NotFound();
            }

            return View(tblVehiculo);
        }

        // POST: TblVehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVehiculo = await _context.TblVehiculos.FindAsync(id);
            if (tblVehiculo != null)
            {
                _context.TblVehiculos.Remove(tblVehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblVehiculoExists(int id)
        {
            return _context.TblVehiculos.Any(e => e.IdVehiculo == id);
        }
    }
}
