using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            if (qtde <= 0) throw new BusinessRuleException("O total de itens de compra deve ser maior que 0!");

            if (produto == null) throw new BusinessRuleException("Sem produto!");

            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens, int? condicao)
        {
            decimal totalGeral = 0;
            if (itens.Count() == 0 ) throw new BusinessRuleException("O total de itens de compra deve ser maior que 0!");

            foreach (var item in itens)
            {
                totalGeral += item.Subtotal.Value;
            }

            if (totalGeral > 50000 && condicao != 30)
            {
                new CondicaoPagamento(30);
            }

           // AddEvent(new CompraRegistradaEvent(itens, totalGeral));

        }
    }
}
