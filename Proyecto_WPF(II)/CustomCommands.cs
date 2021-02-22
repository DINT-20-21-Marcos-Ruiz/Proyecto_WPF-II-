using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_WPF_II_
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand AñadirSala = new RoutedUICommand(
            "AñadirSala",
            "AñadirSala",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );
        public static readonly RoutedUICommand ModificarSala = new RoutedUICommand(
            "ModificarSala",
            "ModificarSala",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );
        public static readonly RoutedUICommand GuardarSala = new RoutedUICommand(
            "GuardarSala",
            "GuardarSala",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );
        public static readonly RoutedUICommand ModificarSesion = new RoutedUICommand(
            "ModificarSesion",
            "ModificarSesion",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );
        public static readonly RoutedUICommand AñadirSesion = new RoutedUICommand(
            "AñadirSesion",
            "AñadirSesion",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );
        public static readonly RoutedUICommand EliminarSesion = new RoutedUICommand(
            "EliminarSesion",
            "EliminarSesion",
            typeof(CustomCommands),
            new InputGestureCollection
            {      
            }
            );
        public static readonly RoutedUICommand GuardarSesion = new RoutedUICommand(
            "GuardarSesion",
            "GuardarSesion",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );
        public static readonly RoutedUICommand AñadirEntradas = new RoutedUICommand(
            "AñadirEntradas",
            "AñadirEntradas",
            typeof(CustomCommands),
            new InputGestureCollection
            {
            }
            );


    }
}
