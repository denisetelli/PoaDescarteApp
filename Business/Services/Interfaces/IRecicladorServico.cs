using Commom.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Interfaces
{
    public interface IRecicladorServico
    {
        void Add(RecicladorDto reciclador);
        void Delete(int? id);
        void Edit(RecicladorDto reciclador);
        RecicladorDto FindById(int? id);
        IEnumerable<RecicladorDto> Get();
    }
}
