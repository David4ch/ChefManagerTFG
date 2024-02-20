namespace ChefManager.Vistas;

public partial class VistaPrinc : ContentPage
{
	public VistaPrinc()
	{
		InitializeComponent();
	}
	

    private void ImageButton_Released(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Chao chao cao");
    }
}