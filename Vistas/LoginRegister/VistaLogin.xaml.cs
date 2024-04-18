using FireSharp.Config;
using FireSharp.Interfaces;

namespace ChefManager.Vistas;

public partial class VistaLogin : ContentPage
{
  

    public VistaLogin()
	{	
		InitializeComponent();
        
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (entryEmail.Text.Equals("admin") && entryPassword.Text.Equals("1234"))
        {
            await AppShell.Current.GoToAsync(nameof(VistaAdmin));
        }
        else {
            await AppShell.Current.GoToAsync(nameof(VistaPrinc));
        }
    }
}