using AutoMapper;
using Business.Services.Interfaces;
using Commom.Dtos;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ItemServico : IItemServico
    {
        private readonly IItemRepositorio _itemRepositorio;
        private readonly IMapper _mapper;

        public ItemServico(IItemRepositorio itemRepositorio, IMapper mapper)
        {
            _itemRepositorio = itemRepositorio;
            _mapper = mapper;
        }

        public void Add(ItemDto itemDto)
        {
            _itemRepositorio.Add(_mapper.Map<Item>(itemDto));
        }

        public void Delete(int? id)
        {
            _itemRepositorio.Delete(id);
        }

        public void Edit(ItemDto item)
        {
            _itemRepositorio.Edit(_mapper.Map<Item>(item));
        }

        public ItemDto FindById(int? id)
        {
            var item = _itemRepositorio.FindById(id);
            return _mapper.Map<ItemDto>(item);
        }

        public IEnumerable<ItemDto> Get()
        {
            var itens = _itemRepositorio.Get();
            return _mapper.Map<List<ItemDto>>(itens);
        }

        public IEnumerable<ItemDto> GetByCategory(int categoriaId)
        {
            var itemsByCateogry = _itemRepositorio.GetByCategory(categoriaId);
            return _mapper.Map<List<ItemDto>>(itemsByCateogry);
        }
    }
}
