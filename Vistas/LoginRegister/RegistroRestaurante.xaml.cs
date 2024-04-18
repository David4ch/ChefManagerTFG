using ChefManager.Modelo;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace ChefManager.Vistas;

public partial class RegistroRestaurante : ContentPage
{
    FirebaseConnection connection = new FirebaseConnection();
    public static string _idRestaurante;


    public RegistroRestaurante()
    {

        InitializeComponent();
    }

    private async void boton_Clicked(object sender, EventArgs e)
    {
        try
        {

            Restaurante restaurante = new Restaurante
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = entryNombre.Text,
                Direccion = entryDireccion.Text,
                Logo = entryLogo.Text,


            };

            var SetData = connection.client.SetAsync("RestauranteDatabase/" + restaurante.Id, restaurante);

            _idRestaurante = restaurante.Id;

            await AppShell.Current.GoToAsync(nameof(RegistroUser));


        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error upload");

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
}