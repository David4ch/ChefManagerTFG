using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefManager.Modelo
{
    public class Empleado
    {

        public string Id { get; set; }
        public string Restaurante_Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string ImagenNomina { get; set; }
        public string Contacto { get; set; }
        public bool Disponibilidad { get; set; }

    }

}
