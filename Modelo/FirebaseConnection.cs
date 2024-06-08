﻿using FireSharp.Interfaces;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ChefManager.Modelo
{
    public class FirebaseConnection
    {
      
        //Configuracion conexión Firebase
        public IFirebaseConfig fc = new FirebaseConfig()
        {
            AuthSecret = "H58xpKu2FTVE58DvJcVWSmRTbaPmlZkjJuvdzr7O",
            BasePath = "https://chefmg-664a2-default-rtdb.europe-west1.firebasedatabase.app/"

        };

        public IFirebaseClient client;

        //Codigo para controlar si la conexion se establece
        public FirebaseConnection()
        {
            try
            {
                client = new FirebaseClient(fc);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Conexion Incorrecta");
            }
        }

        //Método que recoge la información de las tablas de Firebase
        public ObservableCollection<T> obtenerInfo<T>(string nombreDb) where T : class
        {
            ObservableCollection<T> auxLista = new ObservableCollection<T>();
            
            try
            {
                FirebaseResponse al = client.Get(nombreDb);
                Dictionary<string, T> ListData = JsonConvert.DeserializeObject<Dictionary<string, T>>(al.Body.ToString());

                if (ListData != null)
                {
                    auxLista = new ObservableCollection<T>(ListData.Values);
                }

            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Error obtener");
            }

            return auxLista;
        }
    }
}
