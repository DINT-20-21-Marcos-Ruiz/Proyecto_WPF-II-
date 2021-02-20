using Proyecto_WPF_II_.POJO;
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
        public ObservableCollection<Pelicula> ListaPeliculasObv { get; set; }

        public Sala SalaSeleccionada { get; set; }
        public Sala SalaFormulario { get; set; }
        public ObservableCollection<Sala> ListaSalas { get; set; }

        public Sesion SesionSeleccionada { get; set; }
        public ObservableCollection<Sesion> ListaSesiones { get; set; }

        private readonly BaseDatosService _bbdd;
        private DateTime ultimaFecha;

        public MainWindowVM()
        {
            _bbdd = new BaseDatosService();
            ComprobarFecha();
            ListaPeliculas = ListaPeliculasObv;

            SalaFormulario = new Sala();
        }

        public ObservableCollection<Pelicula> GetPeliculas()
        {
            var client = new RestClient(Properties.Settings.Default.apiDireccion);
            var request = new RestRequest("peliculas", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(response.Content);
        }


        public void ComprobarFecha()
        {
            DateTime actFecha = DateTime.Now.Date;
            if(ultimaFecha != actFecha)
            {
                ListaPeliculasObv = GetPeliculas();
                ultimaFecha = actFecha;
            }
        }

        //SALAS ------------------------------------------------------->
        public void AñadirSala()
        {
            SalaFormulario = new Sala();
            _bbdd.InsertarSala(SalaFormulario);
            SalaFormulario = new Sala();

            ListaSalas = _bbdd.ObtenerSalas();
        }
        public void ModificarSala()
        {
            SalaFormulario = new Sala(SalaSeleccionada);
            _bbdd.ModificarSala(SalaFormulario);

            ListaSalas = _bbdd.ObtenerSalas();
        }
        public Boolean ComprobarNumSala(string num)
        {
            if (_bbdd.ComprobarNumeroSalas(num)) return true;
            else return false;
        }
        public Boolean SalaFormOk()
        {
            return (SalaFormulario.Numero != "" && SalaFormulario.Capacidad > 0);
        }
        public Boolean HayPersonaSeleccionada()
        {
            return SalaSeleccionada != null;
        }





        public event PropertyChangedEventHandler PropertyChanged;
    }
}
