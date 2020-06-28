using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class RecicladorRepositorio : IRecicladorRepositorio
    {
        private readonly DatabaseContext _databaseContext;
        private IQueryable<Reciclador> recicladorAsNoTracking => _databaseContext?.Recicladores.AsNoTracking();

        public RecicladorRepositorio(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Add(Reciclador reciclador)
        {
            _databaseContext.Add(reciclador);
            _databaseContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var recicladorPersistido = FindById(id);
            if (recicladorPersistido != null)
            {
                _databaseContext.Remove(recicladorPersistido);
                _databaseContext.SaveChanges();
            }

        }
        public bool Edit(Reciclador reciclador)
        {
            var recicladorPersistido = FindById(reciclador.Id);

            if (recicladorPersistido != null)
            {
                recicladorPersistido.Nome = reciclador.Nome;
                recicladorPersistido.Telefone = reciclador.Telefone;
                recicladorPersistido.Endereco = reciclador.Endereco;
                recicladorPersistido.Coordenadas = reciclador.Coordenadas;
                recicladorPersistido.Categorias = reciclador.Categorias;

                return _databaseContext.SaveChanges() == 1;
            }
            return false;
        }
        public Reciclador FindById(int? id)
        {
            return _databaseContext.Recicladores.FirstOrDefault(_ => _.Id == id);
        }

        public IEnumerable<Reciclador> Get()
        {
            return recicladorAsNoTracking;
        }
    }
}
