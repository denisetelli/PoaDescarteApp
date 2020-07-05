using Commom.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Interfaces
{
    public interface IItemServico
    {
        void Add(ItemDto categoria);
        void Delete(int? id);
        void Edit(ItemDto categoria);
        ItemDto FindById(int? id);
        IEnumerable<ItemDto> Get();
        IEnumerable<ItemDto> GetByCategory(int categoriaId);
    }
}
