using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeProyectos.EntidadesDeNegocio.Paginación
{
    public class ListPagVenta : PagModel
    {
        public List<Venta> Ventas { get; set; }
    }
}
