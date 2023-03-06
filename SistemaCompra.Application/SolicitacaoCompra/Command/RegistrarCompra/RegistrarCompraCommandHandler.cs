using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using SolicitaCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using System.Linq;

namespace SistemaCompra.Application.Produto.Command.RegistrarProduto
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitaCompraAgg.ISolicitacaoCompraRepository _solicitarCompraRepository;
        private readonly ProdutoAgg.IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(SolicitaCompraAgg.ISolicitacaoCompraRepository solicitarCompraRepository, ProdutoAgg.IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this._solicitarCompraRepository = solicitarCompraRepository;
            this._produtoRepository = produtoRepository;

        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {

            var solicitaCompra = new SolicitaCompraAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
            request.Itens.ToList().ForEach(x => {
                x.Produto = _produtoRepository.Obter(x.Produto.Id);
            });

            solicitaCompra.RegistrarCompra(request.Itens, request.CondicaoPagamento);
            _solicitarCompraRepository.RegistrarCompra(solicitaCompra);
            Commit();
            PublishEvents(solicitaCompra.Events);

            return Task.FromResult(true);


        }
    }
}
