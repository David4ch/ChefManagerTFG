using ChefManager.Modelo;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Storage;
namespace ChefManager.Vistas;

public partial class Inventario : ContentPage
{
    List<Producto> ListaAuxProductos = new List<Producto>();
   private string _idProducto="";

    FirebaseConnection connection = new FirebaseConnection();
    List<Proveedor> listaAuxProveedores = [];
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

        MainThread.BeginInvokeOnMainThread(new Action(async () => await ObtenerToken()));

        //ListaAuxProductos = connection.obtenerInfo<Producto>("ProductoDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();
        ListaAuxProductos = connection.obtenerInfo<Producto>("ProductoDatabase").Where(u => u.Restaurante_Id == "28193324-b08d-4c44-a07a-226a21788eae").ToList();

        ActualizarLista();
        
    }

    private async Task ObtenerToken()
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

    private void ActualizarLista()
    {
        //ListaAuxProductos = connection.obtenerInfo<Producto>("ProductoDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();
        ListaAuxProductos = connection.obtenerInfo<Producto>("ProductoDatabase").Where(u => u.Restaurante_Id == "28193324-b08d-4c44-a07a-226a21788eae").ToList();

        if (ListaAuxProductos.Count != 0) { 
            listaProductos.ItemsSource = ListaAuxProductos;
        }
       

        
    }

    private async void SubirFoto(object sender, EventArgs e)
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

    private void Buscar(object sender, EventArgs e)
    {
        listaProductos.ItemsSource = ListaAuxProductos.Where(u => u.Nombre.Contains(buscador.Text));
    }

    private void Agregar(object sender, EventArgs e)
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

    private async void GuardarProducto(object sender, EventArgs e)
    {

        if (labelTitulo.Text == "AÑADIR")
        {
            
            if (ValidarProducto()) { 
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

            connection.client.SetAsync("ProductoDatabase/" + producto.Id, producto);
            await AppShell.Current.DisplayAlert("¡!", "Producto añadido correctamente", "OK");

            stack2.TranslateTo(540, 0);
            stack2.IsVisible = false;
            listaProductos.WidthRequest = 1100;
            stack1.WidthRequest = 1550;
            borde1.WidthRequest = 1200;
            buscador.WidthRequest = 500;

            ActualizarLista();
            }

            

        }
        else if (labelTitulo.Text == "EDITAR")
        {
            if (ValidarProducto())
            {
                
                Producto producto = new Producto
                {
                    Id = _idProducto,
                    Restaurante_Id = VistaPrinc._restauranteId,
                    Nombre = entryNombre.Text,
                    Proveedor = pickerProveedor.SelectedItem.ToString(),
                    Cantidad = int.Parse(entryCantidad.Text),
                    Precio = decimal.Parse(entryPrecio.Text),
                    Imagen = _urlDescarga

                };

                connection.client.Update("ProductoDatabase/" + producto.Id, producto);
                await AppShell.Current.DisplayAlert("¡!", "Producto actualizado correctamente", "OK");

                stack2.TranslateTo(540, 0);
                stack2.IsVisible = false;
                listaProductos.WidthRequest = 1100;
                stack1.WidthRequest = 1550;
                borde1.WidthRequest = 1200;
                buscador.WidthRequest = 500;

                entryNombre.Text = "";
                entryCantidad.Text = "";
                entryImagen.Text = "";
                entryPrecio.Text = "";
                imagen.Source = "";
                pickerProveedor.SelectedIndex = -1;

                ActualizarLista();
            }

        }

    }

    private bool ValidarProducto()
    {
        bool correcto = false;

        if (entryNombre.Text.Length != 0 && entryCantidad.Text.Length != 0 && entryPrecio.Text.Length != 0 && pickerProveedor.SelectedIndex != -1)
        {
            if (decimal.TryParse(entryPrecio.Text, out decimal numeroPrecio) && int.TryParse(entryCantidad.Text, out int numeroCantidad))
            {
                if (_urlDescarga.Length == 0)
                {
                    _urlDescarga = "https://firebasestorage.googleapis.com/v0/b/chefmg-664a2.appspot.com/o/Imagenes%2Fproducto.png?alt=media&token=f2c72a51-fb6e-4ea8-b906-0e659599053d";
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
    
    public async void EditarProducto(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var producto = (Producto)button.Parent.Parent.BindingContext;
        _idProducto = producto.Id;

        await stack2.TranslateTo(0, 0);
        stack2.IsVisible = true;
        borde1.WidthRequest = 860;
        listaProductos.WidthRequest = 750;
        buscador.WidthRequest = 300;

        stack1.WidthRequest = 1000;

        

        labelTitulo.Text = "EDITAR";
        entryNombre.Text = producto.Nombre;
        entryPrecio.Text = producto.Precio.ToString();
        pickerProveedor.SelectedItem = producto.Proveedor;
        entryImagen.Text = Path.GetFileName(new Uri(producto.Imagen).LocalPath);
        _urlDescarga = producto.Imagen;
        imagen.Source = producto.Imagen;
        entryCantidad.Text = producto.Cantidad.ToString();
        botonEliminar.IsVisible = true;

        listaAuxProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaAuxProveedores.Count != 0)
        {
            foreach (var item in listaAuxProveedores)
            {
                opciones.Add(item.NombreEmpresa);
            }

            opciones.Add("Otro");
            pickerProveedor.ItemsSource = opciones;
            pickerProveedor.SelectedItem = producto.Proveedor;
        }
        else
        {
            opciones.Add("Otro");
            pickerProveedor.ItemsSource = opciones;
        }


    }
    
    public async void VerProducto(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var producto = (Producto)button.Parent.Parent.BindingContext;
        await AppShell.Current.DisplayAlert("Información del producto: ",
            " Nombre: " + producto.Nombre + "\n" +
            " Proveedor: " + producto.Proveedor + "\n" +
            " Cantidad: " + producto.Cantidad + "\n" +
            " Precio: " + producto.Precio
            , "Volver");
           
    }

    private async void EliminarProducto(object sender, EventArgs e)
    {
       
        try
        {
            var SetData = connection.client.Delete("ProductoDatabase/" + _idProducto);
            await AppShell.Current.DisplayAlert("¡!", "Producto eliminado correctamente", "OK");

            await stack2.TranslateTo(540, 0);
            stack2.IsVisible = false;
            listaProductos.WidthRequest = 1100;
            stack1.WidthRequest = 1550;
            borde1.WidthRequest = 1200;
            buscador.WidthRequest = 500;

            ActualizarLista();
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error");
        }
    }

    private async void SumarRestarCantidad(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (button.Text == "-")
        {
            if (int.Parse(entryCantidad.Text) > 0) { 
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