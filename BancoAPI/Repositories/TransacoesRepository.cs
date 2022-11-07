using BancoAPI.Interfaces;
using BancoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAPI.Repositories
{
    public class TransacoesRepository : ITransacaoRepository
    {
        private readonly testemasterContext _context;

        public TransacoesRepository(testemasterContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Transferir(TbTransacoes transacao)
        {
            var ultimatransacao = await _context.TbTransacoes.OrderBy(prop => prop.Id).LastAsync();
            var tbtransacao = new TbTransacoes
            {
                Id = ultimatransacao.Id+1,
                Valor = transacao.Valor,
                ChaveDestino = transacao.ChaveDestino,
                FkCliente = transacao.FkCliente,
            };
            Console.WriteLine(tbtransacao.Id);
            await _context.AddAsync(tbtransacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TbTransacoes>> VerTodas()
        {
            return await _context.TbTransacoes.ToListAsync();
        }
    }
}
