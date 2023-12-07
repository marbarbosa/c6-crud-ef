using Escola.Data.Mappings;
using Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Data
{
    public class EscolaDataContext : DbContext
    {
        public DbSet<Pessoa>? Pessoas { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<Aluno>? Alunos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=escola;User ID=sa;Password=1q2w3e4r@#$;");


        // Arquivos de Mapeamento, criação dos modelos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }
    }
}
