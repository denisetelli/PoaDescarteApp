using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DatabaseContext _databaseContext;
        private IQueryable<Categoria> _categoriaAsNoTracking => _databaseContext?.Categorias.AsNoTracking();

        public CategoriaRepositorio(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
       
        public void Add(Categoria categoria)
        {
            _databaseContext.Add(categoria);
            _databaseContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var categoriaPersistida = FindById(id);
            if (categoriaPersistida != null)
            {
                _databaseContext.Remove(categoriaPersistida);
                _databaseContext.SaveChanges();
            }

        }
        public bool Edit(Categoria categoria)
        {
            var categoriaPersistida = FindById(categoria.Id);

            if (categoriaPersistida != null)
            {
                categoriaPersistida.Nome = categoria.Nome;
                categoriaPersistida.Itens = categoria.Itens;

                return _databaseContext.SaveChanges() == 1;
            }
            return false;
        }
        public Categoria FindById(int? id)
        {
            return _databaseContext.Categorias.FirstOrDefault(_ => _.Id == id);
        }
        
        public IEnumerable<Categoria> Get()
        {
            return _categoriaAsNoTracking;
        }
    }
}
