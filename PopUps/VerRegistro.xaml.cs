
using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Maui.Views;
namespace ChefManager.PopUps;

public partial class VerRegistro : Popup
{
    FirebaseConnection _connection;
    List<Dinero> ListaDinero;

    public VerRegistro()
	{
		InitializeComponent();

        _connection = new FirebaseConnection();
        ListaDinero = _connection.obtenerInfo<Dinero>("DineroDatabase").Where(u => u.Restaurante_Id.Equals(VistaPrinc._restauranteId)).ToList();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {   
        List<Dinero> ListaAux = ListaDinero.Where(u => u.Fecha >= datepickerInicio.Date && u.Fecha <= datepickerFin.Date).ToList();
        if (ListaAux.Count != 0)
        {
            decimal sumaTotal = 0;
            decimal suma2 = 0;
            decimal suma1 = 0;
            foreach (var item in ListaAux)
            {

                if (item.Turno.Equals("Mañana"))
                {
                    suma1 += item.Cantidad;
                }
                else if (item.Turno.Equals("Tarde"))
                {
                    suma2 += item.Cantidad;
                }
                sumaTotal += item.Cantidad;
            }

            label1.Text = suma1 + " €";
            label2.Text = suma2 + " €";
            labelTotal.Text = sumaTotal + " €";
        }
        else {
            await AppShell.Current.DisplayAlert("¡!", "No hay registros entre las fechas introducidas", "Ok");
        }
        

        
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {
        Close();
    }
}