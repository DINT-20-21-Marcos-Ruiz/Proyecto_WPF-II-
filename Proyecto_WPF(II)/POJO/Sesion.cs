using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_.POJO
{
    public class Sesion : INotifyPropertyChanged
    {
        public int IdSesion { get; set; }
        public int Pelicula { get; set; }
        public int Sala { get; set; }
        public string Hora { get; set; }

        public Sesion()
        {

        }

        public Sesion(int idSesion, int pelicula, int sala, string hora)
        {
            IdSesion = idSesion;
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
