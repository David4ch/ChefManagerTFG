using ChefManager.Modelo;
using FireSharp.Response;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ChefManager.Vistas;

public partial class VistaAdmin : ContentPage
{
    public ObservableCollection<Usuario> listaAuxUsuario { get; set; } = new ObservableCollection<Usuario>();
    FirebaseConnection firebaseConnection = new FirebaseConnection();
    bool menuAbierto = true;
    public VistaAdmin()
    {
        InitializeComponent();
        listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");

    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {

        Picker picker = (Picker)sender;
        string seleccionado = picker.SelectedItem as string;
        switch (seleccionado)
        {
            case "5":
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase").Take(5);

                break;
            case "10":
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase").Take(10);

                break;
            case "15":
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase").Take(15);
                break;
            default:
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");
                break;
        }
    }

    private void buscar(object sender, EventArgs e)
    {
        switch (labeltitulo.Text)
        {
            case "USUARIOS":
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase").Where(u => u.NombreUser.Contains(buscador.Text));
               
                break;
            case "RESTAURANTES":
                listaRestaurantes.ItemsSource = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase").Where(u => u.Nombre.Contains(buscador.Text));

                break;

        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");
        listaRestaurantes.ItemsSource = firebaseConnection.obtenerInfo<Restaurante>("RestauranteDatabase");
    }

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
                label2.Text = "Acciones";
                
                
                label3.IsVisible = false;
                label4.IsVisible = false;
                label5.IsVisible = false;

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

                            string logo = await Application.Current.MainPage.DisplayPromptAsync("Registro", "Url Logo:", placeholder: "url logo");

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