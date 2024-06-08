
namespace ChefManager.Modelo
{
    public class Producto
    {
        public required String Id { get; set; }
        public required String Restaurante_Id { get; set; }
        public required String Nombre { get; set; }
        public required String Proveedor { get; set; }
        public required int Cantidad { get; set; }
        public required decimal Precio { get; set; }
        public required String Imagen { get; set; }


    }

    
}
