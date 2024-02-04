using System.ComponentModel.DataAnnotations;

namespace Escola.ViewModels
{
    public class EditorAlunoViewModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(80,MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 até 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        public string? Telefone { get; set; }

        public string Ra { get; set; }

        [Required(ErrorMessage = "O campo data da matricula é obrigatório")]
        public DateTime DataMatricula { get; set; }

        [Required(ErrorMessage = "O campo usuário é obrigatório")]
        public int UsuarioId { get; set; }
    }
}
