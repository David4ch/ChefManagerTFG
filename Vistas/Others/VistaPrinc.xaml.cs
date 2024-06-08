using ChefManager.Modelo;
using Newtonsoft.Json;
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
        IniciarTiempo();
        nombreUser.Text = "Hola, " + _user + "!";
	}

    private async void IniciarTiempo()
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
            labelGradosMinMax.Text = "M�x "  + numero1 + "�  /  " +  numero2+ "�";
            labelUbi.Text = _ubicacion;
            labelGrados.Text = numero0 + "�";
            labelSensacion.Text = "Sens t�rmica: " + numero3 + "�";
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
                AppShell.Current.GoToAsync(nameof(Caja));
                break;
            case "File: calendario.png":
                AppShell.Current.GoToAsync(nameof(Calendario));
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

    private async void EliminarCuenta_Clicked(object sender, EventArgs e)
    {
        FirebaseConnection connection = new FirebaseConnection();
        bool answer = await DisplayAlert("Confirmaci�n", "Se va a eliminar tu cuenta, pero los datos del restaurante seguir�n intactos", "Aceptar", "Cancelar");
        if (answer)
        {
            Usuario usuario = connection.obtenerInfo<Usuario>("UsuarioDatabase").FirstOrDefault(u => u.NombreUser.Equals(nombreUser.Text));
            var SetData = connection.client.Delete("RestauranteDatabase/" + usuario.Id);
            await Application.Current.MainPage.DisplayAlert("!�", "Elemento eliminado correctamente", "De acuerdo");
        }
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaLogin));
    }
}