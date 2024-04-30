using ChefManager.Modelo;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ChefManager.Vistas;

public partial class VistaAdmin : ContentPage
{
    FirebaseConnection firebaseConnection = new FirebaseConnection();
    bool menuAbierto = false;
    public VistaAdmin()
    {
        InitializeComponent();
        listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    private void buscar(object sender, EventArgs e)
    {
        switch (labeltitulo.Text)
        {
            case "USUARIOS":

                ObservableCollection<Usuario> auxLista = new ObservableCollection<Usuario>();

                try
                {
                    FirebaseResponse al = firebaseConnection.client.Get("UsuarioDatabase");
                    Dictionary<string, Usuario> ListData = JsonConvert.DeserializeObject<Dictionary<string, Usuario>>(al.Body.ToString());
                    auxLista = new ObservableCollection<Usuario>(ListData.Values.Where(u => u.NombreUser.Contains(buscador.Text)));
                    listaUsuarios.ItemsSource = auxLista;
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Error obtener");
                }
                break;
            case "RESTAURANTES":

                ObservableCollection<Restaurante> auxLista2 = new ObservableCollection<Restaurante>();

                try
                {
                    FirebaseResponse al2 = firebaseConnection.client.Get("RestauranteDatabase");
                    Dictionary<string, Restaurante> ListData2 = JsonConvert.DeserializeObject<Dictionary<string, Restaurante>>(al2.Body.ToString());
                    auxLista2 = new ObservableCollection<Restaurante>(ListData2.Values.Where(u => u.Nombre.Contains(buscador.Text)));
                    listaRestaurantes.ItemsSource = auxLista2;
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Error obtener");
                }
                break;

        }
    }

    public void actualizarLista(string nombreDb)
    {

        switch (nombreDb)
        {
            case "Usuarios":
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");
                break;
            case "Restaurantes":
                listaRestaurantes.ItemsSource = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase");
                break;
            default:
                break;

        }


    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Color.FromRgb(255, 134, 247);


    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.SandyBrown;
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

                label0.Text = "NombreUser";
                label1.Text = "Email";
                label2.Text = "Contraseña";
                label3.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = true;

                listaRestaurantes.IsVisible = false;

                listaUsuarios.IsVisible = true;
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");

                break;
            case "File: restaurantes_icon.png":
                labeltitulo.Text = "RESTAURANTES";
                labelAdd.Text = "Añadir restaurante";
                buscador.Placeholder = "Buscar por Nombre";

                label0.Text = "Nombre";
                label1.Text = "Dirección";
                label2.Text = "Logo";
                label3.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = false;

                listaUsuarios.IsVisible = false;

                listaRestaurantes.IsVisible = true;
                listaRestaurantes.ItemsSource = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase");
                break;
            case "Calendario":

                break;
            case "Dinero":

                break;
            case "Calendario_has_Dinero":

                break;
            case "Empleados":

                break;
            case "Notas":

                break;
            case "Proveedores":

                break;
            case "Productos":

                break;
            case "Proveedores_has_Productos":

                break;
            default:
                System.Diagnostics.Debug.WriteLine("Error terrible");
                break;
        }
    }

    private void mostrarMenu(object sender, EventArgs e)
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

    private async void ImageAdd_Clicked(object sender, EventArgs e)
    {
        switch (labelAdd.Text)
        {
            case "Añadir usuario":
                try
                {

                    string nombre = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Nombre Usuario:");
                    if (nombre == null)
                    {
                        nombre = "";

                    }
                    if (!nombre.Equals(""))
                    {
                        string idRestaurante = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Id Restaurante:");
                        if (idRestaurante == null)
                        {
                            idRestaurante = "";

                        }
                        if (!idRestaurante.Equals(""))
                        {
                            string email = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Email:");
                            if (email == null)
                            {
                                email = "";

                            }
                            if (!email.Equals(""))
                            {

                                string contrasena = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Contraseña:");
                                if (contrasena == null)
                                {
                                    contrasena = "";

                                }
                                if (!contrasena.Equals(""))
                                {
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
                                    actualizarLista("Usuarios");
                                }
                                else
                                {
                                    await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                                }

                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Error 874", "El campo no puede estar vacio", "Ok ");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                    }

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
                    if (nombre == null)
                    {
                        nombre = "";

                    }
                    if (!nombre.Equals(""))
                    {
                        string direccion = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Dirección:");
                        if (direccion == null)
                        {
                            direccion = "";

                        }
                        if (!direccion.Equals(""))
                        {

                            string logo = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Contraseña:", placeholder: "url logo");

                            if (logo == null)
                            {
                                logo = "";

                            }
                            if (!logo.Equals(""))
                            {
                                await Application.Current.MainPage.DisplayAlert("¡!", "Registro Completado Correctamente", "Gracias");

                                Restaurante restaurante = new Restaurante
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Nombre = nombre,
                                    Direccion = direccion,
                                    Logo = logo
                                };
                                var SetData = firebaseConnection.client.SetAsync("RestauranteDatabase/" + restaurante.Id, restaurante);
                                actualizarLista("Restaurantes");
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                            }


                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error 233", "El campo no puede estar vacio", "Ok ");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Processing failed: {ex.Message}");
                }
                break;
            default:
                System.Diagnostics.Debug.WriteLine("Error mostrar Registro");
                break;

        }
    }
}