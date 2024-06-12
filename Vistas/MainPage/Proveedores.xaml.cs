using ChefManager.Modelo;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;

namespace ChefManager.Vistas;

public partial class Proveedores : ContentPage
{
    bool estaEditando = false;
    List<Proveedor> listaAuxProveedores;
    FirebaseConnection connection = new FirebaseConnection();
    string _idProveedor = "";
    Entry entryNombreEmpresa;
    Entry entryContacto;
    Editor entryDescripcion;
    Entry entryPrecio;
    Entry entryPeriocidad;
    Entry entryId;
    Picker pickerTipo;
    ImageButton botonEditar;
    ImageButton botonEliminar;

    public Proveedores()
    {
        InitializeComponent();

        listaAuxProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();
       
        ActualizarLista();

    }

    private void ActualizarLista()
    {
        listaAuxProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();
        if (listaAuxProveedores.Count != 0)
        {
            nohay.IsVisible = false;
            listaProveedores.IsVisible = true;
            listaProveedores.ItemsSource = listaAuxProveedores;
        }
        else
        {
            nohay.IsVisible = true;
            listaProveedores.IsVisible = false;
        }


    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        string seleccionado = picker.SelectedItem as string;
        listaProveedores.ItemsSource = seleccionado switch
        {
            "Productos frescos" => listaAuxProveedores.Where(u => u.TipoProducto.Equals("Productos frescos")),
            "Productos secos" => listaAuxProveedores.Where(u => u.TipoProducto.Equals("Productos secos")),
            "Bebidas" => listaAuxProveedores.Where(u => u.TipoProducto.Equals("Bebidas")),
            "Productos de limpieza e higiene" => listaAuxProveedores.Where(u => u.TipoProducto.Equals("Productos de limpieza e higiene")),
            "Utensilios y equipamiento" => listaAuxProveedores.Where(u => u.TipoProducto.Equals("Utensilios y equipamiento")),
            _ => listaAuxProveedores,
        };
    }

    private void Buscar(object sender, EventArgs e)
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

    private void Eliminar_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var proveedor = (Proveedor)button.Parent.Parent.BindingContext;
        _idProveedor = proveedor.Id;

        try
        {
            var SetData = connection.client.Delete("ProveedorDatabase/" + _idProveedor);
            AppShell.Current.DisplayAlert("¡!", "Proveedor eliminado correctamente", "Ok");
            ActualizarLista();
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar");
        }
    }

    private void Editar_Clicked(object sender, EventArgs e)
    {
        entryNombreEmpresa = ((ImageButton)sender).Parent.FindByName<Entry>("entryNombreEmpresa");
        entryContacto = ((ImageButton)sender).Parent.FindByName<Entry>("entryContacto");
        entryDescripcion = ((ImageButton)sender).Parent.FindByName<Editor>("entryDescripcion");
        entryPrecio = ((ImageButton)sender).Parent.FindByName<Entry>("entryPrecio");
        entryId = ((ImageButton)sender).Parent.FindByName<Entry>("entryId");
        entryPeriocidad = ((ImageButton)sender).Parent.FindByName<Entry>("entryPeriocidad");
        pickerTipo = ((ImageButton)sender).Parent.FindByName<Picker>("pickerTipo");
        botonEditar = ((ImageButton)sender).Parent.FindByName<ImageButton>("botonEditar");
        botonEliminar = ((ImageButton)sender).Parent.FindByName<ImageButton>("botonEliminar");

        _idProveedor = entryId.Text;

        if (estaEditando)
        {
            if (entryNombreEmpresa.Text.Length != 0 && entryContacto.Text.Length != 0 && entryDescripcion.Text.Length != 0 && entryPeriocidad.Text.Length != 0 && entryPrecio.Text.Length != 0 && decimal.TryParse(entryPrecio.Text, out decimal numero2) && int.TryParse(entryContacto.Text, out int numero))
            {
                if (ValidarPeriocidad())
                {
                    try
                    {

                        Proveedor old_proveedor = listaAuxProveedores.FirstOrDefault(u => u.Id == entryId.Text);

                        Proveedor proveedor = new()
                        {
                            Id = old_proveedor.Id,
                            Restaurante_Id = old_proveedor.Restaurante_Id,
                            NombreEmpresa = entryNombreEmpresa.Text,
                            Contacto = numero,
                            TipoProducto = pickerTipo.SelectedItem.ToString(),
                            Descripción = entryDescripcion.Text,
                            Periocidad = entryPeriocidad.Text,
                            Precio = numero2

                        };

                        var SetData = connection.client.Update("ProveedorDatabase/" + proveedor.Id, proveedor);
                        AppShell.Current.DisplayAlert("!¡", "Proveedor actualizado correctamente", "Ok");
                        ReestablecerEntrys();
                        ActualizarLista();
                    }
                    catch (Exception)
                    {
                        System.Diagnostics.Debug.WriteLine("Error");
                    }
                }
                else
                {
                    AppShell.Current.DisplayAlert("Error", "Si la periocidad es Semanal o Quincenal, introduce la inicial del dia de la semana que empieza a venir el proveedor \n L = Lunes \n M = Martes \n X = Miercoles \n J = Jueves \n V = Viernes \n Si es Mensual, introduce un numero del actual mes", "Ok");
                    ReestablecerEntrys();
                }
            }
            else
            {
               
                AppShell.Current.DisplayAlert("ERROR", " Los campos no pueden estar vacíos  \n Deben haber solo numeros en el campo Contacto y Precio \n El formato del campo Periocidad es Semanal-M o Mensual-9", "Ok");
                ReestablecerEntrys();
            }
        }
        else
        {
            estaEditando = true;
            botonEliminar.BackgroundColor = Colors.Gray;
            botonEditar.Source = "save.png";

            botonEliminar.IsEnabled = false;

            entryNombreEmpresa.IsEnabled = true;
            entryContacto.IsEnabled = true;
            pickerTipo.IsEnabled = true;
            entryDescripcion.IsEnabled = true;
            entryPeriocidad.IsEnabled = true;
            entryPrecio.IsEnabled = true;


        }
    }

    private void ReestablecerEntrys()
    {
        estaEditando = false;
        botonEditar.Source = "editar.png";
        botonEliminar.BackgroundColor = Colors.DarkRed;
        botonEliminar.IsEnabled = true;

        entryNombreEmpresa.IsEnabled = false;
        entryContacto.IsEnabled = false;
        pickerTipo.IsEnabled = false;
        entryDescripcion.IsEnabled = false;
        entryPeriocidad.IsEnabled = false;
        entryPrecio.IsEnabled = false;

        entryNombreEmpresa.TextColor = Colors.White;
        entryContacto.TextColor = Colors.White;
        pickerTipo.TextColor = Colors.White;
        entryDescripcion.TextColor = Colors.White;
        entryPeriocidad.TextColor = Colors.White;
        entryPrecio.TextColor = Colors.White;

        Proveedor old_proveedor = listaAuxProveedores.FirstOrDefault(u => u.Id == _idProveedor);

        entryNombreEmpresa.Text = old_proveedor.NombreEmpresa;
        entryContacto.Text = old_proveedor.Contacto.ToString();
        pickerTipo.SelectedItem = old_proveedor.TipoProducto;
        entryDescripcion.Text = old_proveedor.Descripción;
        entryPeriocidad.Text = old_proveedor.Periocidad;
        entryPrecio.Text = old_proveedor.Precio.ToString();
    }

    private bool ValidarPeriocidad()
    {

        bool correcto = false;
        string palabra = entryPeriocidad.Text;

        if (palabra.Contains('-') && palabra.Count(c => c == '-') == 1)
        {
            string[] partes = palabra.Split('-');

            if (partes[0] == "Semanal" || partes[0] == "Quincenal" || partes[0] == "Mensual")
            {
                switch (partes[0])
                {
                    case "Semanal":
                        if (partes[1] == "L" || partes[1] == "M" || partes[1] == "X" || partes[1] == "J" || partes[1] == "V")
                        {
                            correcto = true;
                        }
                        break;
                    case "Quincenal":
                        if (partes[1] == "L" || partes[1] == "M" || partes[1] == "X" || partes[1] == "J" || partes[1] == "V")
                        {
                            correcto = true;
                        }
                        break;
                    case "Mensual":
                        if (int.TryParse(partes[1], out int numeroInt2))
                        {
                            int numeroDiasMesActual = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

                            if (numeroInt2 > numeroDiasMesActual || numeroInt2 < 0)
                            {
                                correcto = true;
                            }
                        }
                        break;
                    default:
                        break;

                }

            }
        }


        return correcto;
    }

}