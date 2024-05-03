using ChefManager.Modelo;
using ChefManager.Vistas;

namespace ChefManager.Templates;

public partial class TemplateUsuarios : ContentView
{
    FirebaseConnection connection = new FirebaseConnection();
    VistaAdmin admin = new VistaAdmin();

    public TemplateUsuarios()
	{
		InitializeComponent();
        
    }
   
    private void ImageEdit_Clicked(object sender, EventArgs e)
    {

    }

    private async void ImageDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            var SetData = connection.client.Delete("UsuarioDatabase/" + labelId.Text);
            admin.actualizarLista("Usuarios");
            await Application.Current.MainPage.DisplayAlert("!¡", "Usuario eliminado correctamente", "De acuerdo");
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar el usuario");
        }
    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        switch (button.Source.ToString())
        {
            case "File: editar.png":
                button.BackgroundColor = Colors.LightBlue;
                button.RotateYTo(360, 500);
                break;
            case "File: eliminar.png":
                button.BackgroundColor = Colors.Red;
                button.RotateYTo(360, 500);
                break;
          
            default:
                break;
        }

    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.LightGray;

    }

}