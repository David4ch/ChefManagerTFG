using ChefManager.Modelo;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;

namespace ChefManager.Vistas;

public partial class RegistroRestaurante : ContentPage
{
    public static string _idRestaurante;
    string authDomain = "chefmg-664a2.firebaseapp.com";
    string api_key = "AIzaSyCyrx6jgU-a2dnYYOqlMX2k_8tbO1ia1rw";
    string email = "admin@gmail.com";
    string contrasena = "123456";
    string token = string.Empty;
    string rutaStorage = "chefmg-664a2.appspot.com";
    public static string _urlDescarga;


    public RegistroRestaurante()
    {

        InitializeComponent();
        MainThread.BeginInvokeOnMainThread(new Action(async ()=> await obtenerToken()));
            
    }


    //Metodo para subir fotos al Storage
    private async Task obtenerToken()
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

    private async void ImageButton_Clicked(object sender, EventArgs e)
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

            entryLogo.Text = foto.FileName;
            _urlDescarga = urlDescarga;
            
        }
    }

}