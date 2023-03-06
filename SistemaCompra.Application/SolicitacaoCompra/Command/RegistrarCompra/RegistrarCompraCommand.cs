using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.Produto.Command.RegistrarProduto
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<Item> Itens { get; set; }
        public int CondicaoPagamento { get; set; }
    }
}
