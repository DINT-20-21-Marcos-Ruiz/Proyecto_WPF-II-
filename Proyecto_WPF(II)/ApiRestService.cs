
using Newtonsoft.Json;
using Proyecto_WPF_II_.Clases;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_
{
    public class ApiRestService
    {
        public ObservableCollection<PeliculaResponse> GetPeliculas()
        {
            var client = new RestClient(Properties.Settings.Default.apiDireccion);
            var request = new RestRequest("peliculas",Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<PeliculaResponse>>(response.Content);
        }

        public class PeliculaResponse
        {
            public int IdPelicula { get; set; }
            public string Titulo { get; set; }
            public string Cartel { get; set; }
            public int Año { get; set; }
            public string Genero { get; set; }
            public string Calificacion { get; set; }
        }

    }
}
