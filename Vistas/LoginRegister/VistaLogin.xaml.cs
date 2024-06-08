
namespace ChefManager.Vistas;

public partial class VistaLogin : ContentPage
{
  

    public VistaLogin()
	{	
		InitializeComponent();
        
	}

    private async void Volver(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(Bienvenida));
    }
}