
using ChefManager.Modelo;
using ChefManager.PopUps;
using CommunityToolkit.Maui.Views;
using System.Globalization;

namespace ChefManager.Vistas
{
    public partial class Caja : ContentPage
    {
   
        FirebaseConnection connection;
        List<Dinero> ListaDineroAux;

        public Caja()
        {
            InitializeComponent();
            
            CultureInfo.CurrentCulture = new CultureInfo("es-ES");
            BindingContext = this;
            connection = new FirebaseConnection();

            ListaDineroAux = connection.obtenerInfo<Dinero>("DineroDatabase").Where(u => u.Restaurante_Id.Equals(VistaPrinc._restauranteId)).ToList();

            ActualizarLista();

        }

        private void ActualizarLista()
        {
            ListaDineroAux = connection.obtenerInfo<Dinero>("DineroDatabase").Where(u => u.Restaurante_Id.Equals(VistaPrinc._restauranteId)).ToList();

            if (ListaDineroAux.Count != 0)
            {
                nohay.IsVisible = false;
                listaDinero.IsVisible = true;
                stackOjo.IsVisible = true;
                listaDinero.ItemsSource = ListaDineroAux;
            }
            else {
                nohay.IsVisible = true; listaDinero.IsVisible = false; stackOjo.IsVisible = false;
            }
        }

        private void VerInforme(object sender, EventArgs e)
        {
            var popup = new VerRegistro();
            this.ShowPopup(popup);
        }

        private async void Agregar_Registro(object sender, EventArgs e)
        {
            if (entryCantidad.Text.Length != 0 && picker1.SelectedIndex != -1)
            {
                if (decimal.TryParse(entryCantidad.Text, out decimal numero))
                {
                    Dinero dinero = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Restaurante_Id = VistaPrinc._restauranteId,
                        Turno = picker1.SelectedItem.ToString(),
                        Cantidad = numero,
                        Fecha = datepicker1.Date
                    };

                    await connection.client.SetAsync("DineroDatabase/" + dinero.Id, dinero);

                    ActualizarLista();
                    entryCantidad.Text = "";
                    picker1.SelectedIndex = -1;
                    datepicker1.Date = DateTime.Now;

                    await AppShell.Current.DisplayAlert("¡!", "Registro Añadido Correctamente", "Ok");

                }
                else
                {
                    await AppShell.Current.DisplayAlert("¡!", "La cantidad tiene que ser un numero o un decimal", "Ok");
                }

            }
            else
            {
                await AppShell.Current.DisplayAlert("¡!", "Los campos no pueden estar vacíos", "Ok");
            }

        }
        
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
       
            double valor = e.NewValue;
            precio.Text = (int)valor + "€ - " + sliderMax.Value + "€";
        }
        private void Slider_ValueChanged2(object sender, ValueChangedEventArgs e)
        {

            double valor = e.NewValue;
            precio.Text = sliderMin.Value + "€ - " + (int)valor + "€";
        }


        private void Slider_DragCompleted(object sender, EventArgs e)
        {

            if (checkbox.IsChecked)
            {
                listaDinero.ItemsSource = ListaDineroAux.Where(u => u.Fecha == datepicker2.Date && u.Cantidad <= (int)sliderMax.Value && u.Cantidad >= (int)sliderMin.Value && u.Turno.Equals(picker2.SelectedItem.ToString()));

            }
            else
            {
                listaDinero.ItemsSource = ListaDineroAux.Where(u => u.Cantidad <= (int)sliderMax.Value && u.Cantidad >= (int)sliderMin.Value);
            }

        }

        private void Dia_Seleccionado(object sender, DateChangedEventArgs e)
        {
            if (checkbox.IsChecked)
            {
                if (picker2.SelectedItem.ToString() != null)
                {
                    listaDinero.ItemsSource = ListaDineroAux.Where(u => u.Fecha == datepicker2.Date && u.Cantidad <= (int)sliderMax.Value && u.Cantidad <= (int)sliderMax.Value && u.Turno.Equals(picker2.SelectedItem.ToString()));

                }
                else {
                    AppShell.Current.DisplayAlert("¡!", "Rellena primero el Turno", "Ok");
                }
                
            }
            else
            {
                listaDinero.ItemsSource = ListaDineroAux.Where(u => u.Fecha == datepicker2.Date);
            }

        }

        private void Turno_Seleccionado(object sender, EventArgs e)
        {
            if (checkbox.IsChecked)
            {
                listaDinero.ItemsSource = ListaDineroAux.Where(u => u.Fecha == datepicker2.Date && u.Cantidad <= (int)sliderMax.Value && u.Cantidad <= (int)sliderMax.Value && u.Turno.Equals(picker2.SelectedItem.ToString()));

            }
            else
            {
                listaDinero.ItemsSource = ListaDineroAux.Where(u => u.Turno.Equals(picker2.SelectedItem.ToString()));
            }
        }

        private void EntryCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbldinero.Text = entryCantidad.Text + "€";
        }

        private async void Volver(object sender, EventArgs e)
        {
            await AppShell.Current.GoToAsync(nameof(VistaPrinc));
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var dinero = (Dinero)button.Parent.BindingContext;

            try
            {
                var SetData = connection.client.Delete("DineroDatabase/" + dinero.Id);
                AppShell.Current.DisplayAlert("¡!", "Dinero Eliminado correctamente", "Ok");
                ActualizarLista();
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

}
