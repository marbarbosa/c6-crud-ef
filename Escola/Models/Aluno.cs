namespace Escola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public Pessoa? Pessoa { get; set; } = new Pessoa();
        public string? Ra { get; set; }
        public DateTime? DataMatricula { get; set; }
        public DateTime? DataRecisao { get; set; }

        public Usuario? UsuInclusao { get; set; } = new Usuario();
        public DateTime? DataInclusao { get; set; }


        public Usuario? UsuUltAtu { get; set; } = new Usuario();
        public DateTime? DataUltAtu { get; set; }


        public Usuario? UsuExclusao { get; set; } = new Usuario();
        public DateTime? DataExclusao { get; set; }

    }
}
