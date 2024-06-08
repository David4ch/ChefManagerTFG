using System.Text;

namespace ChefManager.Modelo
{
    public class Encriptacion
    {
        public static string Encriptar(string cadena)
        {

            return Convert.ToBase64String(Encoding.Unicode.GetBytes(cadena));
        }

        public static string Desencriptar(string cadena)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(cadena));
        }

    }

}
