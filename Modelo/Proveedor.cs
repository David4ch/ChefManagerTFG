﻿
namespace ChefManager.Modelo
{
    public class Proveedor
    {
        public string Id { get; set; }
        public string Restaurante_Id { get; set; }
        public string NombreEmpresa { get; set; }
        public int Contacto { get; set; }
        public string TipoProducto { get; set; }
        public string Descripción { get; set; }
        public string Periocidad { get; set; }
        public decimal Precio { get; set; }
    }
}
