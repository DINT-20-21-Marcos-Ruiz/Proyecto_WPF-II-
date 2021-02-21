using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_WPF_II_
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM _vm;
        public MainWindow()
        {
            _vm = new MainWindowVM();
            InitializeComponent();
            DataContext = _vm;
        }

        //SALA ----------------------------------------------------------------------------->
        private void AñadirSala_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AñadirSala();

        }

        private void ModificarSala_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModificarSala();
        }

        private void ModificarSala_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HaySalaSeleccionada();
        }

        private void GuardarSala_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_vm.ComprobarNumSala(numeroSala_TextBlock.Text))
            {
                MessageBox.Show("LA SALA NO ESTÁ DISPONIBLE", "AVISO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else _vm.GuardarCambioSala();
        }
            
        private void GuardarSala_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.SalaFormOk();
        }

        //SESION ----------------------------------------------------------------------------->
        private void ModificarSesion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModificarSesion();
        }

        private void ModificarSesion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HaySesionSeleccionada();
        }

        private void AñadirSesion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AñadirSesion();
        }

        private void EliminarSesion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.EliminarSesion();
        }

        private void EliminarSesion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HaySesionSeleccionada();
        }

        private void GuardarSesion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_vm.SalasDisponibles(salaSesion_TextBlock.Text) && !_vm.MaxSesionesAsociadas(salaSesion_TextBlock.Text))
            {     
                _vm.GuardarCambioSesion();
            }
            else MessageBox.Show("¡EL NÚMERO DE SALA YA EXISTE!", "AVISO", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void GuardarSesion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.SesionFormOk();
        }

    }
}
