using FastTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTech.Infrastructure.EntityConfiguration;

public class ProdutoEntityConfig : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Descricao)
           .IsRequired()
           .HasColumnType("varchar(700)");

        builder.Property(p => p.Ativo)
           .IsRequired();

        builder.Property(p => p.Valor)
           .IsRequired();

        builder.Property(p => p.Cadastro)
           .IsRequired();

        builder.Property(p => p.Tipo)
           .IsRequired();

        builder.Property(p => p.QuantidadeEstoque)
        .IsRequired();
    }
}
