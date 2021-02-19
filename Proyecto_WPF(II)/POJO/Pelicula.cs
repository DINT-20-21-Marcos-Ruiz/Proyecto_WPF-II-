using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_.Clases
{
    class Pelicula : INotifyPropertyChanged
    {
        public  int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Cartel { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public string Calificacion { get; set; }

        public Pelicula()
        {

        }

        public Pelicula(int idPelicula, string titulo, string cartel, int año, string genero, string calificacion)
        {
            IdPelicula = idPelicula;
            Titulo = titulo;
            Cartel = cartel;
            Año = año;
            Genero = genero;
            Calificacion = calificacion;
        }

        public event PropertyChangedEventHandler PropertyChanged;

 
    }
}
