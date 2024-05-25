using ChefManager.Modelo;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;

namespace ChefManager.Vistas;

public partial class Empleados : ContentPage
{
   public static string _sourceNomina;
   public static string _idEmpleado;
   List<Empleado> listaAuxEmpleados;
   FirebaseConnection connection;

    public Empleados()
	{
		InitializeComponent();
        connection = new FirebaseConnection();
        listaAuxEmpleados = connection.obtenerInfo<Empleado>("EmpleadoDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaAuxEmpleados.Count != 0)
        {
            nohay.IsVisible = false;
            listaEmpleados.IsVisible = true;

            ActualizarLista();
        }
    }

    private void ActualizarLista() { 
        
        listaAuxEmpleados =  connection.obtenerInfo<Empleado>("EmpleadoDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        listaEmpleados.ItemsSource = listaAuxEmpleados;

        labelNum.Text = "Número empleados: " + listaAuxEmpleados.Count().ToString();
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
    
    private void VerNomina(object sender, EventArgs e)
    {

        var button = (ImageButton)sender;
        var empleado = (Empleado)button.Parent.Parent.BindingContext;

        _sourceNomina = empleado.ImagenNomina;

            var popup = new VerNomina();
            this.ShowPopup(popup);
        
    }

    private void EditarEmpleado(object sender, EventArgs e)
    {

        var button = (ImageButton)sender;
        var empleado = (Empleado)button.Parent.Parent.BindingContext;

        _idEmpleado = empleado.Id;

        var popup = new EditarEmpleado();
        this.ShowPopup(popup);
        
    }

    private void EliminarEmpleado(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var empleado = (Empleado)button.Parent.Parent.BindingContext;

        try
        {
            var SetData = connection.client.Delete("EmpleadoDatabase/" + empleado.Id);
            AppShell.Current.DisplayAlert("¡!", "Empleado despedido correctamente", "Ok");
            ActualizarLista();
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar");
        }
    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.Red;
    }
   
    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.Transparent;
    }
}