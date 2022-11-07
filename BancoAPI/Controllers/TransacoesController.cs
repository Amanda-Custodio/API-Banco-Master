using BancoAPI.Interfaces;
using BancoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoAPI.Controllers
{
    [ApiController]
    [Route("api/transferência")]
    public class TransacoesController : Controller
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IClienteRepository _clienteRepository;

        public TransacoesController(ITransacaoRepository transacaoRepository, IClienteRepository clienteRepository)
        {
            _transacaoRepository = transacaoRepository;
            _clienteRepository = clienteRepository;
        }
      

        [HttpGet("Transfências")]
        public async Task<ActionResult<IEnumerable<TbTransacoes>>> GetAll()
        {
            return Ok(await _transacaoRepository.VerTodas());
        }

        [HttpPost("TransferirPix")]
        public async Task<ActionResult> TransferirPix (TransacaoBody transacao)
        {
            var cliente = await _clienteRepository.SelecionarById(transacao.Id_de_Cliente);

            if(cliente == null)
            {
                return BadRequest("Cliente não existente");
            }

            if(cliente.Saldo < transacao.Valor)
            {
                return BadRequest("Saldo insuficiente");
            }

            var clienteDestino = await _clienteRepository.SelecionarByChave(transacao.ChaveDestino);

            if(clienteDestino != null)
            {
                cliente.Saldo = cliente.Saldo - transacao.Valor;

                clienteDestino.Saldo = clienteDestino.Saldo + transacao.Valor;

                await _clienteRepository.Atualizar(cliente);
                await _clienteRepository.Atualizar(clienteDestino);

                var transferenciaPix = new TbTransacoes();
                transferenciaPix.Valor = transacao.Valor;
                transferenciaPix.ChaveDestino = transacao.ChaveDestino;
                transferenciaPix.FkCliente = cliente.Id;

                await _transacaoRepository.Transferir(transferenciaPix);
                return Ok("Transação realizada com sucesso");
            }

            cliente.Saldo = cliente.Saldo - transacao.Valor;

            await _clienteRepository.Atualizar(cliente);

            var transferencia = new TbTransacoes();
            transferencia.Valor = transacao.Valor;
            transferencia.ChaveDestino = transacao.ChaveDestino;
            transferencia.FkCliente = cliente.Id;

            await _transacaoRepository.Transferir(transferencia);
            return Ok("Transação realizada com sucesso");
        }
    }
}
