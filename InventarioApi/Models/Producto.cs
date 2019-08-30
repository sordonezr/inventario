using System;
using System.Collections.Generic;

namespace InventarioApi.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public int? IdMarca { get; set; }
        public int? IdPresentacion { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdZona { get; set; }
        public string Serial { get; set; }
        public string Descripcion { get; set; }
        public decimal? ValorCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string EstadoActual { get; set; }

        public Marca IdMarcaNavigation { get; set; }
        public Presentacion IdPresentacionNavigation { get; set; }
        public Proveedor IdProveedorNavigation { get; set; }
        public Zona IdZonaNavigation { get; set; }
    }
}
