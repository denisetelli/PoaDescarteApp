using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.Interfaces
{
    public class ItemRepositorio : IItemRepositorio
    {
        private readonly DatabaseContext _databaseContext;
        private IQueryable<Item> _itemAsNoTracking => _databaseContext?.Itens.AsNoTracking();

        public ItemRepositorio(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Item item)
        {
            _databaseContext.Add(item);
            _databaseContext.SaveChanges();
        }
        public void Delete(int? id)
        {
            var itemPersistido = FindById(id);
            if (itemPersistido != null)
            {
                _databaseContext.Remove(itemPersistido);
                _databaseContext.SaveChanges();
            }
        }

        public bool Edit(Item item)
        {
            var itemPersistido = FindById(item.Id);

            if (itemPersistido != null)
            {
                itemPersistido.Nome = item.Nome;
                itemPersistido.Categoria = item.Categoria;

                return _databaseContext.SaveChanges() == 1;
            }
            return false;
        }
        public Item FindById(int? id)
        {
            return _databaseContext.Itens.FirstOrDefault(_ => _.Id == id);
        }

        public IEnumerable<Item> Get()
        {
            return _itemAsNoTracking;
        }

        public IEnumerable<Item> GetByCategory(int categoriaId)
        {
            var itemsByCateogry = _itemAsNoTracking.Where(_=>_.Categoria.Id== categoriaId);
            return itemsByCateogry;
        }
    }
}
