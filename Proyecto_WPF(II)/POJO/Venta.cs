using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_.POJO
{
    public class Venta : INotifyPropertyChanged
    {
        public int IdVenta { get; set; }
        public int Sesion { get; set; }
        public int Cantidad { get; set; }
        public string Pago { get; set; }

        public Venta()
        {

        }

        public Venta(int idVenta, int sesion, int cantidad, string pago)
        {
            IdVenta = idVenta;
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = pago;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
