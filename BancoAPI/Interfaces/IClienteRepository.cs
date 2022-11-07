using BancoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoAPI.Interfaces
{
    public interface IClienteRepository
    {
        void Incluir(Clientes cliente);

        Task<Clientes> SelecionarById(int id);

        Task<IEnumerable<Clientes>> SelecionarTodos();

        Task<Clientes> SelecionarByChave(string chaveOrigem);

        Task<Clientes> Atualizar(Clientes cliente);

        Task<bool> SaveAllAsync();
    }
}
