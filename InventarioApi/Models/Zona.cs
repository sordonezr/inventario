using System;
using System.Collections.Generic;

namespace InventarioApi.Models
{
    public partial class Zona
    {
        public Zona()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
