﻿using System;

namespace DataAccess.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime CriacaoConta { get; set; }

        public bool Inativo { get; set; }

        public int IdPermissao { get; set; }

        public virtual Permissao Permissao { get; set; }
    }
}
