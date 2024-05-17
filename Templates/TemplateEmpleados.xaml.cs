using ChefManager.Modelo;
using ChefManager.PopUps;

using CommunityToolkit.Maui.Views;

namespace ChefManager.Templates;

public partial class TemplateEmpleados : ContentView
{
    public static string _sourceNomina;
    public static string _idEmpleado;
    FirebaseConnection connection = new FirebaseConnection();

	public TemplateEmpleados()
	{
		InitializeComponent();
        
        
	}

    private void VerNomina(object sender, EventArgs e)
    {
        _sourceNomina = SourceNomina.Text;
       

        // Obtener la página actual
        var currentPage = this.Parent;
        while (currentPage != null && !(currentPage is ContentPage))
        {
            currentPage = currentPage.Parent;
        }

        // Verificar si se encontró una página
        if (currentPage is ContentPage page)
        {
            var popup = new VerNomina();
            page.ShowPopup(popup);
        }
        else
        {
            // Manejar el caso en el que no se encontró una página
            System.Diagnostics.Debug.WriteLine("No se encontró una página válida para mostrar el popup.");
        }
    }

    private void EditarEmpleado(object sender, EventArgs e)
    {
        _idEmpleado = IdEmpleado.Text;

        // Obtener la página actual
        var currentPage = this.Parent;
        while (currentPage != null && !(currentPage is ContentPage))
        {
            currentPage = currentPage.Parent;
        }

        // Verificar si se encontró una página
        if (currentPage is ContentPage page)
        {
            var popup = new EditarEmpleado();
            page.ShowPopup(popup);
        }
        else
        {
            // Manejar el caso en el que no se encontró una página
            System.Diagnostics.Debug.WriteLine("No se encontró una página válida para mostrar el popup.");
        }
    }

    private void EliminarEmpleado(object sender, EventArgs e)
    {
        try
        {
            var SetData = connection.client.Delete("EmpleadoDatabase/" + IdEmpleado.Text);
            AppShell.Current.DisplayAlert("¡!", "Empleado despedido correctamente", "Ok");
            //proveedores.actualizarLista();
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error al eliminar");
        }
    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.Red;
    }
    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.BackgroundColor = Colors.Transparent;
    }
}