using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace ChefManager.VistaModelo
{
    public partial class ValidadorRegistroUsuario : ObservableValidator
    {
        public ObservableCollection<string> ErroresRegistro { get; set; } = new ObservableCollection<string>();
        FirebaseConnection connection = new FirebaseConnection();

        private string nombre;

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Solo se permiten letras en el campo Nombre.")]
        [StringLength(15, ErrorMessage = "El campo debe tener máximo 15 caracteres.")]
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        private string email;
        [EmailAddress(ErrorMessage = "El formato de email es inválido.")]
        [Required(ErrorMessage = "El email no puede estar vacío")]
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string contrasena;

        [MinLength(8, ErrorMessage = "La contraseña debe tener mínimo 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial.")]
        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        public string Contrasena
        {
            get => contrasena;
            set => SetProperty(ref contrasena, value);
        }

        private string contrasenaRepetida;
        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        public string ContrasenaRepetida
        {
            get => contrasenaRepetida;
            set => SetProperty(ref contrasenaRepetida, value);
        }

        [RelayCommand]
        public async void validarRegistro()
        {
            ValidateAllProperties();
            ErroresRegistro.Clear();
            GetErrors(nameof(Nombre)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));
            GetErrors(nameof(Email)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));
            GetErrors(nameof(Contrasena)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));
            GetErrors(nameof(ContrasenaRepetida)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));

            if (contrasena != contrasenaRepetida)
            {
                ErroresRegistro.Add("Los campos 'Contraseña' deben ser idénticos.");
            }

            if (ErroresRegistro.Count == 0)
            {
                try
                {
                    Usuario usuario = new Usuario
                    {
                        Id = Guid.NewGuid().ToString(),
                        Restaurante_Id = RegistroRestaurante._idRestaurante,
                        NombreUser = nombre,
                        Email = email,
                        Contrasena = Encriptacion.Encriptar(contrasena),

                    };
                    var SetData = connection.client.SetAsync("UsuarioDatabase/" + usuario.Id, usuario);

                    await AppShell.Current.GoToAsync(nameof(VistaLogin));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Processing failed: {ex.Message}");
                }


            }
            else {
                await Application.Current.MainPage.DisplayAlert("ERROR", ErroresRegistro.Last(), "OK");
            }
        }
        }
    }
