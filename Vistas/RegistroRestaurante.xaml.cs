using ChefManager.Modelo;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace ChefManager.Vistas;

public partial class RegistroRestaurante : ContentPage
{
    IFirebaseConfig config = new FirebaseConfig
    {
        AuthSecret = "H58xpKu2FTVE58DvJcVWSmRTbaPmlZkjJuvdzr7O",
        BasePath = "https://chefmg-664a2-default-rtdb.europe-west1.firebasedatabase.app/"


    };
    IFirebaseClient client;

    public RegistroRestaurante()
	{
        
        InitializeComponent();
    }

    private void radiobutton1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        fondo1.BackgroundColor = Colors.Gray;
        entryNombre.IsEnabled = false;
        entryDireccion.IsEnabled = false;
        boton.Text = "Ir a Inicio Sesión";
    }
    private void radiobutton2_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        
        fondo1.BackgroundColor = Colors.White;
        entryNombre.IsEnabled = true;
        entryDireccion.IsEnabled = true;
        boton.Text = "Registrar";
    }

    private async void boton_Clicked(object sender, EventArgs e)
    {
        try {
        Restaurante restaurante = new Restaurante
        {
            Nombre = entryNombre.Text,
            Direccion = entryDireccion.Text,
            Logo = entryLogo.Text,

          
        };
            SetResponse response = await client.SetAsync("RestauranteDatabase/" + restaurante.Id, restaurante);
        }
        catch (Exception) {
            System.Diagnostics.Debug.WriteLine("Error");

            throw;
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        
        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {
            var memoriaStream = await foto.OpenReadAsync();
            entryLogo.Text = foto.FileName;

            // img.Source = ImageSource.FromStream(() => memoriaStream);
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

        client = new FireSharp.FirebaseClient(config);
    }
}