using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IItemRepositorio
    {
        void Add(Item item);
        void Delete(int? id);
        bool Edit(Item item);
        Item FindById(int? id);
        IEnumerable<Item> Get();
        IEnumerable<Item> GetByCategory(int categoriaId);
    }
}
