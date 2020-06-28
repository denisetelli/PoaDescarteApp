using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;
using Commom.Dtos;

namespace Descarte.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaController(ICategoriaServico categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _categoriaServico.Get().OrderBy( _=> _.Id);
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaDto categoria)
        {
                _categoriaServico.Add(categoria);
                return RedirectToAction("Index");            
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _categoriaServico.Delete(id);
            return RedirectToAction("Index");
        }
                
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria =  _categoriaServico.FindById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoriaDto categoria = _categoriaServico.FindById(id);
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaDto categoria)
        {
            _categoriaServico.Edit(categoria);
            return RedirectToAction("Index");
        }
    }
}
