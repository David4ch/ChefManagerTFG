using ChefManager.Modelo;
using System.Collections.ObjectModel;

namespace ChefManager.Vistas;

public partial class VistaAdmin : ContentPage
{
    public ObservableCollection<Usuario> ListaAuxUsuarios { get; set; } = new ObservableCollection<Usuario>();
    public ObservableCollection<Restaurante> ListaAuxRestaurantes { get; set; } = new ObservableCollection<Restaurante>();
    public ObservableCollection<Producto> ListaAuxProductos { get; set; } = new ObservableCollection<Producto>();
    public ObservableCollection<Proveedor> ListaAuxProveedores { get; set; } = new ObservableCollection<Proveedor>();
    public ObservableCollection<Nota> ListaAuxNotas { get; set; } = new ObservableCollection<Nota>();
    public ObservableCollection<Empleado> ListaAuxEmpleados { get; set; } = new ObservableCollection<Empleado>();
    public ObservableCollection<Dinero> ListaAuxDinero { get; set; } = new ObservableCollection<Dinero>();

    FirebaseConnection firebaseConnection = new();
    bool menuAbierto = true;

    public VistaAdmin()
    {
        InitializeComponent();
        CargarListas();
        ActualizarListas("UsuarioDatabase");

    }
    private void CargarListas() {
        ListaAuxUsuarios = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");
        ListaAuxRestaurantes = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase");
        ListaAuxProductos = firebaseConnection.obtenerInfo<Producto>("ProductoDatabase");
        ListaAuxProveedores = firebaseConnection.obtenerInfo<Proveedor>("ProveedorDatabase");
        ListaAuxNotas = firebaseConnection.obtenerInfo<Nota>("NotaDatabase");
        ListaAuxEmpleados = firebaseConnection.obtenerInfo<Empleado>("EmpleadoDatabase");
        ListaAuxDinero = firebaseConnection.obtenerInfo<Dinero>("DineroDatabase");
    }

    private void ActualizarListas(string database)
    {

        switch (database)
        {
            case "UsuarioDatabase":
                ListaAuxUsuarios = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");
                listaUsuarios.ItemsSource = ListaAuxUsuarios;
                break;
            case "RestauranteDatabase":
                ListaAuxRestaurantes = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase");
                listaRestaurantes.ItemsSource = ListaAuxRestaurantes;
                break;
            case "ProductoDatabase":
                ListaAuxProductos = firebaseConnection.obtenerInfo<Producto>("ProductoDatabase");
                listaProductos.ItemsSource = ListaAuxProductos;
                break;
            case "ProveedorDatabase":
                ListaAuxProveedores = firebaseConnection.obtenerInfo<Proveedor>("ProveedorDatabase");
                listaProveedores.ItemsSource = ListaAuxProveedores;
                break;
            case "NotaDatabase":
                ListaAuxNotas = firebaseConnection.obtenerInfo<Nota>("NotaDatabase");
                listaNotas.ItemsSource = ListaAuxNotas;
                break;
            case "EmpleadoDatabase":
                ListaAuxEmpleados = firebaseConnection.obtenerInfo<Empleado>("EmpleadoDatabase");
                listaEmpleados.ItemsSource = ListaAuxEmpleados;
                break;
            case "DineroDatabase":
                ListaAuxDinero = firebaseConnection.obtenerInfo<Dinero>("DineroDatabase");
                listaDinero.ItemsSource = ListaAuxDinero;
                break;

        }



    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {

        Picker picker = (Picker)sender;
        string seleccionado = picker.SelectedItem as string;


        switch (labeltitulo.Text)
        {
            case "USUARIOS":
            case "PRODUCTOS":
            case "RESTAURANTES":
            case "PROVEEDORES":
            case "NOTAS":
            case "EMPLEADOS":
            case "DINERO":
                switch (seleccionado)
                {
                    case "5":
                    case "10":
                    case "15":
                        listaUsuarios.ItemsSource = ListaAuxUsuarios.Take(int.Parse(seleccionado));
                        listaRestaurantes.ItemsSource = ListaAuxRestaurantes.Take(int.Parse(seleccionado));
                        listaProductos.ItemsSource = ListaAuxProductos.Take(int.Parse(seleccionado));
                        listaProveedores.ItemsSource = ListaAuxProductos.Take(int.Parse(seleccionado));
                        listaNotas.ItemsSource = ListaAuxNotas.Take(int.Parse(seleccionado));
                        listaEmpleados.ItemsSource = ListaAuxEmpleados.Take(int.Parse(seleccionado));
                        listaDinero.ItemsSource = ListaAuxDinero.Take(int.Parse(seleccionado));
                        break;
                    default:
                        listaUsuarios.ItemsSource = ListaAuxUsuarios;
                        listaRestaurantes.ItemsSource = ListaAuxRestaurantes;
                        listaProductos.ItemsSource = ListaAuxProductos;
                        listaProveedores.ItemsSource = ListaAuxProveedores;
                        listaNotas.ItemsSource = ListaAuxNotas;
                        listaEmpleados.ItemsSource = ListaAuxEmpleados;
                        listaDinero.ItemsSource = ListaAuxDinero;
                        break;
                }
                break;
        }

    }

    private void Buscar(object sender, EventArgs e)
    {
        switch (labeltitulo.Text)
        {
            case "USUARIOS":
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase").Where(u => u.NombreUser.Contains(buscador.Text));

                break;
            case "RESTAURANTES":
                listaRestaurantes.ItemsSource = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase").Where(u => u.Nombre.Contains(buscador.Text));

                break;
            case "PRODUCTOS":
                listaProductos.ItemsSource = firebaseConnection.obtenerInfo<Producto>("ProductoDatabase").Where(u => u.Nombre.Contains(buscador.Text));

                break;
            case "PROVEEDORES":
                listaProveedores.ItemsSource = firebaseConnection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.NombreEmpresa.Contains(buscador.Text));

                break;
            case "NOTAS":
                listaNotas.ItemsSource = firebaseConnection.obtenerInfo<Nota>("NotaDatabase").Where(u => u.Titulo.Contains(buscador.Text));

                break;
            case "EMPLEADOS":
                listaEmpleados.ItemsSource = firebaseConnection.obtenerInfo<Empleado>("EmpleadoDatabase").Where(u => u.Nombre.Contains(buscador.Text));

                break;
            case "DINERO":
                listaDinero.ItemsSource = firebaseConnection.obtenerInfo<Dinero>("DineroDatabase").Where(u => u.Restaurante_Id.Contains(buscador.Text));

                break;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        switch (button.Source.ToString())
        {
            case "File: usuarios_icon.png":
                labeltitulo.Text = "USUARIOS";
                labelAdd.Text = "Añadir usuario";
                buscador.Placeholder = "Buscar por NombreUser";

                label0.Text = "Restaurante_ID";
                label1.Text = "NombreUser";
                label2.Text = "Email";
                label3.Text = "Acciones";


                label3.IsVisible = true;
                label4.IsVisible = false;
                label5.IsVisible = false;
                label6.IsVisible = false;
                label7.IsVisible = false;

                listaRestaurantes.IsVisible = false;
                listaProveedores.IsVisible = false;
                listaProductos.IsVisible = false;
                listaNotas.IsVisible = false;
                listaEmpleados.IsVisible = false;
                listaDinero.IsVisible = false;

                imgAdd.IsVisible = true;
                labelAdd.IsVisible = true;

                listaUsuarios.IsVisible = true;
                listaUsuarios.ItemsSource = ListaAuxUsuarios;

                break;
            case "File: restaurantes_icon.png":
                labeltitulo.Text = "RESTAURANTES";
                labelAdd.Text = "Añadir restaurante";
                buscador.Placeholder = "Buscar por Nombre";

                label0.Text = "Restaurante_ID";
                label1.Text = "Nombre";
                label2.Text = "Dirección";
                label3.Text = "Logo";
                label4.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = false;
                label6.IsVisible = false;
                label7.IsVisible = false;

                listaUsuarios.IsVisible = false;
                listaProductos.IsVisible = false;
                listaProveedores.IsVisible = false;
                listaNotas.IsVisible = false;
                listaEmpleados.IsVisible = false;
                listaDinero.IsVisible = false;

                imgAdd.IsVisible = true;
                labelAdd.IsVisible = true;

                listaRestaurantes.IsVisible = true;
                listaRestaurantes.ItemsSource = ListaAuxRestaurantes;
                break;
            case "File: dinero.png":
                labeltitulo.Text = "DINERO";
                buscador.Placeholder = "Buscar por Restaurante_ID";

                label0.Text = "Restaurante_ID";
                label1.Text = "Turno";
                label2.Text = "Cantidad";
                label3.Text = "Fecha";
                label4.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = false;
                label6.IsVisible = false;
                label7.IsVisible = false;

                listaUsuarios.IsVisible = false;
                listaRestaurantes.IsVisible = false;
                listaProductos.IsVisible = false;
                listaProveedores.IsVisible = false;
                listaNotas.IsVisible = false;
                listaEmpleados.IsVisible = false;

                imgAdd.IsVisible = false;
                labelAdd.IsVisible = false;

                listaDinero.IsVisible = true;
                listaDinero.ItemsSource = ListaAuxDinero;
                break;
            case "File: empleados_icon.png":
                labeltitulo.Text = "EMPLEADOS";
                buscador.Placeholder = "Buscar por Nombre";

                label0.Text = "Restaurante_ID";
                label1.Text = "Nombre";
                label2.Text = "Puesto";
                label3.Text = "Nómina";
                label4.Text = "Contacto";
                label5.Text = "Disponibilidad";
                label6.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = true;
                label7.IsVisible = true;

                listaUsuarios.IsVisible = false;
                listaRestaurantes.IsVisible = false;
                listaProductos.IsVisible = false;
                listaProveedores.IsVisible = false;
                listaNotas.IsVisible = false;
                listaDinero.IsVisible = false;

                imgAdd.IsVisible = false;
                labelAdd.IsVisible = false;

                listaEmpleados.IsVisible = true;
                listaEmpleados.ItemsSource = ListaAuxEmpleados;
                break;
            case "File: notas.png":
                labeltitulo.Text = "NOTAS";
                buscador.Placeholder = "Buscar por Titulo";

                label0.Text = "Restaurante_ID";
                label1.Text = "Titulo";
                label2.Text = "Mensaje";
                label3.Text = "Date";
                label4.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = false;
                label6.IsVisible = false;
                label7.IsVisible = false;

                listaUsuarios.IsVisible = false;
                listaRestaurantes.IsVisible = false;
                listaProductos.IsVisible = false;
                listaProveedores.IsVisible = false;
                listaDinero.IsVisible = false;
                listaEmpleados.IsVisible = false;

                imgAdd.IsVisible = false;
                labelAdd.IsVisible = false;

                listaNotas.IsVisible = true;
                listaNotas.ItemsSource = ListaAuxNotas;
                break;
            case "File: proveedores.png":
                labeltitulo.Text = "PROVEEDORES";
                buscador.Placeholder = "Buscar por NombreEmpresa";

                label0.Text = "Restaurante_ID";
                label1.Text = "Nombre Empresa";
                label2.Text = "Tipo Producto";
                label3.Text = "Descripción";
                label4.Text = "Precio";
                label5.Text = "Periocidad";
                label6.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = true;
                label7.IsVisible = true;

                listaUsuarios.IsVisible = false;
                listaRestaurantes.IsVisible = false;
                listaDinero.IsVisible = false;
                listaProductos.IsVisible = false;
                listaEmpleados.IsVisible = false;
                listaNotas.IsVisible = false;

                imgAdd.IsVisible = false;
                labelAdd.IsVisible = false;

                listaProveedores.IsVisible = true;
                listaProveedores.ItemsSource = ListaAuxProveedores;
                break;
            case "File: productos_icon.png":
                labeltitulo.Text = "PRODUCTOS";
                buscador.Placeholder = "Buscar por Nombre";

                label0.Text = "Restaurante_ID";
                label1.Text = "Nombre";
                label2.Text = "Precio";
                label3.Text = "Cantidad";
                label4.Text = "Proveedor";
                label5.Text = "Imagen";
                label6.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = true;
                label7.IsVisible = true;

                listaUsuarios.IsVisible = false;
                listaRestaurantes.IsVisible = false;
                listaProveedores.IsVisible = false;
                listaEmpleados.IsVisible = false;
                listaDinero.IsVisible = false;
                listaNotas.IsVisible = false;

                imgAdd.IsVisible = false;
                labelAdd.IsVisible = false;

                listaProductos.IsVisible = true;
                listaProductos.ItemsSource = ListaAuxProductos;


                break;
            default:
                System.Diagnostics.Debug.WriteLine("Error");
                break;
        }
    }

    private void MostrarMenu(object sender, EventArgs e)
    {
        if (!menuAbierto)
        {
            verticalLayout.TranslateTo(0, 0);
            verticalLayout.IsVisible = true;

            verticalLayout2.WidthRequest = 1071;

            menuAbierto = true;
        }
        else
        {
            verticalLayout.TranslateTo(-519, 0);
            verticalLayout.IsVisible = false;

            verticalLayout2.WidthRequest = 1550;

            menuAbierto = false;
        }
    }

    private async void ImageAdd_Clicked(object sender, EventArgs e)
    {
        switch (labelAdd.Text)
        {
            case "Añadir usuario":

                try
                {
                    string nombre = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Nombre Usuario:");
                    if (string.IsNullOrEmpty(nombre))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        return;
                    }

                    string idRestaurante = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Id Restaurante:");
                    if (string.IsNullOrEmpty(idRestaurante))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        return;
                    }

                    string email = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Email:");
                    if (string.IsNullOrEmpty(email))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 874", "El campo no puede estar vacio", "Ok ");
                        return;
                    }

                    string contrasena = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Contraseña:");
                    if (string.IsNullOrEmpty(contrasena))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        return;
                    }

                    await Application.Current.MainPage.DisplayAlert("¡!", "Registro Completado Correctamente", "Gracias");

                    Usuario usuario = new Usuario
                    {
                        Id = Guid.NewGuid().ToString(),
                        Restaurante_Id = idRestaurante,
                        NombreUser = nombre,
                        Email = email,
                        Contrasena = contrasena
                    };
                    var SetData = firebaseConnection.client.SetAsync("UsuarioDatabase/" + usuario.Id, usuario);
                    ActualizarListas("UsuarioDatabase");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Processing failed: {ex.Message}");
                }

                break;
            case "Añadir restaurante":
                try
                {
                    string nombre = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Nombre Restaurante:");
                    if (string.IsNullOrEmpty(nombre))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        return;
                    }

                    string direccion = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Dirección:");
                    if (string.IsNullOrEmpty(direccion))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        return;
                    }

                    string logo = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Logo:");
                    if (string.IsNullOrEmpty(logo))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 874", "El campo no puede estar vacio", "Ok ");
                        return;
                    }


                    await Application.Current.MainPage.DisplayAlert("¡!", "Registro Completado Correctamente", "Gracias");

                    Restaurante restaurante = new Restaurante
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nombre = nombre,
                        Direccion = direccion,
                        Logo = logo
                    };
                    var SetData = firebaseConnection.client.SetAsync("RestauranteDatabase/" + restaurante.Id, restaurante);
                    ActualizarListas("RestauranteDatabase");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Processing failed: {ex.Message}");
                }

                break;
        }
    }

    private void ImageEdit_Clicked(object sender, EventArgs e)
    {

    }

    private async void ImageDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            // var SetData = firebaseConnection.client.Delete("RestauranteDatabase/" + labelId.Text);
            await Application.Current.MainPage.DisplayAlert("!¡", "Elemento eliminado correctamente", "De acuerdo");
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar el restaurante");
        }
    }

    //CAMBIAR COLOR DE LOS BOTONES DE EMPLEADOS USUARIOS RESTAURANTES ETC
    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Color.FromRgb(255, 134, 247);


    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = default;
    }

    //CAMBIAR COLOR DEL BOTON DE AGREGAR ELEMENT0 (EJ. Agregar empleado)
    private void OnPointerEntered2(object sender, PointerEventArgs e)
    {

        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.Yellow;
        button.RotateYTo(360, 500);


    }

    private void OnPointerExited2(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.White;

    }

    //CAMBIAR EL COLOR A LOS BOTONES DE EDITAR Y ELIMINAR
    private void OnPointerEntered3(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;

        switch (button.Source.ToString())
        {
            case "File: editar.png":
                button.BackgroundColor = Colors.LightBlue;
                button.RotateYTo(360, 500);
                break;
            case "File: eliminar.png":
                button.BackgroundColor = Colors.Red;
                button.RotateYTo(360, 500);
                break;

            default:
                break;
        }

    }

    private void OnPointerExited3(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.LightGray;

    }
}