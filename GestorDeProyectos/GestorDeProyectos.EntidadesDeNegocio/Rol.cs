using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        [ForeignKey("TipoRol")]
        [Required(ErrorMessage = "TipoRol es obligatorio")]
        [Display(Name = "TipoRol")]
        public int IdTipoRol { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        public TipoRol TipoRol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Usuario> Usuario { get; set; }
    }
    public enum Estatus_Rol
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
