﻿using SistemaCompra.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class NomeFornecedor
    {
        public string Nome { get; }

        private NomeFornecedor() { }

        public NomeFornecedor(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
          
            Nome = nome;
        }
    }
}
