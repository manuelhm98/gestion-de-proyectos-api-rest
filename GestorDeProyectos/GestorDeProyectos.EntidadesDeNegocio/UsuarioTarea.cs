using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class UsuarioTarea
    {
        [Key]
        public int IdUsuarioTarea { get; set; }
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("Tarea")]
        [Required(ErrorMessage = "Tarea es obligatorio")]
        [Display(Name = "Tarea")]
        public int IdTarea { get; set; }
        public byte Estatus { get; set; }
        public Usuario Usuario { get; set; }
        public Tarea Tarea { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
    public enum Estatus_UsuarioTarea
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
