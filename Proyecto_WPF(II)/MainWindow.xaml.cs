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

        private void AñadirSala_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_vm.ComprobarNumSala(numeroSala_TextBlock.Text))
            {
                MessageBox.Show("¡EL NÚMERO DE SALA YA EXISTE!","ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
            }else _vm.AñadirSala();

        }

        private void AñadirSala_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.SalaFormOk();
        }

        private void ModificarSala_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_vm.ComprobarNumSala(numeroSala_TextBlock.Text))
            {
                MessageBox.Show("¡EL NÚMERO DE SALA YA EXISTE!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else _vm.ModificarSala();
        }

        private void ModificarSala_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HayPersonaSeleccionada();
        }
    }
}
