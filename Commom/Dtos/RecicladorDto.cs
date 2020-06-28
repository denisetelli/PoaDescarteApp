using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commom.Dtos
{
    public class RecicladorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.", AllowEmptyStrings = false)]
        public string Endereco { get; set; }

        public string Coordenadas { get; set; }

        public ICollection<CategoriaDto> Categorias { get; set; }
    }
}
