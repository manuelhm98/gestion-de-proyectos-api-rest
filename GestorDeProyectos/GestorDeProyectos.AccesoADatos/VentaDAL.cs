using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using GestorDeProyectos.EntidadesDeNegocio;

namespace GestorDeProyectos.AccesoADatos
{
    public class VentaDAL
    {
        public static async Task<int> CrearAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.IdVenta == pVenta.IdVenta);
                venta.FechaDeVenta = pVenta.FechaDeVenta;
                venta.MontoTotal = pVenta.MontoTotal;
                venta.IdProducto = pVenta.IdProducto;
                venta.IdCliente = pVenta.IdCliente;
                venta.Estatus = pVenta.Estatus;
                bdContexto.Update(venta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.IdVenta == pVenta.IdVenta);
                bdContexto.Venta.Remove(venta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            var venta = new Venta();
            using (var bdContexto = new BDContexto())
            {
                venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.IdVenta == pVenta.IdVenta);
            }
            return venta;
        }

        public static async Task<List<Venta>> ObtenerTodosAsync()
        {
            var ventas = new List<Venta>();
            using (var bdContexto = new BDContexto())
            {
                ventas = await bdContexto.Venta.ToListAsync();
            }
            return ventas;
        }

        internal static IQueryable<Venta> QuerySelect(IQueryable<Venta> pQuery, Venta pVenta)
        {
            if (pVenta.IdVenta > 0)
                pQuery = pQuery.Where(s => s.IdVenta == pVenta.IdVenta);
            if (pVenta.MontoTotal > 0)
                pQuery = pQuery.Where(s => s.MontoTotal == pVenta.MontoTotal);
            if (pVenta.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pVenta.IdProducto);
            if (pVenta.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pVenta.IdCliente);
            if (pVenta.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pVenta.Estatus);
            pQuery = pQuery.OrderByDescending(s => s.IdVenta).AsQueryable();
            if (pVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pVenta.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            var ventas = new List<Venta>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Venta.AsQueryable();
                select = QuerySelect(select, pVenta);
                ventas = await select.ToListAsync();
            }
            return ventas;
        }
    }
}
