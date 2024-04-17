using ChefManager.Modelo;
using FireSharp.Response;
using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChefManager.Vistas;

public partial class VistaAdmin : ContentPage
{
    FirebaseConnection firebaseConnection = new FirebaseConnection();

    //public ObservableCollection<Restaurante> listaRestaurantesAux { get; set; }

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

    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromRgb(18, 34, 36);
        button.TextColor = Color.FromRgb(255, 134, 247);

    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromRgb(255, 134, 247);
        button.TextColor = Color.FromRgb(18, 34, 36);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        switch (button.Text)
        {
            case "Usuarios":
                labeltitulo.Text = "Usuarios";
                grid1.ColumnDefinitions = new ColumnDefinitionCollection
                    {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto }
                    };
                label0.Text = "Restaurante_Id";
                label1.Text = "Id";
                label2.Text = "NombreUser";
                label3.Text = "Email";
                label4.Text = "Contraseña";
                label5.Text = "Acciones";

                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible = true;
                label6.IsVisible = false;
                label7.IsVisible = false;
                label7.IsVisible = false;

                listaRestaurantes.IsVisible = false;

                listaUsuarios.IsVisible = true;
                listaUsuarios.ItemsSource = firebaseConnection.obtenerInfo<Usuario>("UsuarioDatabase");

                break;
            case "Restaurantes":
                labeltitulo.Text = "Restaurantes";
                grid1.ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto },
                    new ColumnDefinition { Width =GridLength.Auto }, 
                    new ColumnDefinition { Width =GridLength.Auto } 
                };
                label0.Text = "Id";
                label1.Text = "Nombre";
                label2.Text = "Dirección";
                label3.Text = "Logo";
                label4.Text = "Acciones";
                
                label3.IsVisible = true;
                label4.IsVisible = true;
                label5.IsVisible =false ;
                label6.IsVisible =false ;
                label7.IsVisible =false ;
                listaUsuarios.IsVisible = false;

                FirebaseConnection firebaseConnection2 = new FirebaseConnection();
                listaRestaurantes.IsVisible = true;
                listaRestaurantes.ItemsSource = firebaseConnection2.obtenerInfo<Restaurante>("RestauranteDatabase");
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
}