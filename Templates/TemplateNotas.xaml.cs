using ChefManager.Vistas.MainPage;

namespace ChefManager.Templates;

public partial class TemplateNotas : ContentView
{
    public static string _idNota;
	public TemplateNotas()
	{
		InitializeComponent();

	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        _idNota = idNota.Text;
        AppShell.Current.GoToAsync(nameof(VerNota));
    }
}