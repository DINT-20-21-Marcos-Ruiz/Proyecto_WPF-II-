using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_.POJO
{
    public class Sala : INotifyPropertyChanged
    {
        public int IdSala { get; set; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }
        public Boolean Disponible { get; set; }

        public Sala()
        {
            Numero = "";
            Capacidad = 0;
            Disponible = true;
        }
        public Sala(int idSala, string numero, int capacidad, bool disponible)
        {
            IdSala = idSala;
            Numero = numero;
            Capacidad = capacidad;
            Disponible = disponible;
        }

        public Sala(Sala salaSeleccionada)
        {
            IdSala = salaSeleccionada.IdSala;
            Numero = salaSeleccionada.Numero;
            Capacidad = salaSeleccionada.Capacidad;
            Disponible = salaSeleccionada.Disponible;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
