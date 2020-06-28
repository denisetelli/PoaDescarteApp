using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public string Texto { get; set; }
        public string VideoUrl { get; set; }
        public virtual ICollection<Item> Itens { get; set; }
    }
}
