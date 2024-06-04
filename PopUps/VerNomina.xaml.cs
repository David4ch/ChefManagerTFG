using ChefManager.Vistas;
using CommunityToolkit.Maui.Views;

namespace ChefManager.PopUps;

public partial class VerNomina : Popup
{
	

	public VerNomina()
	{
		InitializeComponent();
		imgNomina.Source = Empleados._sourceNomina;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}