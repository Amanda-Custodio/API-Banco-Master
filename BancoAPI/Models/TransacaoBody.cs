using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoAPI.Models
{
    public class TransacaoBody
    {
        public int Id_de_Cliente { get; set; }

        public string ChaveDestino { get; set; }

        public double Valor { get; set; }
    }
}
