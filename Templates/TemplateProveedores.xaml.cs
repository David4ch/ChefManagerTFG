using ChefManager.Modelo;
using ChefManager.Vistas;
using static System.Net.Mime.MediaTypeNames;

namespace ChefManager.Templates;

public partial class TemplateProveedores : ContentView
{
    FirebaseConnection connection = new FirebaseConnection();
    Proveedores proveedores = new Proveedores();
    string tipoProducto;
    string periocidad;
    bool estaEditando = false;

    public TemplateProveedores()
    {
        InitializeComponent();
    }

    private Proveedor obtenerProveedor()
    {
        List<Proveedor> listaProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").ToList();

        Proveedor proveedor = listaProveedores.FirstOrDefault(u => u.Id == entryId.Text);

        return proveedor;
    }

    private void Eliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var SetData = connection.client.Delete("ProveedorDatabase/" + obtenerProveedor().Id.ToString());
            AppShell.Current.DisplayAlert("¡!", "Proveedor eliminado correctamente", "Ok");
            proveedores.actualizarLista();
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar");
        }
    }

    private void Editar_Clicked(object sender, EventArgs e)
    {

        if (estaEditando)
        {
            editando();

            if (entryNombreEmpresa.Text.Length != 0 && entryContacto.Text.Length != 0 && entryDescripcion.Text.Length != 0 && entryPrecio.Text.Length != 0 && decimal.TryParse(entryPrecio.Text, out decimal numero2) && int.TryParse(entryContacto.Text, out int numero))
            {
                try
                {
                    Proveedor old_proveedor = obtenerProveedor();

                    Proveedor proveedor = new Proveedor()
                    {
                        Id = old_proveedor.Id,
                        Restaurante_Id = old_proveedor.Restaurante_Id,
                        NombreEmpresa = entryNombreEmpresa.Text,
                        Contacto = int.Parse(entryContacto.Text),
                        TipoProducto = tipoProducto,
                        Descripción = entryDescripcion.Text,
                        Periocidad = periocidad,
                        Precio = decimal.Parse(entryPrecio.Text)

                    };

                    var SetData = connection.client.Update("ProveedorDatabase/" + proveedor.Id, proveedor);
                    AppShell.Current.DisplayAlert("!¡", "Proveedor actualizado correctamente", "Ok");
                    proveedores.actualizarLista();
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Error");
                }
            }
            else
            {
                Proveedor old_proveedor = obtenerProveedor();

                entryNombreEmpresa.Text = old_proveedor.NombreEmpresa;
                entryContacto.Text = old_proveedor.Contacto.ToString();
                pickerTipo.SelectedItem = old_proveedor.TipoProducto;
                entryDescripcion.Text = old_proveedor.Descripción;
                pickerPeriocidad.SelectedItem = old_proveedor.Periocidad;
                entryPrecio.Text = old_proveedor.Precio.ToString();

                AppShell.Current.DisplayAlert("ERROR", "Los campos no pueden estar vacíos  \n Deben haber solo numeros en el campo Contacto y Precio", "Ok");
                editando();
            }
        }
        else
        {
            estaEditando = true;
            botonEditar.Text = "Guardar";
            botonEliminar.BackgroundColor = Colors.Gray;
            botonEditar.TextColor = Colors.Black;

            botonEliminar.IsEnabled = false;

            entryNombreEmpresa.IsEnabled = true;
            entryContacto.IsEnabled = true;
            pickerTipo.IsEnabled = true;
            entryDescripcion.IsEnabled = true;
            pickerPeriocidad.IsEnabled = true;
            entryPrecio.IsEnabled = true;


        }


    }

    private void editando()
    {
        estaEditando = false;
        botonEliminar.BackgroundColor = Colors.DarkRed;
        botonEliminar.IsEnabled = true;

        botonEditar.Text = "Editar";
        botonEditar.TextColor = Colors.Wheat;

        entryNombreEmpresa.IsEnabled = false;
        entryContacto.IsEnabled = false;
        pickerTipo.IsEnabled = false;
        entryDescripcion.IsEnabled = false;
        pickerPeriocidad.IsEnabled = false;
        entryPrecio.IsEnabled = false;

        entryNombreEmpresa.TextColor = Colors.White;
        entryContacto.TextColor = Colors.White;
        pickerTipo.TextColor = Colors.White;
        entryDescripcion.TextColor = Colors.White;
        pickerPeriocidad.TextColor = Colors.White;
        entryPrecio.TextColor = Colors.White;
    }

    private void Picker_TipoProducto(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        tipoProducto = picker.SelectedItem as string;
    }

    private void Picker_Periocidad(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        periocidad = picker.SelectedItem as string;
    }
}