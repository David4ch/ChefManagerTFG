using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefManager.Modelo
{
    class Producto
    {
        public string Id { get; set; }
        public string Restaurante_Id { get; set; }
        public string Nombre { get; set; }
        public string Proveedor { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }


    }

    
}
