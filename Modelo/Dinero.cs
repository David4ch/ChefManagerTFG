using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefManager.Modelo
{
    public class Dinero
    {
        public string Id { get; set; }
        public string Restaurante_Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public string Turno { get; set; }

    }
}
