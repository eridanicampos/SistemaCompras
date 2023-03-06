using AutoMapper;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitaCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;


namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d => d.Preco, o => o.MapFrom(src => src.Preco.Value));

            CreateMap<SolicitaCompraAgg.SolicitacaoCompra, ObterCompraViewModel>()
                .ForMember(d => d.NomeFornecedor, o => o.MapFrom(src => src.NomeFornecedor.Nome))
                .ForMember(d => d.UsuarioSolicitante, o=> o.MapFrom(src => src.UsuarioSolicitante.Nome));

        }
    }
}
