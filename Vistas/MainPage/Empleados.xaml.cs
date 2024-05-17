using ChefManager.Modelo;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;

namespace ChefManager.Vistas;

public partial class Empleados : ContentPage
{
    List<Empleado> listaAuxEmpleados;
    FirebaseConnection connection = new FirebaseConnection();

    public Empleados()
	{
		InitializeComponent();
        listaAuxEmpleados = connection.obtenerInfo<Empleado>("EmpleadoDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaAuxEmpleados.Count != 0)
        {
            nohay.IsVisible = false;
            listaEmpleados.IsVisible = true;
            listaEmpleados.ItemsSource = listaAuxEmpleados;
        }
    }

    private void Buscador_TextChanged(object sender, TextChangedEventArgs e)
    {
        listaEmpleados.ItemsSource = listaAuxEmpleados.Where(u=> u.Nombre.Contains(buscador.Text));
    }

    private void Agregar_Empleado(object sender, EventArgs e)
    {
        var popup = new AgregarEmpleado();
        this.ShowPopup(popup);
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        string seleccionado = picker.SelectedItem as string;
        switch (seleccionado)
        {
            case "Disponibilidad(Si)":

                listaEmpleados.ItemsSource = listaAuxEmpleados.Where(u =>u.Disponibilidad );
                break;
            case "Disponibilidad(No)":
                listaEmpleados.ItemsSource = listaAuxEmpleados.Where(u => !u.Disponibilidad);

                break;
            case "Orden alfabético":
                listaEmpleados.ItemsSource = listaAuxEmpleados.OrderBy(u => u.Nombre);
                break;
            default:
                listaEmpleados.ItemsSource = listaAuxEmpleados;
                break;
        }
    }

    private async void Volver(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaPrinc));
    }
}