using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        [Display(Name = "Fecha Pedido")]
        public DateTime FechaPedido { get; set; }
        [Display(Name = "Fecha Entrega")]
        public DateTime FechaEntrega { get; set; }
        [Required(ErrorMessage = "Monto total es obligatorio")]
        public decimal MontoTotal { get; set; }
        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        public Cliente Cliente { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }

    public enum Estatus_Pedido
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
