using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class Proyecto
    {
        [Key]
        public int IdProyecto { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Periodo de Desarrollo es obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string PeriodoDeDesarrollo { get; set; }
        [ForeignKey("Producto")]
        [Required(ErrorMessage = "Producto es obligatorio")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        public Producto Producto { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }

    public enum Estatus_Proyecto
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
