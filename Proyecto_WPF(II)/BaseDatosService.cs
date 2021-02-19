using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF_II_
{
    public class BaseDatosService
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;
        public BaseDatosService()
        {
            //_conexion = new SqliteConnection("Data");
        }
    }
}
