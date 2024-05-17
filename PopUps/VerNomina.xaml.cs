using ChefManager.Templates;
using CommunityToolkit.Maui.Views;

namespace ChefManager.PopUps;

public partial class VerNomina : Popup
{
	

	public VerNomina()
	{
		InitializeComponent();
		imgNomina.Source = TemplateEmpleados._sourceNomina;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}