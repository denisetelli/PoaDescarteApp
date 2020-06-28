using AutoMapper;
using Business.Services.Interfaces;
using Commom.Dtos;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class RecicladorServico: IRecicladorServico
    {
        private readonly IRecicladorRepositorio _recicladorRepositorio;
        private readonly IMapper _mapper;

        public RecicladorServico(IRecicladorRepositorio recicladorRepositorio, IMapper mapper)
        {
            _recicladorRepositorio = recicladorRepositorio;
            _mapper = mapper;
        }

        public void Add(RecicladorDto recicladorDto)
        {
            _recicladorRepositorio.Add(_mapper.Map<Reciclador>(recicladorDto));
        }

        public void Delete(int? id)
        {
            _recicladorRepositorio.Delete(id);
        }

        public void Edit(RecicladorDto recicladorDto)
        {
            _recicladorRepositorio.Edit(_mapper.Map<Reciclador>(recicladorDto));
        }

        public RecicladorDto FindById(int? id)
        {
            var reciclador = _recicladorRepositorio.FindById(id);
            return _mapper.Map<RecicladorDto>(reciclador);
        }

        public IEnumerable<RecicladorDto> Get()
        {
            var recicladores = _recicladorRepositorio.Get();
            return _mapper.Map<List<RecicladorDto>>(recicladores);
        }
    }
}
