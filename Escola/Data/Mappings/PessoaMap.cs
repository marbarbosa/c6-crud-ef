using Escola.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            // Tabela
            builder.ToTable("Pessoas");


            // Primary key
            builder.HasKey(x => x.Id);
            // Identity
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // Primary Key Identity (1, 1)


            // Columns
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnName("Telefone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);

            builder.Property(x => x.DataInclusao)
                .IsRequired()
                .HasColumnName("DataInclusao")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.DataUltAtu)
                .IsRequired()
                .HasColumnName("DataUltAtu")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.DataExclusao)
                .HasColumnName("DataExclusao")
                .HasColumnType("DATETIME");



            // Index
            builder.HasIndex(x => x.Cpf, "IDX_Pessoas_Cpf")
                .IsUnique();



            // Relacionamentos
            builder.HasOne(x => x.UsuInclusao)
                .WithMany()
                .HasConstraintName("FK_Pessoas_Usuarios_UsuInclusaoId");

            builder.HasOne(x => x.UsuUltAtu)
                .WithMany()
                .HasConstraintName("FK_Pessoas_Usuarios_UsuUltAtuId");

            builder.HasOne(x => x.UsuExclusao)
                .WithMany()
                .HasConstraintName("FK_Pessoas_Usuarios_UsuExclusaoId");

        }
    }
}
