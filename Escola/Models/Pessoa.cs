using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }

        public Usuario? UsuInclusao { get; set; } = new Usuario();
        public DateTime? DataInclusao { get; set; }


        public Usuario? UsuUltAtu { get; set; } = new Usuario();
        public DateTime? DataUltAtu { get; set; }


        public Usuario? UsuExclusao { get; set; } = new Usuario();
        public DateTime? DataExclusao { get; set; }

    }
}
