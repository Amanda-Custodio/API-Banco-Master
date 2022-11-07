using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Models
{
    [Table("tb_Transacoes")]
    public partial class TbTransacoes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(40)]
        public string ChaveDestino { get; set; }
        public double? Valor { get; set; }

        [Column("fk_Cliente")]
        public int FkCliente { get; set; }

        [ForeignKey(nameof(FkCliente))]
        [InverseProperty(nameof(Clientes.TbTransacoes))]
        public virtual Clientes FkClienteNavigation { get; set; }
    }
}