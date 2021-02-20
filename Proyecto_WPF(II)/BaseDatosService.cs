using Microsoft.Data.Sqlite;
using Proyecto_WPF_II_.POJO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _conexion = new SqliteConnection("Data Source=cine.db");
            CrearTablas();
        }

        private void CrearTablas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS peliculas (idPelicula INTEGER PRIMARY KEY,
                                    titulo TEXT,cartel TEXT,año INTEGER,genero TEXT,calificacion TEXT)";
            _comando.ExecuteNonQuery();

            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS salas (idSala INTEGER PRIMARY KEY AUTOINCREMENT,
                                    numero TEXT,capacidad  INTEGER,disponible BOOLEAN DEFAULT (true))";
            _comando.ExecuteNonQuery();

            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS sesiones (idSesion INTEGER PRIMARY KEY AUTOINCREMENT,
                                    pelicula INTEGER REFERENCES peliculas (idPelicula),
                                    sala INTEGER REFERENCES salas (idSala),hora TEXT)";
            _comando.ExecuteNonQuery();

            _comando.CommandText = @"CREATE TABLE IF NOT EXISTS ventas (idVenta  INTEGER PRIMARY KEY AUTOINCREMENT,
                                    sesion   INTEGER REFERENCES sesiones (idSesion),cantidad INTEGER,pago TEXT)";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        //PELÍCULAS
        public void InsertarPelicula(Pelicula pelicula)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO peliculas VALUES (@idPelicula,@titulo,@cartel,@año,@genero,@calificacion)";
            _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
            _comando.Parameters.Add("@titulo", SqliteType.Text);
            _comando.Parameters.Add("@cartel", SqliteType.Text);
            _comando.Parameters.Add("@año", SqliteType.Integer);
            _comando.Parameters.Add("@genero", SqliteType.Text);
            _comando.Parameters.Add("@calificacion", SqliteType.Text);
            _comando.Parameters["@idPelicula"].Value = pelicula.IdPelicula;
            _comando.Parameters["@titulo"].Value = pelicula.Titulo;
            _comando.Parameters["@cartel"].Value = pelicula.Cartel;
            _comando.Parameters["@año"].Value = pelicula.Año;
            _comando.Parameters["@genero"].Value = pelicula.Genero;
            _comando.Parameters["@calificacion"].Value = pelicula.Calificacion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }


        //SESIONES
        public void DeleteSesion(Sesion sesionSeleccionada)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM sesiones WHERE idSesion=@idSesion";
            _comando.Parameters.Add("@idSesion",SqliteType.Integer);
            _comando.Parameters["@idSesion"].Value = sesionSeleccionada.IdSesion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void InsertarSesion(Sesion sesionFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO sesiones VALUES (@pelicula,@sala,@hora)";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesionFormulario.Pelicula;
            _comando.Parameters["@sala"].Value = sesionFormulario.Sala;
            _comando.Parameters["@hora"].Value = sesionFormulario.Hora;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void ModificarSesion(Sesion sesionFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE sesiones SET pelicula=@pelicula,sala=@sala,hora=@hora WHERE idSesion=@idSesion";
            _comando.Parameters.Add("@idSesion", SqliteType.Integer);
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@idSesion"].Value = sesionFormulario.IdSesion;
            _comando.Parameters["@pelicula"].Value = sesionFormulario.Pelicula;
            _comando.Parameters["@sala"].Value = sesionFormulario.Sala;
            _comando.Parameters["@hora"].Value = sesionFormulario.Hora;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public ObservableCollection<Sesion> ObtenerSesiones()
        {
            ObservableCollection<Sesion> resultado = new ObservableCollection<Sesion>();
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            _comando.CommandText = "SELECT * FROM sesiones";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSesion = lector.GetInt32(0);
                    int pelicula = lector.GetInt32(1);
                    int sala = lector.GetInt32(2);
                    string hora = lector.GetString(3);
                    resultado.Add(new Sesion(idSesion, pelicula, sala, hora));
                }
            }
            lector.Close();
            _conexion.Close();

            return resultado;
        }

        //SALAS
        public void InsertarSala(Sala salaFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO salas VALUES(@numero,@capacidad,@disponible)";
            _comando.Parameters.Add("@numero", SqliteType.Text);
            _comando.Parameters.Add("@capacidad", SqliteType.Integer);
            _comando.Parameters.Add("@disponible", SqliteType.Integer);
            _comando.Parameters["@numero"].Value = salaFormulario.Numero;
            _comando.Parameters["@capacidad"].Value = salaFormulario.Capacidad;
            _comando.Parameters["@disponible"].Value = salaFormulario.Disponible;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void ModificarSala(Sala salaFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE salas SET numero=@numero,capacidad=@capacidad,disponible=@disponible WHERE idSala=@idSala";
            _comando.Parameters.Add("@idSala", SqliteType.Integer);
            _comando.Parameters.Add("@numero", SqliteType.Text);
            _comando.Parameters.Add("@capacidad", SqliteType.Integer);
            _comando.Parameters.Add("@disponible", SqliteType.Integer);
            _comando.Parameters["@idSala"].Value = salaFormulario.IdSala;
            _comando.Parameters["@numero"].Value = salaFormulario.Numero;
            _comando.Parameters["@capacidad"].Value = salaFormulario.Capacidad;
            _comando.Parameters["@disponible"].Value = salaFormulario.Disponible;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }
        public ObservableCollection<Sala> ObtenerSalas()
        {
            ObservableCollection<Sala> resultado = new ObservableCollection<Sala>();
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            _comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSala = lector.GetInt32(0);
                    string numero = lector.GetString(1);
                    int capacidad = lector.GetInt32(2);
                    Boolean disponible = lector.GetBoolean(3);
                    resultado.Add(new Sala(idSala, numero, capacidad, disponible));
                }
            }
            lector.Close();
            _conexion.Close();

            return resultado;
        }
        public Boolean ComprobarNumeroSalas(string numeroSala)
        {
            Boolean existe = false;
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            _comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    if (lector.GetString(1) == numeroSala) existe = true;
                }
            }
            lector.Close();
            _conexion.Close();

            return existe;
        }

        //VENTAS
        public void InsertarVenta(Venta ventaFormulario)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO ventas VALUES (@sesion,@cantidad,@pago)";
            _comando.Parameters.Add("@sesion", SqliteType.Integer);
            _comando.Parameters.Add("@cantidad", SqliteType.Integer);
            _comando.Parameters.Add("@pago", SqliteType.Text);
            _comando.Parameters["@sesion"].Value = ventaFormulario.Sesion;
            _comando.Parameters["@cantidad"].Value = ventaFormulario.Cantidad;
            _comando.Parameters["@pago"].Value = ventaFormulario.Pago;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }


    }
}
