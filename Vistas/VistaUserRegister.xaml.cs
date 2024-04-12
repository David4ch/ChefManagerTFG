namespace ChefManager.Vistas;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

public partial class VistaUserRegister : ContentPage
{
	public VistaUserRegister()
	{
		InitializeComponent();

     

        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://chefmanager.firebaseio.com/"
        };

        IFirebaseClient client = new FirebaseClient(config);

       
    }

}