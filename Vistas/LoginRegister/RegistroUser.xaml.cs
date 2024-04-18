namespace ChefManager.Vistas;

using ChefManager.Modelo;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

public partial class RegistroUser : ContentPage
{
    FirebaseConnection connection = new FirebaseConnection();

    public RegistroUser()
	{
		InitializeComponent();  
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario
        {
            Id = Guid.NewGuid().ToString(),
            Restaurante_Id = RegistroRestaurante._idRestaurante,
            NombreUser = entryNombreUser.Text,
            Email = entryCorreo.Text,
            Contrasena = entryContrasena.Text,


        };
        var SetData = connection.client.SetAsync("UsuarioDatabase/" + usuario.Id, usuario);

        await AppShell.Current.GoToAsync(nameof(VistaLogin));
    }
}