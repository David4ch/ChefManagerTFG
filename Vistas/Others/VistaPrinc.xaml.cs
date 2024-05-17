using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace ChefManager.Vistas;

public partial class VistaPrinc : ContentPage
{
    public static string _user;
    public static string _ubicacion;
    public static string _logo;
    public static string _restauranteId;

	public VistaPrinc()
	{
		InitializeComponent();
        iniciarTiempo();
	}

    private async void iniciarTiempo()
    {
        string host = "https://api.openweathermap.org/data/2.5/weather?q= "+ _ubicacion + "&APPID=aca455c6610e2d9e9420cd2245432faf";
        HttpClient resultado = new HttpClient();

        string cadena = await resultado.GetStringAsync(host);
        Modelo.Tiempo tiempo = JsonConvert.DeserializeObject<Modelo.Tiempo>(cadena);
        var tiempoObservable = new ObservableCollection<Modelo.Tiempo>
            {
                tiempo
            };

        foreach (Modelo.Tiempo temp in tiempoObservable)
        {
            decimal numero0 = Math.Round(temp.Main.Temp - 273, 0);
            int numero1 = Convert.ToInt32(temp.Main.Temp_max) - 273;
            int numero2 = Convert.ToInt32(temp.Main.Temp_min) - 273;
            int numero3 = Convert.ToInt32(temp.Main.Feels_like) - 273;
            imgLogo.Source = _logo;
            labelTiempoMain.Text = temp.Weather[0].Main + ", " +  temp.Weather[0].Description ;
            labelGradosMinMax.Text = "Máx "  + numero1 + "º  /  " +  numero2+ "º";
            labelUbi.Text = _ubicacion;
            labelGrados.Text = numero0 + "º";
            labelSensacion.Text = "Sens térmica: " + numero3 + "º";
            imgUbicacion.Source = "https://openweathermap.org/img/wn/" + temp.Weather[0].Icon + "@2x.png";



        }

    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton imgbutton = (ImageButton)sender;
        imgbutton.WidthRequest = 110;
        imgbutton.HeightRequest = 110;
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton imgbutton = (ImageButton)sender;
        imgbutton.WidthRequest = 90;
        imgbutton.HeightRequest = 90;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        ImageButton imgbutton = (ImageButton)sender;
         switch (imgbutton.Source.ToString()) {

            case "File: inventario.png":
                AppShell.Current.GoToAsync(nameof(Inventario));
                break;
            case "File: proveedores.png":
                AppShell.Current.GoToAsync(nameof(Proveedores));
                break;
            case "File: caja.png":
                break;
            case "File: calendario.png":
                break;
            case "File: empleados.png":
                AppShell.Current.GoToAsync(nameof(Empleados));
                break;
            case "File: notas.png":
                 AppShell.Current.GoToAsync(nameof(Notas));
                break;
            default:
            
                break;
        }
    }
}