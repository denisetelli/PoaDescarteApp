using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;
using Commom.Dtos;
using System.Collections.Generic;

namespace Descarte.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemServico _itemServico;
        private readonly ICategoriaServico _categoriaServico;

        public ItemController(IItemServico itemServico, ICategoriaServico categoriaServico)
        {
            _itemServico = itemServico;
            _categoriaServico = categoriaServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var itens = _itemServico.Get().OrderBy(_ => _.Nome);
            return View(itens);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoriaServico.Get();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemDto itemDto)
        {
            _itemServico.Add(itemDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _itemServico.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var item = _itemServico.FindById(Id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ItemDto item = _itemServico.FindById(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemDto item)
        {
            _itemServico.Edit(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CategoryItems(int Id)
        {
            IEnumerable<ItemDto> itens = _itemServico.GetByCategory(Id);
            return View(itens);
        }
    }
}
