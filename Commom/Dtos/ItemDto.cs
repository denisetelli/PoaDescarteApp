
namespace Commom.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaDto Categoria { get; set; }
    }
}
