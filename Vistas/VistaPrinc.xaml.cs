namespace ChefManager.Vistas;

public partial class VistaPrinc : ContentPage
{
	public VistaPrinc()
	{
		InitializeComponent();
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