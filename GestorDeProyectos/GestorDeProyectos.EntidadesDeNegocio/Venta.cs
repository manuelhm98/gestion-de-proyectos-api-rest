using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        [Display(Name = "Fecha de Venta")]
        public DateTime FechaDeVenta { get; set; }
        [Required(ErrorMessage = "Monto total es obligatorio")]
        public decimal MontoTotal { get; set; }
        [ForeignKey("Producto")]
        [Required(ErrorMessage = "Producto es obligatorio")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        public Producto Producto { get; set; }
        public Cliente Cliente { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }

    public enum Estatus_Venta
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
