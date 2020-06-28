using System;
using System.ComponentModel.DataAnnotations;

namespace Commom.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.", AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+))@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+))\.([A-Za-z]{2,})$",
        ErrorMessage = "O e-mail não foi inserido da maneira correta.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Senha é obrigatória.", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.[\d])(?:.[^a-zA-Z])", ErrorMessage = "A senha deve conter 6 caracteres incluindo letras e números.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirmação de senha é obrigatória.", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.[\d])(?:.[^a-zA-Z])", ErrorMessage = " ")]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais.")]
        public string ConfirmacaoSenha { get; set; }

        public DateTime CriacaoConta { get; set; }

        public bool Inativo { get; set; }

        [Required(ErrorMessage ="Autorização é obrigatória.")]
        public int IdPermissao { get; set; }

        public PermissaoDto Permissao { get; set; }
    }
}

