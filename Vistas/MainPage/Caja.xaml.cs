using System.Collections.ObjectModel;

namespace ChefManager.Vistas
{
    public partial class Caja : ContentPage
    {
        public DateTime dia { get; }
        public ObservableCollection<int> lista2 = new ObservableCollection<int>();
       
        public Caja()
        {
            InitializeComponent();
            
            dia = DateTime.Now;
            mes.Text = dia.ToString("MMMM");
            string numDias = dia.ToString("MM");
            int numDias2 = ObtenerDiasEnMes(int.Parse(numDias));
            for (int i = 1; i <= numDias2; i++)
            {
                lista2.Add(i);
            }
            
            lista.ItemsSource = lista2;

        }
        public int ObtenerDiasEnMes(int numeroMes)
        {
            return DateTime.DaysInMonth(DateTime.Now.Year, numeroMes);
        }

        private async void numeroClick(object sender, EventArgs e)
        {
           
            
            if (sender is StackLayout stackLayout)
            {
                if (stackLayout.Children.OfType<Border>().FirstOrDefault() != null)
                {
                    stackLayout.Children.OfType<Border>().FirstOrDefault().BackgroundColor = Colors.Orange;
                    System.Diagnostics.Debug.WriteLine("bien");
                }
            }

        }
        private void pick(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            string seleccionado = picker.SelectedItem as string;
            ObservableCollection<int> listaAux = new ObservableCollection<int>();
            int numDias=0;
            switch (seleccionado)
            {
                case "Enero":
                    numDias = ObtenerDiasEnMes(1);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Enero";
                    lista.ItemsSource = listaAux;
                    break;
                case "Febrero":
                    numDias = ObtenerDiasEnMes(2);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Febrero";
                    lista.ItemsSource = listaAux;
                    break;
                case "Marzo":
                    numDias = ObtenerDiasEnMes(3);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Marzo";
                    lista.ItemsSource = listaAux;
                    break;
                case "Abril":
                    numDias = ObtenerDiasEnMes(4);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Abril";
                    lista.ItemsSource = listaAux;
                    break;
                case "Mayo":
                    numDias = ObtenerDiasEnMes(5);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Mayo";
                    lista.ItemsSource = listaAux;
                    break;
                case "Junio":
                    numDias = ObtenerDiasEnMes(6);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Junio";
                    lista.ItemsSource = listaAux;
                    break;
                case "Julio":
                    numDias = ObtenerDiasEnMes(7);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Julio";
                    lista.ItemsSource = listaAux;
                    break;
                case "Agosto":
                    numDias = ObtenerDiasEnMes(8);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Agosto";
                    lista.ItemsSource = listaAux;
                    break;
                case "Septiembre":
                    numDias = ObtenerDiasEnMes(9);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Septiembre";
                    lista.ItemsSource = listaAux;
                    break;
                case "Octubre":
                    numDias = ObtenerDiasEnMes(10);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Octubre";
                    lista.ItemsSource = listaAux;
                    break;
                case "Noviembre":
                    numDias = ObtenerDiasEnMes(11);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Noviembre";
                    lista.ItemsSource = listaAux;
                    break;
                case "Diciembre":
                    numDias = ObtenerDiasEnMes(12);
                    for (int i = 1; i <= numDias; i++)
                    {
                        listaAux.Add(i);
                    }
                    mes.Text = "Diciembre";
                    lista.ItemsSource = listaAux;
                    break;
                default:
                    
                    break;
            }
        }
    }

    }
