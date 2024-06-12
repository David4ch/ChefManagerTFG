using ChefManager.Modelo;
using CommunityToolkit.Maui.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ChefManager.PopUps;

public partial class EditarElemento : Popup
{
    public static string nombreElemento;
    public static string idElemento;
    FirebaseConnection connection;

    public EditarElemento()
    {
        connection = new FirebaseConnection();
        InitializeComponent();
        switch (nombreElemento)
        {
            case "USUARIOS":
                titulo.Text = "Editar Usuario";
                Usuario usuario = connection.obtenerInfo<Usuario>("UsuarioDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Restaurante_ID";
                entry1.Text = usuario.Restaurante_Id;

                label2.Text = "NombreUser";
                entry2.Text = usuario.NombreUser;

                label3.Text = "Email";
                entry3.Text = usuario.Email;

                label4.IsVisible = false;
                label5.IsVisible = false;
                label6.IsVisible = false;

                entry4.IsVisible = false;
                entry5.IsVisible = false;
                entry6.IsVisible = false;

                break;
            case "RESTAURANTES":
                titulo.Text = "Editar Restaurante";
                Restaurante restaurante = connection.obtenerInfo<Restaurante>("RestauranteDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Nombre";
                entry1.Text = restaurante.Nombre;

                label2.Text = "Dirección";
                entry2.Text = restaurante.Direccion;

                label3.Text = "Logo";
                entry3.Text = restaurante.Logo;

                label4.IsVisible = false;
                label5.IsVisible = false;
                label6.IsVisible = false;

                entry4.IsVisible = false;
                entry5.IsVisible = false;
                entry6.IsVisible = false;
                break;
            case "PRODUCTOS":
                titulo.Text = "Editar Producto";
                Producto producto = connection.obtenerInfo<Producto>("ProductoDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Restaurante_ID";
                entry1.Text = producto.Restaurante_Id;

                label2.Text = "Nombre";
                entry2.Text = producto.Nombre;

                label3.Text = "Precio";
                entry3.Text = producto.Precio.ToString();

                label4.Text = "Cantidad";
                entry4.Text = producto.Cantidad.ToString();

                label5.Text = "Proveedor";
                entry5.Text = producto.Proveedor;

                label6.Text = "Imagen";
                entry6.Text = producto.Imagen;


                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = true;

                entry4.IsVisible = true;
                entry5.IsVisible = true;
                entry6.IsVisible = true;
                break;
            case "PROVEEDORES":
                titulo.Text = "Editar Proveedor";
                Proveedor proveedor = connection.obtenerInfo<Proveedor>("ProveedorDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Restaurante_ID";
                entry1.Text = proveedor.Restaurante_Id;

                label2.Text = "Nombre Empresa";
                entry2.Text = proveedor.NombreEmpresa;

                label3.Text = "Tipo Producto";
                entry3.Text = proveedor.TipoProducto;

                label4.Text = "Descripción";
                entry4.Text = proveedor.Descripción;

                label5.Text = "Precio";
                entry5.Text = proveedor.Precio.ToString();

                label6.Text = "Periocidad";
                entry6.Text = proveedor.Periocidad;


                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = true;

                entry4.IsVisible = true;
                entry5.IsVisible = true;
                entry6.IsVisible = true;
                break;
            case "NOTAS":
                titulo.Text = "Editar Nota";
                Nota nota = connection.obtenerInfo<Nota>("NotaDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Titulo";
                entry1.Text = nota.Titulo;

                label2.Text = "Mensaje";
                entry2.Text = nota.Mensaje;



                label3.IsVisible = false;
                label4.IsVisible = false;
                label5.IsVisible = false;
                label6.IsVisible = false;

                entry3.IsVisible = false;
                entry4.IsVisible = false;
                entry5.IsVisible = false;
                entry6.IsVisible = false;
                break;
            case "EMPLEADOS":
                titulo.Text = "Editar Empleado";
                Empleado empleado = connection.obtenerInfo<Empleado>("EmpleadoDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Restaurante_ID";
                entry1.Text = empleado.Restaurante_Id;

                label2.Text = "Nombre";
                entry2.Text = empleado.Nombre;

                label3.Text = "Puesto";
                entry3.Text = empleado.Puesto;

                label4.Text = "Nomina";
                entry4.Text = empleado.ImagenNomina;

                label5.Text = "Contacto";
                entry5.Text = empleado.Contacto;

                label6.Text = "Disponibilidad";
                entry6.Text = empleado.Disponibilidad.ToString();


                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = true;

                entry4.IsVisible = true;
                entry5.IsVisible = true;
                entry6.IsVisible = true;
                break;
            case "DINERO":
                titulo.Text = "Editar Dinero";
                Dinero dinero = connection.obtenerInfo<Dinero>("DineroDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                label1.Text = "Restaurante_ID";
                entry1.Text = dinero.Restaurante_Id;

                label2.Text = "Turno";
                entry2.Text = dinero.Turno;

                label3.Text = "Cantidad";
                entry3.Text = dinero.Cantidad.ToString();

                label4.Text = "Fecha";
                entry4.Text = dinero.Fecha.ToString();


                label4.IsVisible = true;
                label5.IsVisible = false;
                label6.IsVisible = false;

                entry4.IsVisible = true;
                entry5.IsVisible = false;
                entry6.IsVisible = false;
                break;

        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        switch (titulo.Text)
        {
            case "Editar Usuario":
                Usuario old_usuario = connection.obtenerInfo<Usuario>("UsuarioDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));
                Usuario usuario = new Usuario
                {
                    Id = idElemento,
                    Restaurante_Id = entry1.Text,
                    NombreUser = entry2.Text,
                    Email = entry3.Text,
                    Contrasena = old_usuario.Contrasena
                };

                connection.client.Update("UsuarioDatabase/" + usuario.Id, usuario);
                await AppShell.Current.DisplayAlert("¡!", "Usuario actualizado correctamente", "OK");
                break;
            case "Editar Restaurante":
                Restaurante old_restaurante = connection.obtenerInfo<Restaurante>("RestauranteDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));
                Restaurante restaurante = new Restaurante
                {
                    Id = idElemento,
                    Nombre = entry1.Text,
                    Direccion = entry2.Text,
                    Logo = entry3.Text
                };

                connection.client.Update("RestauranteDatabase/" + restaurante.Id, restaurante);
                await AppShell.Current.DisplayAlert("¡!", "Restaurante actualizado correctamente", "OK");

                break;
            case "Editar Producto":
                Producto old_producto = connection.obtenerInfo<Producto>("ProductoDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));
                Producto producto = new Producto
                {
                    Id = idElemento,
                    Restaurante_Id = old_producto.Restaurante_Id,
                    Nombre = entry2.Text,
                    Proveedor = entry5.Text,
                    Cantidad = int.Parse(entry4.Text),
                    Precio = decimal.Parse(entry3.Text),
                    Imagen = entry6.Text

                };

                connection.client.Update("ProductoDatabase/" + producto.Id, producto);
                await AppShell.Current.DisplayAlert("¡!", "Producto actualizado correctamente", "OK");

                break;
            case "Editar Proveedor":
                try
                {
                    Proveedor old_proveedor = connection.obtenerInfo<Proveedor>("ProveedorDatabase").FirstOrDefault(u => u.Id == idElemento);

                    Proveedor proveedor = new()
                    {
                        Id = idElemento,
                        Restaurante_Id = entry1.Text,
                        NombreEmpresa = entry2.Text,
                        Contacto = old_proveedor.Contacto,
                        TipoProducto = entry3.Text,
                        Descripción = entry4.Text,
                        Periocidad = entry6.Text,
                        Precio = decimal.Parse(entry5.Text)

                    };

                    connection.client.Update("ProveedorDatabase/" + proveedor.Id, proveedor);
                    await AppShell.Current.DisplayAlert("!¡", "Proveedor actualizado correctamente", "Ok");
                }
                catch (IOException ex)
                {
                    await AppShell.Current.DisplayAlert("!¡", "Error al actualizar el proveedor: " + ex.Message, "Ok");
                }
                break;
            case "Editar Nota":
                Nota notaanterior = connection.obtenerInfo<Nota>("NotaDatabase").FirstOrDefault(u => u.Id == idElemento);

                Nota nota = new Nota()
                {
                    Id = notaanterior.Id,
                    Restaurante_Id = notaanterior.Restaurante_Id,
                    Titulo = entry1.Text,
                    Mensaje = entry2.Text,
                    Date = DateTime.Now
                };

                connection.client.Update("NotaDatabase/" + nota.Id, nota);
                await AppShell.Current.DisplayAlert("!¡", "Nota actualizada correctamente", "Ok");

                break;
            case "Editar Empleado":
                Empleado empleado_old = connection.obtenerInfo<Empleado>("EmpleadoDatabase").FirstOrDefault(u => u.Id.Equals(idElemento));

                Empleado empleado = new Empleado
                {
                    Id = empleado_old.Id,
                    Restaurante_Id = entry1.Text,
                    Nombre = entry2.Text,
                    Puesto = entry3.Text,
                    Contacto = entry5.Text,
                    ImagenNomina = entry4.Text,
                    Disponibilidad = bool.Parse(entry6.Text)
                };

                connection.client.Update("EmpleadoDatabase/" + empleado.Id, empleado);

                await AppShell.Current.DisplayAlert("¡!", "Empleado Editado Correctamente", "Ok");
                break;
            default:
                await AppShell.Current.DisplayAlert("¡!", "Error", "Ok");
                break;

        }
        Close();
    }
}