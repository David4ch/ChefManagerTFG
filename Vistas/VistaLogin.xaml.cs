using FireSharp.Config;
using FireSharp.Interfaces;

namespace ChefManager.Vistas;

public partial class VistaLogin : ContentPage
{
    IFirebaseConfig config = new FirebaseConfig{
            AuthSecret = "H58xpKu2FTVE58DvJcVWSmRTbaPmlZkjJuvdzr7O",
            BasePath= "https://chefmg-664a2-default-rtdb.europe-west1.firebasedatabase.app/"


    };
    IFirebaseClient client;

    public VistaLogin()
	{	
		InitializeComponent();
        client = new FireSharp.FirebaseClient(config);
        if (client != null)
        {
            System.Diagnostics.Debug.WriteLine("CONECTADO MAAAAN");
        }
        else {
            System.Diagnostics.Debug.WriteLine("Que pringao");
        }
	}
}