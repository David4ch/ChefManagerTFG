
namespace ChefManager.Modelo
{
    public class Tiempo
    {
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
    }
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Main
    {
        public decimal Temp { get; set; }
        public decimal Feels_like { get; set; }
        public decimal Temp_min { get; set; }
        public decimal Temp_max { get; set; }
    }
}
