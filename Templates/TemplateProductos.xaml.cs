using ChefManager.Modelo;
using ChefManager.Vistas;
namespace ChefManager.Templates;

public partial class TemplateProductos : ContentView
{
    Inventario inventario = new Inventario();
    
        
	public TemplateProductos()
	{
		InitializeComponent();
    }

    private void verProducto(object sender, EventArgs e)
    {
        Inventario.idProducto = idProducto.Text;        
        inventario.verProducto();
    }

    private void EditarProducto(object sender, EventArgs e)
    {
        if (BindingContext is Inventario inventario)
        {
            inventario.EditarProducto();
        }
    }
}