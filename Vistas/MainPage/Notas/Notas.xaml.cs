using ChefManager.Modelo;
using ChefManager.Vistas.MainPage;

namespace ChefManager.Vistas;

public partial class Notas : ContentPage
{
    FirebaseConnection firebaseconnection = new FirebaseConnection();
    public static string _idNota;
    List<Nota> listaNotasAux;


    public Notas()
    {
        InitializeComponent();
        listaNotasAux = firebaseconnection.obtenerInfo<Nota>("NotaDatabase").Where(u => u.Restaurante_Id == VistaPrinc._restauranteId).ToList();

        if (listaNotasAux.Count != 0)
        {

            listaNotas.ItemsSource = listaNotasAux;
        }
    }


    private void Buscar(object sender, EventArgs e)
    {
        listaNotas.ItemsSource = listaNotasAux.Where(u => u.Titulo.Contains(buscador.Text));
    }

    private async void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        ImageButton imageButton = (ImageButton)sender;
        imageButton.Shadow.Brush = new SolidColorBrush(Colors.White);
        await imageButton.TranslateTo(0, -3, 200);

    }

    private async void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        ImageButton imageButton = (ImageButton)sender;
        imageButton.Shadow.Brush = new SolidColorBrush(Colors.SandyBrown);
        await imageButton.TranslateTo(0, 3, 200);



    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(AgregarNota));

    }

    private async void Volver(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(VistaPrinc));
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var stack = (VerticalStackLayout)sender;
        var nota = (Nota)stack.Parent.Parent.BindingContext;

        _idNota = nota.Id;
        AppShell.Current.GoToAsync(nameof(VerNota));
    }
}