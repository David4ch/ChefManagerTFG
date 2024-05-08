using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefManager.Modelo
{
    public class Nota
    {
        public string Id { get; set; }
        public string Restaurante_Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime Date { get; set; }
    }
}
