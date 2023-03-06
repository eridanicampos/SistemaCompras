using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            builder.OwnsOne(c => c.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral"));
            builder.Property(y => y.Id).HasColumnName("Id");
            builder.Property(y => y.Data).HasColumnName("Data").IsRequired();
            builder.Property(y => y.Situacao).HasColumnName("Situacao").IsRequired();
        }
    }
}
