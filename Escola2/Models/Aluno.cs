namespace Escola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string? Ra { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime? DataRecisao { get; set; }

        public int UsuInclusaoId { get; set; }
        public DateTime DataInclusao { get; set; }

        public int? UsuUltAtuId { get; set; }
        public DateTime? DataUltAtu { get; set; }

        public int? UsuExclusaoId { get; set; }
        public DateTime? DataExclusao { get; set; }

    }
}
