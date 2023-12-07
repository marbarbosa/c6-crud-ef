namespace Escola.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }

        public int UsuInclusaoId { get; set; }
        public DateTime DataInclusao { get; set; }

        public int? UsuUltAtuId { get; set; }
        public DateTime? DataUltAtu { get; set; }

        public int? UsuExclusaoId { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
