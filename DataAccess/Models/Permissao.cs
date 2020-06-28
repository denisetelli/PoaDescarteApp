using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Permissao
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
