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

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton imgbutton = (ImageButton)sender;
        imgbutton.WidthRequest = 110;
        imgbutton.HeightRequest = 110;
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton imgbutton = (ImageButton)sender;
        imgbutton.WidthRequest = 90;
        imgbutton.HeightRequest = 90;
    }
}