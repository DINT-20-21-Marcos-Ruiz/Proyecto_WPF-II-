using Proyecto_WPF_II_.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public Pelicula PeliculaSeleccionada { get; set; }
        public ObservableCollection<Pelicula> ListaPeliculas { get; set; }

        private readonly BaseDatosService _bbdd;
        private readonly ApiRestService _api;

        public MainWindowVM()
        {
            _bbdd = new BaseDatosService();
            _api = new ApiRestService();
            ListaPeliculas = GetPeliculas();
        }

        public ObservableCollection<Pelicula> GetPeliculas()
        {
            var client = new RestClient(Properties.Settings.Default.apiDireccion);
            var request = new RestRequest("peliculas", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(response.Content);
        }






        public event PropertyChangedEventHandler PropertyChanged;
    }
}
