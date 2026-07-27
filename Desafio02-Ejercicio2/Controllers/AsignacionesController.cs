using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Desafio02_Ejercicio2.Data;
using Desafio02_Ejercicio2.Models;

namespace Desafio02_Ejercicio2.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index(string? searchString)
        {
            var asignaciones = _context.Asignaciones.Include(a => a.Empleado).Include(a => a.Proyecto).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                asignaciones = asignaciones.Where(a => a.Proyecto.NombreProyecto.Contains(searchString) 
                                                    || a.Empleado.Nombre.Contains(searchString) 
                                                    || a.Empleado.Apellido.Contains(searchString) 
                                                    || a.Rol.Contains(searchString));
            }
            return View(await asignaciones.ToListAsync());
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Empleado)
                .Include(a => a.Proyecto)
                .FirstOrDefaultAsync(m => m.AsignacionId == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido");
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "NombreProyecto");
            return View();
        }

        // POST: Asignaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignacionId,EmpleadoId,ProyectoId,FechaAsignacion,Rol")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido", asignacion.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "NombreProyecto", asignacion.ProyectoId);
            return View(asignacion);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido", asignacion.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "NombreProyecto", asignacion.ProyectoId);
            return View(asignacion);
        }

        // POST: Asignaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignacionId,EmpleadoId,ProyectoId,FechaAsignacion,Rol")] Asignacion asignacion)
        {
            if (id != asignacion.AsignacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.AsignacionId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "Apellido", asignacion.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "NombreProyecto", asignacion.ProyectoId);
            return View(asignacion);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Empleado)
                .Include(a => a.Proyecto)
                .FirstOrDefaultAsync(m => m.AsignacionId == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(e => e.AsignacionId == id);
        }
    }
}
