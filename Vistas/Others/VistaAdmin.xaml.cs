using ChefManager.Modelo;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;
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

    FirebaseConnection firebaseConnection;
    bool menuAbierto = true;

    public VistaAdmin()
    {
        firebaseConnection = new FirebaseConnection();
        InitializeComponent();
        listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");

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

                ActualizarListas("UsuarioDatabase");

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
                ActualizarListas("RestauranteDatabase");
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
                ActualizarListas("DineroDatabase");
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
                ActualizarListas("EmpleadoDatabase");
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
                ActualizarListas("NotaDatabase");
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
                ActualizarListas("ProveedorDatabase");
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
                ActualizarListas("ProductoDatabase");
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
                        Contrasena = Encriptacion.Encriptar(contrasena)
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

    private async void ImageEdit_Clicked(object sender, EventArgs e)
    {
        switch (labeltitulo.Text)
        {
            case "USUARIOS":
            case "PRODUCTOS":
            case "RESTAURANTES":
            case "PROVEEDORES":
            case "NOTAS":
            case "EMPLEADOS":
                Label labelId = ((ImageButton)sender).Parent.FindByName<Label>("labelId");
                EditarElemento.idElemento = labelId.Text;
                EditarElemento.nombreElemento = labeltitulo.Text;

                var popup = new EditarElemento();
                this.ShowPopup(popup);
                break;
            default:
                await AppShell.Current.DisplayAlert("¡!", "No está habilitado esta opción", "Ok");
                break;
        }

    }

    private async void ImageDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (labeltitulo.Text)
            {
                case "USUARIOS":
                    var button0 = (ImageButton)sender;
                    var usuario = (Usuario)button0.Parent.Parent.BindingContext;


                    var SetData0 = firebaseConnection.client.Delete("EmpleadoDatabase/" + usuario.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Elemento eliminado correctamente", "Ok");
                    ActualizarListas("EmpleadoDatabase");
                    break;
                case "PRODUCTOS":
                    var button1 = (ImageButton)sender;
                    var producto = (Producto)button1.Parent.Parent.BindingContext;


                    var SetData1 = firebaseConnection.client.Delete("ProductoDatabase/" + producto.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Elemento eliminado correctamente", "Ok");
                    ActualizarListas("ProductoDatabase");
                    break;
                case "RESTAURANTES":
                    var button2 = (ImageButton)sender;
                    var restaurante = (Restaurante)button2.Parent.Parent.BindingContext;


                    var SetData2 = firebaseConnection.client.Delete("RestauranteDatabase/" + restaurante.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Elemento eliminado correctamente", "Ok");
                    ActualizarListas("RestauranteDatabase");
                    break;
                case "PROVEEDORES":
                    var button3 = (ImageButton)sender;
                    var proveedor = (Proveedor)button3.Parent.Parent.BindingContext;


                    var SetData3 = firebaseConnection.client.Delete("ProveedorDatabase/" + proveedor.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Elemento eliminado correctamente", "Ok");
                    ActualizarListas("ProveedorDatabase");
                    break;
                case "NOTAS":
                    var button4 = (ImageButton)sender;
                    var nota = (Nota)button4.Parent.Parent.BindingContext;


                    var SetData4 = firebaseConnection.client.Delete("NotaDatabase/" + nota.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Elemento eliminado correctamente", "Ok");
                    ActualizarListas("NotaDatabase");
                    break;
                case "EMPLEADOS":
                    var button = (ImageButton)sender;
                    var empleado = (Empleado)button.Parent.Parent.BindingContext;


                    var SetData = firebaseConnection.client.Delete("EmpleadoDatabase/" + empleado.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Empleado despedido correctamente", "Ok");
                    ActualizarListas("EmpleadoDatabase");
                    break;
                case "DINERO":
                    var button6 = (ImageButton)sender;
                    var dinero = (Dinero)button6.Parent.Parent.BindingContext;


                    var SetData6 = firebaseConnection.client.Delete("DineroDatabase/" + dinero.Id);
                    await AppShell.Current.DisplayAlert("¡!", "Elemento eliminado correctamente", "Ok");
                    ActualizarListas("DineroDatabase");
                    break;
                default:

                    System.Diagnostics.Debug.WriteLine("Error");
                    break;
            }
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar");
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

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaLogin));
    }
}