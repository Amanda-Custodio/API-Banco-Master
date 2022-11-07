using BancoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoAPI.Interfaces
{
    public interface ITransacaoRepository
    {
        Task Transferir(TbTransacoes transacao);

        Task<IEnumerable<TbTransacoes>> VerTodas();

        Task<bool> SaveAllAsync();
    }
}
