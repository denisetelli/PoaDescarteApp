using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;
using Commom.Dtos;

namespace Descarte.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemServico _itemServico;

        public ItemController(IItemServico itemServico)
        {
            _itemServico = itemServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var itens = _itemServico.Get().OrderBy(_ => _.Id);
            return View(itens);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemDto item)
        {
            _itemServico.Add(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _itemServico.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _itemServico.FindById(id);
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
        public async Task<IActionResult> Edit(ItemDto itemDto)
        {
            _itemServico.Edit(itemDto);
            return RedirectToAction("Index");
        }
    }
}
