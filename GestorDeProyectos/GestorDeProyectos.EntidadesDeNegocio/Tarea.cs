using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Descripcion { get; set; }
        [ForeignKey("Proyecto")]
        [Required(ErrorMessage = "Proyecto es obligatorio")]
        [Display(Name = "Proyecto")]
        public int IdProyecto { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaDeInicio { get; set; }
        [Display(Name = "Fecha de Finalizacion")]
        public DateTime FechaDeFinalizacion { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        public Proyecto Proyecto { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
    public enum Estatus_Tarea
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
