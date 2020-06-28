using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ICategoriaRepositorio
    {
        void Add(Categoria categoria);
        void Delete(int? id);
        bool Edit(Categoria categoria);
        Categoria FindById(int? id);
        IEnumerable<Categoria> Get();
    }
}
