using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Descarte.Controllers
{
    public class RecicladorController : Controller
    {
        private readonly DatabaseContext _context;

        public RecicladorController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Reciclador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recicladores.ToListAsync());
        }

        // GET: Reciclador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclador = await _context.Recicladores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reciclador == null)
            {
                return NotFound();
            }

            return View(reciclador);
        }

        // GET: Reciclador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reciclador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Endereco,Coordenadas")] Reciclador reciclador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reciclador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reciclador);
        }

        // GET: Reciclador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclador = await _context.Recicladores.FindAsync(id);
            if (reciclador == null)
            {
                return NotFound();
            }
            return View(reciclador);
        }

        // POST: Reciclador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Endereco,Coordenadas")] Reciclador reciclador)
        {
            if (id != reciclador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reciclador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecicladorExists(reciclador.Id))
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
            return View(reciclador);
        }

        // GET: Reciclador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclador = await _context.Recicladores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reciclador == null)
            {
                return NotFound();
            }

            return View(reciclador);
        }

        // POST: Reciclador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reciclador = await _context.Recicladores.FindAsync(id);
            _context.Recicladores.Remove(reciclador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecicladorExists(int id)
        {
            return _context.Recicladores.Any(e => e.Id == id);
        }
    }
}
