using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Maui.Views;
namespace ChefManager.PopUps;

public partial class AgregarProveedor : Popup
{
    string pickerPeriocidad;

    string pickerTipo;

    FirebaseConnection connection = new FirebaseConnection();


    public AgregarProveedor()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (entryNombre.Text.Length != 0 && entryNumero.Text.Length != 0 && entryPrecio.Text.Length != 0 && entryDescripcion.Text.Length != 0)
        {
            if (decimal.TryParse(entryPrecio.Text, out decimal numeroDecimal))
            {

                Proveedor proveedor = new Proveedor
                {
                    Id = Guid.NewGuid().ToString(),
                    Restaurante_Id = VistaPrinc._restauranteId,
                    NombreEmpresa = entryNombre.Text,
                    Contacto = int.Parse(entryNumero.Text),
                    TipoProducto = pickerTipo,
                    Descripción = entryDescripcion.Text,
                    Precio = decimal.Parse(entryPrecio.Text),
                    Periocidad = pickerPeriocidad
                };
                var SetData = connection.client.SetAsync("ProveedorDatabase/" + proveedor.Id, proveedor);

                await AppShell.Current.DisplayAlert("¡!", "Proveedor Añadido Correctamente", "Ok");

                Close();

            }
            else
            {
                await AppShell.Current.DisplayAlert("Error", "El campo Precio tiene que ser numero \n Ej: 22,00 o 22", "Ok");
            }
        }
        else
        {

            await AppShell.Current.DisplayAlert("Error", "Los campos no pueden estar vacíos", "Gracias");
        }

    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        pickerTipo = picker.SelectedItem as string;
    }

    private void Picker_SelectedIndexChanged2(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        pickerPeriocidad = picker.SelectedItem as string;
    }
}