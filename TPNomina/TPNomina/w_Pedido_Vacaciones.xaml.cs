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
using System.Windows.Shapes;

namespace TPNomina
{
    /// <summary>
    /// Lógica de interacción para w_Pedido_Vacaciones.xaml
    /// </summary>
    public partial class w_Pedido_Vacaciones : Window
    {
        ConexionBD Datos;
        public w_Pedido_Vacaciones()
        {
            InitializeComponent();
            Datos = new ConexionBD();
        }

        private void cargarGrillaVacaciones()
        {
            dgVacaciones.ItemsSource = Datos.Vacaciones.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrillaVacaciones();
        }
    }
}
