namespace ChefManager.Vistas;

public partial class VistaPrinc : ContentPage
{
	public VistaPrinc()
	{
		InitializeComponent();
        imgLogo.Source = "https://firebasestorage.googleapis.com/v0/b/chefmg-664a2.appspot.com/o/Imagenes%2Fchefmg.png?alt=media&token=75317dde-76a5-4395-bff8-fa82c19db5a2";
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