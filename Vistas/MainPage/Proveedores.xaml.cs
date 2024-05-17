using ChefManager.Modelo;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;

namespace ChefManager.Vistas;

public partial class Proveedores : ContentPage
{
    List<Proveedor> listaAuxProveedores;
    FirebaseConnection connection = new FirebaseConnection();

    public Proveedores()
    {
        InitializeComponent();
    }
    public void actualizarLista() {
        listaProveedores.ItemsSource = listaAuxProveedores;
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        string seleccionado = picker.SelectedItem as string;
        switch (seleccionado)
        {
            case "Productos frescos":

                listaProveedores.ItemsSource = listaAuxProveedores.Where(u => u.TipoProducto.Equals("Productos frescos"));
                break;
            case "Productos secos":
                listaProveedores.ItemsSource = listaAuxProveedores.Where(u => u.TipoProducto.Equals("Productos secos"));

                break;
            case "Bebidas":
                listaProveedores.ItemsSource = listaAuxProveedores.Where(u => u.TipoProducto.Equals("Bebidas"));
                break;
            case "Productos de limpieza e higiene":
                listaProveedores.ItemsSource = listaAuxProveedores.Where(u => u.TipoProducto.Equals("Productos de limpieza e higiene"));
                break;
            case "Utensilios y equipamiento":
                listaProveedores.ItemsSource = listaAuxProveedores.Where(u => u.TipoProducto.Equals("Utensilios y equipamiento"));
                break;
            default:
                listaProveedores.ItemsSource = listaAuxProveedores;
                break;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();


        listaAuxProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaAuxProveedores.Count != 0)
        {
            nohay.IsVisible = false;
            listaProveedores.IsVisible = true;
            listaProveedores.ItemsSource = listaAuxProveedores;
        }
    }

    private void buscar(object sender, EventArgs e)
    {
        listaProveedores.ItemsSource = listaAuxProveedores.Where(u => u.NombreEmpresa.Contains(buscador.Text));

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new AgregarProveedor();
        this.ShowPopup(popup);
    }

    private async void Volver(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaPrinc));
    }
}