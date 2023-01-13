using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeProyectos.EntidadesDeNegocio
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Producto> Producto { get; set; }
    }

    public enum Estatus_Categoria
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
