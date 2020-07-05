﻿namespace DataAccess.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }
    }
}
