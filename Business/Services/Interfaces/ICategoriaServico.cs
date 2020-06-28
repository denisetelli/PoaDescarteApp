using Commom.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Interfaces
{
    public interface ICategoriaServico
    {
        void Add(CategoriaDto categoria);
        void Delete(int? id);
        void Edit(CategoriaDto categoria);
        CategoriaDto FindById(int? id);
        IEnumerable<CategoriaDto> Get();
    }
}
