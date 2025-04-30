using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeliculasWeb.Data;
using PeliculasWeb.Models;

namespace PeliculasWeb.Controllers
{
    public class ReseñasController : Controller
    {
        private readonly AppDbContext _context;

        public ReseñasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reseñas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Reseñas.Include(r => r.Cliente).Include(r => r.Pelicula);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Reseñas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas
                .Include(r => r.Cliente)
                .Include(r => r.Pelicula)
                .FirstOrDefaultAsync(m => m.ReseñaId == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // GET: Reseñas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "PeliculaId");
            return View();
        }

        // POST: Reseñas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReseñaId,Calificacion,Comentario,FechaReseña,EsRecomendada,ClienteId,PeliculaId")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", reseña.ClienteId);
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "PeliculaId", reseña.PeliculaId);
            return View(reseña);
        }

        // GET: Reseñas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", reseña.ClienteId);
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "NombrePelicula", reseña.PeliculaId);
            return View(reseña);
        }

        // POST: Reseñas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReseñaId,Calificacion,Comentario,FechaReseña,EsRecomendada,ClienteId,PeliculaId")] Reseña reseña)
        {
            if (id != reseña.ReseñaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaExists(reseña.ReseñaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", reseña.ClienteId);
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "NombrePelicula", reseña.PeliculaId);
            return View(reseña);
        }

        // GET: Reseñas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseñas
                .Include(r => r.Cliente)
                .Include(r => r.Pelicula)
                .FirstOrDefaultAsync(m => m.ReseñaId == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // POST: Reseñas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña != null)
            {
                _context.Reseñas.Remove(reseña);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaExists(int id)
        {
            return _context.Reseñas.Any(e => e.ReseñaId == id);
        }
    }
}
