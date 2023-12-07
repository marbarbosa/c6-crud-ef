using Escola.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            // Tabela
            builder.ToTable("Enderecos");


            // Primary key
            builder.HasKey(x => x.Id);
            // Identity
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // Primary Key Identity (1, 1)

            // Columns
            builder.Property(x => x.PessoaId)
                .IsRequired()
                .HasColumnName("PessoaId")
                .HasColumnType("INT")
                .HasMaxLength(10);

            builder.Property(x => x.Cep)
                .IsRequired()
                .HasColumnName("Cep")
                .HasColumnType("VARCHAR")
                .HasMaxLength(8);

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasColumnName("Logradouro")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnName("Numero")
                .HasColumnType("INT");

            builder.Property(x => x.Complemento)
                .IsRequired()
                .HasColumnName("Complemento")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.UsuInclusaoId)
                .IsRequired()
                .HasColumnName("UsuInclusaoId")
                .HasColumnType("INT");

            builder.Property(x => x.DataInclusao)
                .IsRequired()
                .HasColumnName("DataInclusao")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UsuUltAtuId)
                .IsRequired()
                .HasColumnName("UsuUltAtuId")
                .HasColumnType("INT");

            builder.Property(x => x.DataUltAtu)
                .IsRequired()
                .HasColumnName("DataUltAtu")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UsuExclusaoId)
                .HasColumnName("UsuExclusaoId")
                .HasColumnType("INT");

            builder.Property(x => x.DataExclusao)
                .HasColumnName("DataExclusao")
                .HasColumnType("DATETIME");




        }
    }
}
