using ChefManager.Modelo;
using Plugin.Maui.Calendar.Models;
using System.Collections.Generic;
using System.Globalization;

namespace ChefManager.Vistas;

public partial class Calendario : ContentPage
{
    FirebaseConnection connection;


    public EventCollection Events { get; set; }
    public CultureInfo Culture { get; set; }
   

    public Calendario()
    {
        Culture = new CultureInfo("es-ES");
        connection = new FirebaseConnection();
        Events = new EventCollection();
        InitializeComponent();
        List<Proveedor> listaProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        List<string> strings = [];
        foreach (var item in listaProveedores)
        {
            strings.Add(item.NombreEmpresa + ": " + item.Periocidad);
        }

        string proveedorInfo = string.Join("\n", strings);



        AppShell.Current.DisplayAlert("Comprobación", "Tienes estos proveedores: \n" + proveedorInfo, "OK");
        if (listaProveedores.Count != 0)
        {
            InicializarCalendario();

          
        }
        else
        {
            AppShell.Current.DisplayAlert("Advertencia", "Para la correcta funcionalidad del Calendario asegúrate de tener proveedores añadidos!", "OK");

        }
    }

    private void InicializarCalendario()
    {
        List<Proveedor> listaProveedores = connection.obtenerInfo<Proveedor>("ProveedorDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();
        List<Proveedor> listaViernes = new List<Proveedor>();
        List<Proveedor> listaLunes = new List<Proveedor>();
        List<Proveedor> listaMartes = new List<Proveedor>();
        List<Proveedor> listaMiercoles = new List<Proveedor>();
        List<Proveedor> listaJueves = new List<Proveedor>();


        List<Proveedor> listaViernes2 = new List<Proveedor>();
        List<Proveedor> listaLunes2 = new List<Proveedor>();
        List<Proveedor> listaMartes2 = new List<Proveedor>();
        List<Proveedor> listaMiercoles2 = new List<Proveedor>();
        List<Proveedor> listaJueves2 = new List<Proveedor>();

        foreach (var item in listaProveedores)
        {
            string[] partes = item.Periocidad.Split('-');
            switch (partes[0])
            {

                case "Semanal":
                    switch (partes[1].ToString())
                    {
                        case "L":
                            listaLunes.Add(item);
                            break;
                        case "M":
                            listaMartes.Add(item);
                            break;
                        case "J":
                            listaJueves.Add(item);
                            break;
                        case "V":
                            listaViernes.Add(item);
                            break;
                        default:
                            listaMiercoles.Add(item);
                            break;
                    }
                    break;
                case "Quincenal":
                    switch (partes[1].ToString())
                    {
                        case "L":
                            listaLunes2.Add(item);
                            break;
                        case "M":
                            listaMartes2.Add(item);
                            break;
                        case "J":
                            listaJueves2.Add(item);
                            break;
                        case "V":
                            listaViernes2.Add(item);
                            break;
                        default:
                            listaMiercoles2.Add(item);
                            break;
                    }
                    break;
                case "Mensual":
                    DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, int.Parse(partes[1]));

                    Events[fecha] = new List<Proveedor>() { item };

                    break;



            }
        }

        foreach (var dia in new[] { (listaLunes, DayOfWeek.Monday), (listaMartes, DayOfWeek.Tuesday), (listaMiercoles, DayOfWeek.Wednesday), (listaJueves, DayOfWeek.Thursday), (listaViernes, DayOfWeek.Friday) })
        {
            if (dia.Item1.Count > 0)
            {
                AgregarListaACalendario(dia.Item1, dia.Item2);
            }
        }

        foreach (var dia in new[] { (listaLunes2, DayOfWeek.Monday), (listaMartes2, DayOfWeek.Tuesday), (listaMiercoles2, DayOfWeek.Wednesday), (listaJueves2, DayOfWeek.Thursday), (listaViernes2, DayOfWeek.Friday) })
        {
            if (dia.Item1.Count > 0)
            {
                AgregarListaQuincenalACalendario(dia.Item1, dia.Item2);
            }
        }




    }
    private void AgregarListaACalendario(List<Proveedor> listaProveedoresSemanal, DayOfWeek dia)
    {
        List<DateTime> listaDiasSemana = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
        .Select(day => new DateTime(DateTime.Now.Year, DateTime.Now.Month, day))
        .Where(date => date.DayOfWeek == dia)
        .ToList();


        foreach (DateTime day in listaDiasSemana)
        {

            Events[day] = listaProveedoresSemanal;
        }

        BindingContext = this;
    }

    private void AgregarListaQuincenalACalendario(List<Proveedor> listaProveedoresSemanal, DayOfWeek dia)
    {
        int mesActual = DateTime.Now.Month;
        int anioActual = DateTime.Now.Year;

        List<DateTime> listaDiasSemana = new List<DateTime>();

        DateTime primerDia = new DateTime(anioActual, mesActual, 1);
        int diaInicial = (int)primerDia.DayOfWeek;
        int diferenciaInicial = (dia - primerDia.DayOfWeek + 7) % 7;

        DateTime fechaActual = primerDia.AddDays(diferenciaInicial);

        while (fechaActual.Month == mesActual)
        {
            listaDiasSemana.Add(fechaActual);
            fechaActual = fechaActual.AddDays(14);
        }


        foreach (DateTime day in listaDiasSemana)
        {

            Events[day] = listaProveedoresSemanal;
        }

        BindingContext = this;
    }



    private async void Volver(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaPrinc));
    }
}
