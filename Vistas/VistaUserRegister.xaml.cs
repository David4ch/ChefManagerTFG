namespace ChefManager.Vistas;

using ChefManager.Modelo;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

public partial class VistaUserRegister : ContentPage
{
    FirebaseConnection connection = new FirebaseConnection();

    public VistaUserRegister()
	{
		InitializeComponent();  
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario
        {
            Restaurante_Id = RegistroRestaurante._idRestaurante,
            Id = Guid.NewGuid().ToString(),
            NombreUser = entryNombreUser.Text,
            Email = entryCorreo.Text,
            Contrasena = entryContrasena.Text,


        };
        var SetData = connection.client.SetAsync("UsuarioDatabase/" + usuario.Id, usuario);

        await AppShell.Current.GoToAsync(nameof(VistaLogin));
    }
}