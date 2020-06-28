using System.Collections.Generic;

namespace Commom.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Texto { get; set; }
        public string VideoUrl { get; set; }
        public ICollection<ItemDto> Itens { get; set; }
    }
}
