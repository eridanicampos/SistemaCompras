using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.Produto.Query.ObterProduto
{
    public class ObterCompraViewModel
    {
        public DateTime Data { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public int Situacao { get; set; }
    }

}
