namespace ChefManager.Vistas;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

public partial class VistaRegister : ContentPage
{
	public VistaRegister()
	{
		InitializeComponent();
        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://chefmanager.firebaseio.com/"
        };

        IFirebaseClient client = new FirebaseClient(config);

       
    }

}