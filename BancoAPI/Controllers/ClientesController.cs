using BancoAPI.Interfaces;
using BancoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clientesRepository;

        public ClientesController(IClienteRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet("ConsultarClientes")]
        public async Task<ActionResult<IEnumerable<Clientes>>> ConsultarCliente()
        {
            return Ok(await _clientesRepository.SelecionarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ConsultarById (int id)
        {
            var cliente = await _clientesRepository.SelecionarById(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(cliente);
        }

        [HttpPost("CadastrarCliente")]
        public async Task<ActionResult> CadastrarCliente (Clientes cliente)
        {
            _clientesRepository.Incluir(cliente);
            if (await _clientesRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso");
            }
            return BadRequest("houve um erro ao cadastrar novo cliente");
        }
    }
}
