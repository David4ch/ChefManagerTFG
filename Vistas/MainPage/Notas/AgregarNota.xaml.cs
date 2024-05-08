using ChefManager.Modelo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChefManager.Vistas.MainPage;

public partial class AgregarNota : ContentPage
{

    public AgregarNota()
    {
        InitializeComponent();

    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        FirebaseConnection connection = new FirebaseConnection();
        if (entryTitulo.Text.Length != 0 && TextEditor.Text.Length != 0 && entryTitulo.Text.Length < 25 && TextEditor.Text.Length < 150)
        {
            Nota nota = new Nota
            {
                Id = Guid.NewGuid().ToString(),
                Restaurante_Id = VistaPrinc._restauranteId,
                Titulo = entryTitulo.Text,
                Mensaje = TextEditor.Text,
                Date = DateTime.Now

            };

            var SetData = connection.client.SetAsync("NotaDatabase/" + nota.Id, nota);

            await AppShell.Current.GoToAsync(nameof(Notas));

        }
        else
        {

            await AppShell.Current.DisplayAlert("ERROR", "El titulo tiene que tener menos de 25 caracteres y el mensaje menos de 150 caracteres y además no pueden estar vacíos", "Ok");
        }


    }

}