using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }

        public int UsuInclusaoId { get; set; }
        public DateTime DataInclusao { get; set; }

        public int? UsuUltAtuId { get; set; }
        public DateTime? DataUltAtu { get; set; }

        public int? UsuExclusaoId { get; set; }
        public DateTime? DataExclusao { get; set; }

    }
}
