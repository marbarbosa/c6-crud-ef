namespace Escola.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; } = new Pessoa();
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }

        public Usuario? UsuInclusao { get; set; } = new Usuario();
        public DateTime? DataInclusao { get; set; }


        public Usuario? UsuUltAtu { get; set; } = new Usuario();
        public DateTime? DataUltAtu { get; set; }


        public Usuario? UsuExclusao { get; set; } = new Usuario();
        public DateTime? DataExclusao { get; set; }
    }
}
