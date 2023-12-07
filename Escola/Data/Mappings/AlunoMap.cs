using Escola.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            // Tabela
            builder.ToTable("Alunos");


            // Primary key
            builder.HasKey(x => x.Id);
            // Identity
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // Primary Key Identity (1, 1)


            // Columns
            builder.Property(x => x.Ra)
                .IsRequired()
                .HasColumnName("Ra")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.DataMatricula)
                .IsRequired()
                .HasColumnName("DataMatricula")
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataRecisao)
                .HasColumnName("DataRecisao")
                .HasColumnType("DATETIME");

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
            builder.HasIndex(x => x.Ra, "IDX_Alunos_Ra")
                .IsUnique();


            // Relacionamentos
            builder.HasOne(x => x.Pessoa)
                .WithMany()
                .HasConstraintName("FK_Alunos_Pessoas_PessoaId");

            builder.HasOne(x => x.UsuInclusao)
                .WithMany()
                .HasConstraintName("FK_Alunos_Usuarios_UsuInclusaoId");

            builder.HasOne(x => x.UsuUltAtu)
                .WithMany()
                .HasConstraintName("FK_Alunos_Usuarios_UsuUltAtuId");

            builder.HasOne(x => x.UsuExclusao)
                .WithMany()
                .HasConstraintName("FK_Alunos_Usuarios_UsuExclusaoId");


        }
    }
}
