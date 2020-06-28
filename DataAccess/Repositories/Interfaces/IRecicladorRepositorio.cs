using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRecicladorRepositorio
    {
        void Add(Reciclador reciclador);
        void Delete(int? id);
        bool Edit(Reciclador reciclador);
        Reciclador FindById(int? id);
        IEnumerable<Reciclador> Get();
    }
}