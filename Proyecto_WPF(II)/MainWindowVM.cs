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
    public enum Modo { INSERT,UPDATE }
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
        public Sesion SesionFormulario { get; set; }

        public Venta VentaSeleccionada { get; set; }
        public ObservableCollection<Venta> ListaVentas { get; set; }
        public Venta VentaFormulario { get; set; }

        public Modo Accion { get; set; }

        private readonly BaseDatosService _bbdd;
        private DateTime ultimaFecha;

        public event PropertyChangedEventHandler PropertyChanged;
 
        public MainWindowVM()
        {
            _bbdd = new BaseDatosService();
            ComprobarFecha();
            ListaPeliculas = ListaPeliculasObv;
            ListaSalas = _bbdd.ObtenerSalas();
            ListaSesiones = _bbdd.ObtenerSesiones();
            SalaFormulario = new Sala();
            SesionFormulario = new Sesion();
            VentaFormulario = new Venta();

            Accion = Modo.INSERT;
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
            Accion = Modo.INSERT;
        }
        public void ModificarSala()
        {
            SalaFormulario = new Sala(SalaSeleccionada);
            Accion = Modo.UPDATE;
        }
        public void GuardarCambioSala()
        {
            if(Accion == Modo.INSERT)
            {
                _bbdd.InsertarSala(SalaFormulario);
                SalaFormulario = new Sala();
            }
            else
            {
                _bbdd.ModificarSala(SalaFormulario);
            }
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
        public Boolean HaySalaSeleccionada()
        {
            return SalaSeleccionada != null;
        }

        //SESIONES ------------------------------------------------------->
        public void AñadirSesion()
        {
            SesionFormulario = new Sesion();
            Accion = Modo.INSERT;
        }
        public void ModificarSesion()
        {
            SesionFormulario = new Sesion(SesionSeleccionada);
            Accion = Modo.UPDATE;
        }
        public void EliminarSesion()
        {
            _bbdd.DeleteSesion(SesionSeleccionada);
            ListaSesiones = _bbdd.ObtenerSesiones();
        }
        public void GuardarCambioSesion()
        {
            if (Accion == Modo.INSERT)
            {
                _bbdd.InsertarSesion(SesionFormulario);
                SesionFormulario = new Sesion();
            }
            else
            {
                _bbdd.ModificarSesion(SesionFormulario);
            }
            ListaSesiones = _bbdd.ObtenerSesiones();
        }
        public Boolean SalasDisponibles(string sala)
        {
            if (_bbdd.ComprobarSalaDisponible(sala)) return true;
            else return false;
        }
        public Boolean MaxSesionesAsociadas(string sala)
        {
            if (_bbdd.ComprobarNumSesiones(sala) >= 3) return true;
            else return false;
        }
        public Boolean SesionFormOk()
        {
            return (SesionFormulario.Pelicula >= 0 && SesionFormulario.Sala >= 0 && SesionFormulario.Hora != "") ;
        }
        public Boolean HaySesionSeleccionada()
        {
            return SesionSeleccionada != null;
        }

        //VENTAS ------------------------------------------------------->
        public void AñadirEntrada()
        {
            _bbdd.InsertarVenta(VentaFormulario);
            VentaFormulario = new Venta();
            ListaVentas = _bbdd.ObtenerVentas();
        }

    }
}
