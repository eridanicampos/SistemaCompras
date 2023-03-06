using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.Produto.Query.ObterProduto
{
    public class RegistrarCompraViewModel
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<ItemViewModel> Itens { get; set; }
        public int CondicaoPagamento { get; set; }
    }

    public class ItemViewModel
    {
        public ProdutoViewModel Produto { get; set; }
      
        public int Qtde { get; set; }


    }

    public class MoneyViewModel
    {
        public decimal Value { get; set; }
    }

    public class ProdutoViewModel
    {
        public Categoria Categoria { get; set; }
        public MoneyViewModel Preco { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public Situacao Situacao { get; set; }
    }
}
