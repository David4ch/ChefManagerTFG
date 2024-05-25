using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Maui.Views;
namespace ChefManager.PopUps;

public partial class AgregarProveedor : Popup
{

    FirebaseConnection connection = new FirebaseConnection();

    public AgregarProveedor()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (entryNombre.Text.Length != 0 && entryNumero.Text.Length != 0 && entryPrecio.Text.Length != 0 && entryDescripcion.Text.Length != 0 && entryDia.Text.Length != 0 && pickerPeriocidad.SelectedIndex != -1 && pickerProducto.SelectedIndex != -1)
        {
            if (decimal.TryParse(entryPrecio.Text, out decimal numeroDecimal) && int.TryParse(entryNumero.Text, out int numeroInt))
            {
                if (ValidarDia())
                {
                    Proveedor proveedor = new Proveedor
                    {
                        Id = Guid.NewGuid().ToString(),
                        Restaurante_Id = VistaPrinc._restauranteId,
                        NombreEmpresa = entryNombre.Text,
                        Contacto = numeroInt,
                        TipoProducto = pickerProducto.SelectedItem.ToString(),
                        Descripción = entryDescripcion.Text,
                        Precio = numeroDecimal,
                        Periocidad = pickerPeriocidad.SelectedItem.ToString() + "-" + entryDia.Text
                    };

                    await connection.client.SetAsync("ProveedorDatabase/" + proveedor.Id, proveedor);

                    await AppShell.Current.DisplayAlert("¡!", "Proveedor Añadido Correctamente", "Ok");
                    
                    await AppShell.Current.GoToAsync(nameof(Proveedores));
                    
                    Close();
                    
                }
            }
            else
            {
                await AppShell.Current.DisplayAlert("Error", "El campo Precio y Contacto tienen que ser numeros \n Ej: 22,00 o 22", "Ok");
            }
        }
        else
        {

            await AppShell.Current.DisplayAlert("Error", "Los campos no pueden estar vacíos", "Gracias");
        }

    }

    private bool ValidarDia()
    {
        bool correcto = false;

        switch (pickerPeriocidad.SelectedItem)
        {
            case "Semanal":
                if (entryDia.Text == "L" || entryDia.Text == "M" || entryDia.Text == "X" || entryDia.Text == "J" || entryDia.Text == "V")
                {
                    correcto = true;
                }
                else
                {
                    AppShell.Current.DisplayAlert("Error", "Si la periocidad es Semanal, introduce la inicial del dia de la semana que empieza a venir el proveedor \n L = Lunes \n M = Martes \n X = Miercoles \n J = Jueves \n V = Viernes ", "Ok");
                }
                break;
            case "Quincenal":
                if (entryDia.Text == "L" || entryDia.Text == "M" || entryDia.Text == "X" || entryDia.Text == "J" || entryDia.Text == "V")
                {
                    correcto = true;
                }
                else
                {
                    AppShell.Current.DisplayAlert("Error", "Si la periocidad es Semanal, introduce la inicial del dia de la semana que empieza a venir el proveedor \n L = Lunes \n M = Martes \n X = Miercoles \n J = Jueves \n V = Viernes ", "Ok");
                }
                break;
            case "Mensual":
                if (int.TryParse(entryDia.Text, out int numeroInt2))
                {
                    int numeroDiasMesActual = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

                    if (numeroInt2 < numeroDiasMesActual && numeroInt2 > 0)
                    {
                        correcto = true;
                    }
                    else
                    {
                        AppShell.Current.DisplayAlert("Error", "Este mes tiene " + numeroDiasMesActual + " días, introduce un numero mayor a uno o menor a esos dias", "Gracias");

                    }
                }
                else
                {

                    AppShell.Current.DisplayAlert("Error", "Si la periocidad es Diaria, introduce el numero del dia del mes que empieza a venir el proveedor ", "Gracias");
                }
                break;
            default:
                AppShell.Current.DisplayAlert("Error", "Error inesperado ", "Gracias");

                break;
        }
        return correcto;
    }

}