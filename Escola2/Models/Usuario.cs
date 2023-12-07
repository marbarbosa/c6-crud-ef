using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string? Senha { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltAtu { get; set; }

        public DateTime? DataExclusao { get; set; }
    }
}
