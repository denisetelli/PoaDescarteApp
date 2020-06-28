using Commom.Dtos;
using System.Collections.Generic;

namespace Commom
{
    public class PermissaoDto
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        public ICollection<UsuarioDto> Usuarios { get; set; }
    }
}
