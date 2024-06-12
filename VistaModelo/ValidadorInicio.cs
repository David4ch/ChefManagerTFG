using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Security.Cryptography;

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
            List<Restaurante> listaRestaurantes = connection.obtenerInfo<Restaurante>("RestauranteDatabase").ToList();

            try
            {

                if (_email != null || _contrasena !=null)
                {
                    Usuario usuarioValido = listaUsuarios.FirstOrDefault(u => u.Email == _email && u.Contrasena.Equals(Encriptacion.Encriptar(_contrasena)));


                    if (usuarioValido != null)
                    {
                        if (_email == "Admin@gmail.com")
                        {
                            await AppShell.Current.GoToAsync(nameof(VistaAdmin));
                        }
                        else
                        {
                            Restaurante restaurante = listaRestaurantes.FirstOrDefault(u => u.Id == usuarioValido.Restaurante_Id);
                            VistaPrinc._ubicacion = restaurante.Direccion;
                            VistaPrinc._user = usuarioValido.NombreUser;
                            VistaPrinc._logo = restaurante.Logo;
                            VistaPrinc._restauranteId = restaurante.Id;

                            await AppShell.Current.GoToAsync(nameof(VistaPrinc));
                        }

                    }
                    else
                    {
                        await AppShell.Current.DisplayAlert("INCORRECTO", "La contraseña o el correo son incorrectos", "OK");
                    }
                }
                else
                {
                    await AppShell.Current.DisplayAlert("!¡", "Los campos no pueden estar vacíos", "OK");
                }

            }
            catch (FormatException ex)
            {
                await AppShell.Current.DisplayAlert("Error", "Decodificar mal", "OK");
            }




        }
    }
}
