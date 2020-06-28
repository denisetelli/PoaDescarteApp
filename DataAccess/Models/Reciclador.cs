using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Reciclador
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Coordenadas { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}
