using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;
using Commom.Dtos;

namespace Descarte.Controllers
{
    public class RecicladorController : Controller
    {
        private readonly IRecicladorServico _recicladorServico;

        public RecicladorController(IRecicladorServico recicladorServico)
        {
            _recicladorServico = recicladorServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var recicladores = _recicladorServico.Get().OrderBy(_ => _.Id);
            return View(recicladores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecicladorDto reciclador)
        {
            _recicladorServico.Add(reciclador);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _recicladorServico.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciclador = _recicladorServico.FindById(id);
            if (reciclador == null)
            {
                return NotFound();
            }

            return View(reciclador);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            RecicladorDto reciclador = _recicladorServico.FindById(id);
            return View(reciclador);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecicladorDto reciclador)
        {
            _recicladorServico.Edit(reciclador);
            return RedirectToAction("Index");
        }
    }
}
