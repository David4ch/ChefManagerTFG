using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Maui.Views;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Storage;

namespace ChefManager.PopUps;

public partial class AgregarEmpleado : Popup
{
    FirebaseConnection connection = new FirebaseConnection();

    string authDomain = "chefmg-664a2.firebaseapp.com";
    string api_key = "AIzaSyCyrx6jgU-a2dnYYOqlMX2k_8tbO1ia1rw";
    string email = "admin@gmail.com";
    string contrasena = "123456";
    string token = string.Empty;
    string rutaStorage = "chefmg-664a2.appspot.com";
    string _urlDescarga = "";

    public AgregarEmpleado()
    {
        InitializeComponent();
        MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerToken()));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (entryNombre.Text.Length != 0 && entryPuesto.Text.Length != 0 && entryContacto.Text.Length != 0 && entryImagen.Text.Length != 0)
        {
            Empleado empleado = new()
            {
                Id = Guid.NewGuid().ToString(),
                Restaurante_Id = VistaPrinc._restauranteId,
                Nombre = entryNombre.Text,
                Puesto = entryPuesto.Text,
                Contacto = entryContacto.Text,
                ImagenNomina = _urlDescarga,
                Disponibilidad = switchh.IsToggled
            };

            var SetData = connection.client.SetAsync("EmpleadoDatabase/" + empleado.Id, empleado);

            await AppShell.Current.DisplayAlert("¡!", "Empleado Añadido Correctamente", "Ok");

            Close();
        }
        else
        {
            await AppShell.Current.DisplayAlert("ERROR", "Los campos no pueden estar vacíos", "Ok");
        }
    }

    private async Task ObtenerToken()
    {

        var client = new FirebaseAuthClient(new FirebaseAuthConfig()
        {

            ApiKey = api_key,
            AuthDomain = authDomain,
            Providers = new FirebaseAuthProvider[]
            {
                    new EmailProvider()
            }
        });

        var credenciales = await client.SignInWithEmailAndPasswordAsync(email, contrasena);
        token = await credenciales.User.GetIdTokenAsync();

    }
    private async void SubirFoto(object sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {

            var task = new FirebaseStorage(
                rutaStorage,
                new FirebaseStorageOptions
                {

                    AuthTokenAsyncFactory = () => Task.FromResult(token),
                    ThrowOnCancel = true
                }
              )
                .Child("Imagenes")
                .Child(foto.FileName)
                .PutAsync(await foto.OpenReadAsync());

            var urlDescarga = await task;
            _urlDescarga = urlDescarga;
            entryImagen.Text = foto.FileName;

        }
    }
}