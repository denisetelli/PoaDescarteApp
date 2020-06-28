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
    public class CategoriaServico: ICategoriaServico
    {
        private ICategoriaRepositorio _categoriaRepositorio;
        private IMapper _mapper;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        public void Add(CategoriaDto categoria)
        {
            _categoriaRepositorio.Add(_mapper.Map<Categoria>(categoria));
        }

        public void Delete(int? id)
        {
            _categoriaRepositorio.Delete(id);
        }

        public void Edit(CategoriaDto categoria)
        {
            _categoriaRepositorio.Edit(_mapper.Map<Categoria>(categoria));
        }

        public CategoriaDto FindById(int? id)
        {
            var categoria = _categoriaRepositorio.FindById(id);
            return _mapper.Map<CategoriaDto>(categoria);
        }

        public IEnumerable<CategoriaDto> Get()
        {
            var categorias = _categoriaRepositorio.Get();
            return _mapper.Map<List<CategoriaDto>>(categorias);

        }
    }
}
