using BancoAPI.Interfaces;
using BancoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAPI.Repositories
{
    public class ClientesRepository : IClienteRepository
    {
        private readonly testemasterContext _context;

        public ClientesRepository(testemasterContext context)
        {
            _context = context;
        }

        public void Incluir(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Clientes> SelecionarById(int id)
        {
            var cliente = await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<Clientes> SelecionarByChave(string chaveOrigem)
        {
            var cliente = await _context.Clientes.Where(c => c.ChaveOrigem == chaveOrigem).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<IEnumerable<Clientes>> SelecionarTodos()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> Atualizar(Clientes cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
