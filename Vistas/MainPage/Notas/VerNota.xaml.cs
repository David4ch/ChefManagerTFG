using ChefManager.Modelo;
using ChefManager.Templates;

namespace ChefManager.Vistas.MainPage;

public partial class VerNota : ContentPage
{
    FirebaseConnection connection = new FirebaseConnection();
    
    public VerNota()
    {
        InitializeComponent();
        Nota nota = obtenerNota();
        entryTitulo.Text = nota.Titulo.ToString();
        TextEditor.Text = nota.Mensaje.ToString();
    }
    private Nota obtenerNota() {
        List<Nota> listaNotas = connection.obtenerInfo<Nota>("NotaDatabase").ToList();

        Nota nota = listaNotas.FirstOrDefault(u => u.Id == Notas._idNota);

        return nota;
    }

    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        try
        {   
            var SetData = connection.client.Delete("NotaDatabase/" + obtenerNota().Id.ToString());
            await AppShell.Current.GoToAsync(nameof(Notas));
        }
        catch (Exception)
        {
            System.Diagnostics.Debug.WriteLine("Error");
        }
    }

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        if (entryTitulo.Text.Length < 25 && TextEditor.Text.Length < 150 && entryTitulo.Text.Length != 0 && TextEditor.Text.Length != 0)
        {
                try
                {
                    Nota notaanterior = obtenerNota();

                    Nota nota = new Nota()
                    {
                        Id = notaanterior.Id,
                        Restaurante_Id = notaanterior.Restaurante_Id,
                        Titulo = entryTitulo.Text,
                        Mensaje = TextEditor.Text,
                        Date = DateTime.Now
                    };

                    var SetData = connection.client.Update("NotaDatabase/" + nota.Id, nota);

                    await AppShell.Current.GoToAsync(nameof(Notas));
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Error");
                }
        }
        else
        {
            await AppShell.Current.DisplayAlert("ERROR", "El titulo tiene que tener menos de 25 caracteres y el mensaje menos de 150 caracteres y además no puede estar vacío", "Ok");
        }

    }
}