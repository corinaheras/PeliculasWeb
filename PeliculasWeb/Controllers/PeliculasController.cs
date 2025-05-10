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
    public class PeliculasController : Controller
    {
        private readonly AppDbContext _context;

        public PeliculasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Peliculas
        public async Task<IActionResult> Index(string searchString, string NombreGenero)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["Genero"] = NombreGenero;

            var peliculas = from p in _context.Peliculas
                .Include(p => p.Actor)
                .Include(p => p.Director)
                .Include(p => p.Genero)
                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                peliculas = peliculas.Where(p => p.NombrePelicula.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(NombreGenero))
            {
                peliculas = peliculas.Where(p => p.Genero.NombreGenero.Contains(NombreGenero));
            }

            return View(await peliculas.ToListAsync());
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .Include(p => p.Actor)
                .Include(p => p.Director)
                .Include(p => p.Genero)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actores, "ActorId", "NombreActor");
            ViewData["DirectorId"] = new SelectList(_context.Directores, "DirectorId", "Nombre");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "NombreGenero");

            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeliculaId,FechaEstreno,NombrePelicula,GeneroId,Sipnosis,ActorId,DirectorId,ImagenRuta")] Pelicula pelicula)
        {
            /*if (id != pelicula.PeliculaId)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {

                try
                {
                    if (pelicula.ImagenArchivo != null && pelicula.ImagenArchivo.Length > 0)
                    {
                        var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(pelicula.ImagenArchivo.FileName);
                        var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", nombreArchivo);

                        using (var stream = new FileStream(ruta, FileMode.Create))
                        {
                            await pelicula.ImagenArchivo.CopyToAsync(stream);
                        }

                        //Guardar nueva ruta de imagen
                        pelicula.ImagenRuta = "/imagenes/" + nombreArchivo;
                    }
                    _context.Add(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.PeliculaId))
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
            ViewData["ActorId"] = new SelectList(_context.Actores, "ActorId", "NombreActor", pelicula.ActorId);
            ViewData["DirectorId"] = new SelectList(_context.Directores, "DirectorId", "Nombre", pelicula.DirectorId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "NombreGenero", pelicula.GeneroId);

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actores, "ActorId", "NombreActor", pelicula.ActorId);
            ViewData["DirectorId"] = new SelectList(_context.Directores, "DirectorId", "Nombre", pelicula.DirectorId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "NombreGenero", pelicula.GeneroId);

            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //        public async Task<IActionResult> Edit(int id, [Bind("PeliculaId,FechaEstreno,NombrePelicula,GeneroId,Sipnosis,ActorId,DirectorId,ImagenRuta")] Pelicula pelicula, IFormFile ImagenArchivo)

        public async Task<IActionResult> Edit(int id, Pelicula pelicula)
        {

        if (id != pelicula.PeliculaId) return NotFound();
            if (pelicula.ImagenArchivo != null && pelicula.ImagenArchivo.Length > 0)
            {
                Console.WriteLine("punto");
            }
                if (ModelState.IsValid)
            {
                try
                {

                    if (pelicula.ImagenArchivo != null && pelicula.ImagenArchivo.Length > 0)
                    {
                        var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(pelicula.ImagenArchivo.FileName);
                        var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", nombreArchivo);

                        using (var stream = new FileStream(ruta, FileMode.Create))
                        {
                            await pelicula.ImagenArchivo.CopyToAsync(stream);
                        }

                        //Guardar nueva ruta de imagen
                        pelicula.ImagenRuta = "/imagenes/" + nombreArchivo;

                    }

                    else
                    {
                        var peliculaExistente = await _context.Peliculas.AsNoTracking().FirstOrDefaultAsync(p => p.PeliculaId == pelicula.PeliculaId);
                        if (peliculaExistente != null)
                        {
                            pelicula.ImagenRuta = peliculaExistente.ImagenRuta;

                        }
                    }
                        _context.Update(pelicula);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.PeliculaId))
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


            if (pelicula.ImagenArchivo == null || pelicula.ImagenArchivo.Length == 0)
            {
                var peliculaExistente = await _context.Peliculas.AsNoTracking().FirstOrDefaultAsync(p => p.PeliculaId == pelicula.PeliculaId);
                if (peliculaExistente != null)
                {
                    pelicula.ImagenRuta = peliculaExistente.ImagenRuta;
                }
            }


            ViewData["ActorId"] = new SelectList(_context.Actores, "ActorId", "NombreActor", pelicula.PeliculaId);
            ViewData["DirectorId"] = new SelectList(_context.Directores, "DirectorId", "Nombre", pelicula.DirectorId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "NombreGenero", pelicula.GeneroId);




            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .Include(p => p.Actor)
                .Include(p => p.Director)
                .Include(p => p.Genero)
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Peliculas.Any(e => e.PeliculaId == id);
        }
    }
}
