using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ChefManager.VistaModelo
{
    public partial class ValidadorInicio : ObservableValidator
    {
      
        private string _contrasena;
        public string Contrasena
        {
            get => _contrasena;
            set => SetProperty(ref _contrasena, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        [RelayCommand]
        public async void validarInicio()
        {
            
            FirebaseConnection connection = new FirebaseConnection();
            List<Usuario> listaUsuarios = connection.obtenerInfo<Usuario>("UsuarioDatabase").ToList();

            bool esUsuarioValido = listaUsuarios.Any(u => u.Email == _email && u.Contrasena == _contrasena);

            if (esUsuarioValido)
            {
                if (_email == "Admin@gmail.com" && _contrasena == "Administrador4-")
                {
                    await AppShell.Current.GoToAsync(nameof(VistaAdmin));
                }
                else { 
                await AppShell.Current.GoToAsync(nameof(VistaPrinc));
                }
                
            }
            else
            {
                await AppShell.Current.DisplayAlert("ERROR UPLOAD", "La contraseña o el correo son incorrectos", "OK");
            }
        }
    }
}
