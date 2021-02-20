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
                new KeyGesture(Key.E,ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand ModificarSala = new RoutedUICommand(
            "ModificarSala",
            "ModificarSala",
            typeof(CustomCommands),
            new InputGestureCollection
            {
                new KeyGesture(Key.S,ModifierKeys.Control)
            }
            );

    }
}
