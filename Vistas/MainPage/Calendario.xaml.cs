using ChefManager.Modelo;
using Plugin.Maui.Calendar.Models;

namespace ChefManager.Vistas;

public partial class Calendario : ContentPage
{
    FirebaseConnection connection = new FirebaseConnection();

    public EventCollection Events { get; set; }

    public Calendario()
    {
        InitializeComponent();
        List<Proveedor> listaProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == "28193324-b08d-4c44-a07a-226a21788eae").ToList();
        List<string> strings = new List<string>();
        foreach (var item in listaProveedores)
        {
            strings.Add(item.NombreEmpresa + ": " + item.Periocidad);
        }

        string proveedorInfo = string.Join("\n", strings);



        AppShell.Current.DisplayAlert("Comprobación", "Tienes estos proveedores:  " + proveedorInfo, "OK");
        DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        List<DateTime> daysOfMonth = new List<DateTime>();

        for (DateTime day = firstDayOfMonth; day <= lastDayOfMonth; day = day.AddDays(1))
        {
            daysOfMonth.Add(day);
        }

        Events = new EventCollection();

        foreach (DateTime day in daysOfMonth)
        {
            Events[day] = new List<Dinero>
    {
        new Dinero { Cantidad = "200€", Turno = "Turno mañana" }
    };
        }
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
