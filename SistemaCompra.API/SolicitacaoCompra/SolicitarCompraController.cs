using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.Produto.Command.AtualizarPreco;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using System;

namespace SistemaCompra.API.Produto
{
    public class SolicitarCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitarCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        //[HttpGet, Route("solicitarCompra/{id}")]
        //public IActionResult Obter(Guid id)
        //{
        //    var query = new ObterProdutoQuery() { Id = id };
        //    var produtoViewModel = _mediator.Send(query);
        //    return Ok(produtoViewModel);
        //}

        [HttpPost, Route("solicitarCompra/cadastrar")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarSolicitacaoCompra([FromBody] RegistrarCompraCommand registrarCompraCommand)
        {
            _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }

      
    }
}
