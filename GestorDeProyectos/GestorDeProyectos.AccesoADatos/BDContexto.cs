using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<TipoRol> TipoRol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioTarea> UsuarioTarea { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuiler)
        {
            optionBuiler.UseSqlServer(@"Data Source=MANUELDEV98;Initial Catalog=GestorDeProyectos;Integrated Security=True");
        }
    }

}
