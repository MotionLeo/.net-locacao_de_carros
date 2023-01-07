using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocacaoDeCarros.Context;
using LocacaoDeCarros.Models;

namespace LocacaoDeCarros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly DbContexto _context;

        public CarrosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var locacaoContext = _context.Carros.Include(c => c.Marca).Include(c => c.Modelo);
            return View(await locacaoContext.ToListAsync());
        }

        /*public IActionResult TodasMarcas(){
            return _context.Marca 
        }*/
        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Marca)
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            var marcas = _context.Marcas.ToList();
            var idMarca = marcas[0].Id;
            var modelos = _context.Modelos.Where(m => m.IdMarca == idMarca).ToList();

            ViewData["IdMarca"] = new SelectList(marcas, "Id", "Nome");
            ViewData["IdModelo"] = new SelectList(modelos, "Id", "Nome");
            /*Utilizando Viewbag para exibir num loop no select do html
            ViewBag.marcas = _context.Marcas.ToList();
            ViewBag.modelos = _context.Modelos.ToList();
            */
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IdModelo,IdMarca")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Nome", carro.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome", carro.IdModelo);
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /*Utilizando viewbag
            ViewBag.marcas = _context.Marcas.ToList();
            ViewBag.modelos = _context.Modelos.ToList(); */
            
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Nome", carro.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome", carro.IdModelo);
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IdModelo,IdMarca")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
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
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "Id", "Nome", carro.IdMarca);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nome", carro.IdModelo);
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carros == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Marca)
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carros == null)
            {
                return Problem("Entity set 'DbContexto.Carro'  is null.");
            }
            var carro = await _context.Carros.FindAsync(id);
            if (carro != null)
            {
                _context.Carros.Remove(carro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
          return (_context.Carros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
