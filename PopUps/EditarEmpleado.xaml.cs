using ChefManager.Modelo;
using ChefManager.Templates;
using CommunityToolkit.Maui.Views;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Maui.ApplicationModel.Communication;
using ChefManager.Vistas;

namespace ChefManager.PopUps;

public partial class EditarEmpleado : Popup
{
    string authDomain = "chefmg-664a2.firebaseapp.com";
    string api_key = "AIzaSyCyrx6jgU-a2dnYYOqlMX2k_8tbO1ia1rw";
    string email = "admin@gmail.com";
    string contrasena = "123456";
    string token = string.Empty;
    string rutaStorage = "chefmg-664a2.appspot.com";
    string _urlDescarga = "";
    string _entryImagenFinal = "";
	FirebaseConnection connection = new FirebaseConnection();

	public EditarEmpleado()
	{
		InitializeComponent();
        MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerToken()));
        EstablecerEntrys();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (entryNombre.Text.Length != 0 && entryPuesto.Text.Length != 0 && entryContacto.Text.Length != 0 && entryImagen.Text.Length != 0)
        {
            Empleado empleado_old = connection.obtenerInfo<Empleado>("EmpleadoDatabase").FirstOrDefault(u => u.Id.Equals(Empleados._idEmpleado));

            _entryImagenFinal = (entryImagen.Text == Path.GetFileName(new Uri(empleado_old.ImagenNomina).LocalPath)) ? empleado_old.ImagenNomina : _urlDescarga;


            Empleado empleado = new Empleado
            {
                Id = empleado_old.Id,
                Restaurante_Id = empleado_old.Restaurante_Id,
                Nombre = entryNombre.Text,
                Puesto = entryPuesto.Text,
                Contacto = entryContacto.Text,
                ImagenNomina = _entryImagenFinal,
                Disponibilidad = switchh.IsToggled
            };

            var Set = connection.client.Update("EmpleadoDatabase/" + empleado.Id, empleado);

            await AppShell.Current.DisplayAlert("¡!", "Empleado Editado Correctamente", "Ok");

            await AppShell.Current.GoToAsync(nameof(Empleados));

            Close();
        }
        else
        {
            await AppShell.Current.DisplayAlert("ERROR", "Los campos no pueden estar vacíos", "Ok");
        }
        
    }

	private void EstablecerEntrys() {
		Empleado empleado = connection.obtenerInfo<Empleado>("EmpleadoDatabase").FirstOrDefault(u=> u.Id.Equals(Empleados._idEmpleado));

		entryNombre.Text = empleado.Nombre;
		entryPuesto.Text = empleado.Puesto;
		entryImagen.Text = Path.GetFileName(new Uri(empleado.ImagenNomina).LocalPath);
		entryContacto.Text = empleado.Contacto;
		switchh.IsToggled = empleado.Disponibilidad;

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