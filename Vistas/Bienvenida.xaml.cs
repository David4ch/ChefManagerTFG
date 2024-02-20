namespace ChefManager.Vistas;

public partial class Bienvenida : ContentPage
{
	public Bienvenida()
	{
		InitializeComponent();
	}
    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            await AppShell.Current.GoToAsync(nameof(VistaRegister));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Processing failed: {ex.Message}");
        }
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            await AppShell.Current.GoToAsync(nameof(VistaLogin));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Processing failed: {ex.Message}");
        }
    }
/*
        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {
            var memoriaStream = await foto.OpenReadAsync();
            img.Source = ImageSource.FromStream(() => memoriaStream);
        }*/
}