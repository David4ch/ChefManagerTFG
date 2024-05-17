using ChefManager.Modelo;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Storage;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using ChefManager.Templates;
namespace ChefManager.Vistas;

public partial class Inventario : ContentPage
{
    public string TituloProducto { get; set; }
    public static string idProducto;
    FirebaseConnection connection = new FirebaseConnection();
    List<Producto> listaAuxProductos = new List<Producto>();
    List<Proveedor> listaAuxProveedores = new List<Proveedor>();
    public static string _idRestaurante;
    string authDomain = "chefmg-664a2.firebaseapp.com";
    string api_key = "AIzaSyCyrx6jgU-a2dnYYOqlMX2k_8tbO1ia1rw";
    string email = "admin@gmail.com";
    string contrasena = "123456";
    string token = string.Empty;
    string rutaStorage = "chefmg-664a2.appspot.com";
    string _urlDescarga = "";
    List<string> opciones = new List<string>();

    public Inventario()
    {
        InitializeComponent();
        BindingContext = this;
        MainThread.BeginInvokeOnMainThread(new Action(async () => await obtenerToken()));

        listaAuxProductos = connection.obtenerInfo<Producto>("ProductoDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaAuxProductos.Count != 0)
        {
            listaProductos.ItemsSource = listaAuxProductos;
        }
    }


    private async Task obtenerToken()
    {

        var client = new FirebaseAuthClient(new FirebaseAuthConfig()
        {

            ApiKey = api_key,
            AuthDomain = authDomain,
            Providers = new FirebaseAuthProvider[]
            {
                    new EmailProvider()
            }
        });

        var credenciales = await client.SignInWithEmailAndPasswordAsync(email, contrasena);
        token = await credenciales.User.GetIdTokenAsync();

    }

    public void actualizarLista()
    {
        listaProductos.ItemsSource = listaAuxProductos;
    }

    private async void subirFoto(object sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {

            var task = new FirebaseStorage(
                rutaStorage,
                new FirebaseStorageOptions
                {

                    AuthTokenAsyncFactory = () => Task.FromResult(token),
                    ThrowOnCancel = true
                }
              )
                .Child("Imagenes")
                .Child(foto.FileName)
                .PutAsync(await foto.OpenReadAsync());

            var urlDescarga = await task;
            _urlDescarga = urlDescarga;
            entryImagen.Text = foto.FileName;
            imagen.Source = urlDescarga;

        }
    }

    private void buscar(object sender, EventArgs e)
    {
        listaProductos.ItemsSource = listaAuxProductos.Where(u => u.Nombre.Contains(buscador.Text));
    }

    private void agregar(object sender, EventArgs e)
    {

        stack2.TranslateTo(0, 0);
        stack2.IsVisible = true;
        borde1.WidthRequest = 860;
        listaProductos.WidthRequest = 750;
        buscador.WidthRequest = 300;

        stack1.WidthRequest = 1000;

        listaAuxProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaAuxProveedores.Count != 0)
        {
            foreach (var item in listaAuxProveedores)
            {
                opciones.Add(item.NombreEmpresa);
            }

            opciones.Add("Otro");
            pickerProveedor.ItemsSource = opciones;
        }
        else
        {
            opciones.Add("Otro");
            pickerProveedor.ItemsSource = opciones;
        }



    }

    private async void guardarProducto(object sender, EventArgs e)
    {

        if (labelTitulo.Text == "AÑADIR")
        {
            
            if (validarProducto()) { 
            Producto producto = new Producto
            {
                Id = Guid.NewGuid().ToString(),
                Restaurante_Id = VistaPrinc._restauranteId,
                Nombre = entryNombre.Text,
                Proveedor = pickerProveedor.SelectedItem.ToString(),
                Cantidad = int.Parse(entryCantidad.Text),
                Precio = decimal.Parse(entryPrecio.Text),
                Imagen = _urlDescarga

            };

            var SetData = connection.client.SetAsync("ProductoDatabase/" + producto.Id, producto);
            await AppShell.Current.DisplayAlert("¡!", "Producto añadido correctamente", "OK");

            stack2.TranslateTo(540, 0);
            stack2.IsVisible = false;
            listaProductos.WidthRequest = 1100;
            stack1.WidthRequest = 1550;
            borde1.WidthRequest = 1200;
            buscador.WidthRequest = 500;

            actualizarLista();
            }

            

        }
        else if (labelTitulo.Text == "EDITAR")
        {
            if (validarProducto())
            {
                Producto producto = new Producto
                {
                    Id = idProducto,
                    Restaurante_Id = VistaPrinc._restauranteId,
                    Nombre = entryNombre.Text,
                    Proveedor = pickerProveedor.SelectedItem.ToString(),
                    Cantidad = int.Parse(entryCantidad.Text),
                    Precio = decimal.Parse(entryPrecio.Text),
                    Imagen = _urlDescarga

                };

                var SetData = connection.client.Update("ProductoDatabase/" + producto.Id, producto);
                await AppShell.Current.DisplayAlert("¡!", "Producto actualizado correctamente", "OK");

                stack2.TranslateTo(540, 0);
                stack2.IsVisible = false;
                listaProductos.WidthRequest = 1100;
                stack1.WidthRequest = 1550;
                borde1.WidthRequest = 1200;
                buscador.WidthRequest = 500;

                actualizarLista();
            }

        }

    }

    private bool validarProducto()
    {
        bool correcto = false;

        if (entryNombre.Text.Length != 0 && entryCantidad.Text.Length != 0 && entryPrecio.Text.Length != 0 && pickerProveedor.SelectedIndex != -1)
        {
            if (decimal.TryParse(entryPrecio.Text, out decimal numeroPrecio) && int.TryParse(entryCantidad.Text, out int numeroCantidad))
            {
                if (_urlDescarga.Length == 0)
                {
                    _urlDescarga = "https://firebasestorage.googleapis.com/v0/b/chefmg-664a2.appspot.com/o/Imagenes%2Fproducto.png?alt=media&token=c661172d-e919-49ff-a084-5934f4d14e02";
                }

                correcto = true;
            }
            else
            {
                AppShell.Current.DisplayAlert("Error", "Los campos Precio y Cantidad no son correctos. Por favor introduce solo números o separador por comas", "OK");
            }
        }
        else
        {
            AppShell.Current.DisplayAlert("Error", "Los campos no pueden estar vacíos", "OK");
        }

        return correcto;
    }

    
    public void EditarProducto()
    {
        lbl.Text = "Hola bebe";
        System.Diagnostics.Debug.WriteLine("Pepe");
        /*
        await stack2.TranslateTo(0, 0);
        stack2.IsVisible = true;
        borde1.WidthRequest = 860;
        listaProductos.WidthRequest = 750;
        buscador.WidthRequest = 300;

        stack1.WidthRequest = 1000;

        Producto producto = listaAuxProductos.FirstOrDefault(u => u.Id.Equals(idProducto));

        labelTitulo.Text = "EDITAR";
        entryNombre.Text = producto.Nombre;
        entryPrecio.Text = producto.Precio.ToString();
        pickerProveedor.SelectedItem = producto.Proveedor;
        entryImagen.Text = producto.Imagen;
        imagen.Source = producto.Imagen;
        entryCantidad.Text = producto.Cantidad.ToString();
        */

    }
    
    public async void verProducto()
    {

        Producto producto = listaAuxProductos.FirstOrDefault(u => u.Id.Equals(idProducto));
        await AppShell.Current.DisplayAlert("Información del producto: ",
            " Nombre: " + producto.Nombre + "\n" +
            " Proveedor: " + producto.Proveedor + "\n" +
            " Cantidad: " + producto.Cantidad + "\n" +
            " Precio: " + producto.Precio
            , "Volver");

       
    }

    private async void eliminarProducto(object sender, EventArgs e)
    {
        try
        {
            var SetData = connection.client.Delete("ProductoDatabase/" + idProducto);
            await AppShell.Current.DisplayAlert("¡!", "Producto eliminado correctamente", "OK");

            await stack2.TranslateTo(540, 0);
            stack2.IsVisible = false;
            listaProductos.WidthRequest = 1100;
            stack1.WidthRequest = 1550;
            borde1.WidthRequest = 1200;
            buscador.WidthRequest = 500;

            actualizarLista();
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error");
        }
    }

    private async void sumarRestarCantidad(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (button.Text == "-")
        {

            if (int.TryParse(entryCantidad.Text, out int numero))
            {
                int numeromenos = numero - 1;

                entryCantidad.Text = numeromenos.ToString();
            }
            else
            {
                await AppShell.Current.DisplayAlert("Error", "Porfavor introduce solo numeros en el campo Cantidad", "OK");
            }


        }
        else if (button.Text == "+")
        {
            if (int.TryParse(entryCantidad.Text, out int numero))
            {
                int numeromenos = numero + 1;

                entryCantidad.Text = numeromenos.ToString();
            }
            else
            {
                await AppShell.Current.DisplayAlert("Error", "Porfavor introduce solo numeros en el campo Cantidad", "OK");
            }
        }
    }

    private async void Volver(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaPrinc));
    }
}