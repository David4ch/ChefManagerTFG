using ChefManager.Modelo;
using ChefManager.Vistas;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefManager.VistaModelo
{
    public partial class ValidadorRegistroRestaurante : ObservableValidator
    {
        
        FirebaseConnection connection = new FirebaseConnection();
        public ObservableCollection<string> ErroresRegistro { get; set; } = new ObservableCollection<string>();

        private string nombre;
        [RegularExpression(@".{0,15}", ErrorMessage = "El campo nombre debe tener menos de 15 caracteres")]
        [Required(ErrorMessage = "El nombre no puede estar vacío")]
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        private string direccion;
        [Required(ErrorMessage = "La dirección no puede estar vacía")]
        public string Direccion
        {
            get => direccion;
            set => SetProperty(ref direccion, value);
        }

        private string logo;
        [Required(ErrorMessage = "El logo no puede estar vacío")]
        public string Logo
        {
            get => logo;
            set => SetProperty(ref logo, value);
        }

        [RelayCommand]
        public async void validarRegistro() {

            ValidateAllProperties();
            ErroresRegistro.Clear();
            GetErrors(nameof(Logo)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));
            GetErrors(nameof(Direccion)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));
            GetErrors(nameof(Nombre)).ToList().ForEach(F => ErroresRegistro.Add(F.ErrorMessage));

            if (ErroresRegistro.Count == 0)
            {

                try
                {

                    Restaurante restaurante = new Restaurante
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nombre = nombre,
                        Direccion = direccion,
                        Logo = RegistroRestaurante._urlDescarga

                    };

                    var SetData = connection.client.SetAsync("RestauranteDatabase/" + restaurante.Id, restaurante);

                    RegistroRestaurante._idRestaurante = restaurante.Id;

                    await AppShell.Current.GoToAsync(nameof(RegistroUser));


                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("ERROR UPLOAD", "No se ha subido la imagen con exito", "OK");

                }
            }
            else {
                await Application.Current.MainPage.DisplayAlert("ERROR", ErroresRegistro.Last(), "OK");
            }
        }
    }
}
