using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPrueba.ConText;
using ApiPrueba.Models;
using ApiPrueba.Controllers.Apis;
using ApiPrueba.Repositories;

namespace ApiPrueba.Controllers.Vistas
{
    public class ProovedorsController : Controller
    {
        private readonly IUnir _context;

        public ProovedorsController(IUnir context)
        {
            _context = context;
        }

        // GET: Proovedors
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.Proovedor.TodosRegistros());
        }

       

        // GET: Proovedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proovedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Telefono,Direccion,Contacto,FechaEntrega,FechaEntrega1")] Proovedor proovedor)
        {
            if (ModelState.IsValid)
            {
                await _context.Proovedor.Crear(proovedor);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(proovedor);
        }

        // GET: Proovedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proovedor == null)
            {
                return NotFound();
            }

            var proovedor = await _context.Proovedor.Buscar(id);
            if (proovedor == null)
            {
                return NotFound();
            }
            return View(proovedor);
        }

        // POST: Proovedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Telefono,Direccion,Contacto,FechaEntrega,FechaEntrega1")] Proovedor proovedor)
        {
            if (id != proovedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Proovedor.Modificar(proovedor);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProovedorExists(proovedor.Id))
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
            return View(proovedor);
        }

        // GET: Proovedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proovedor == null)
            {
                return NotFound();
            }

            var proovedor = await _context.Proovedor.Buscar(id);
            if (proovedor == null)
            {
                return NotFound();
            }

            return View(proovedor);
        }

        // POST: Proovedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proovedor == null)
            {
                return Problem("Entity set 'AppDbContext.Provedor'  is null.");
            }
            var proovedor = await _context.Proovedor.Buscar(id);
            if (proovedor != null)
            {
                await _context.Proovedor.Borrar(id);
            }
            
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProovedorExists(int id)
        {
            if(_context.Proovedor.Buscar(id)==null)
                return false;
            return true;
        }
    }
}
