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
    /// Lógica de interacción para w_MenuPrincipal.xaml
    /// </summary>
    public partial class w_MenuPrincipal : Window
    {
        public w_MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuAnticipo_Click(object sender, RoutedEventArgs e)
        {
            W_Anticipo ventanaAnticipo = new W_Anticipo();
            ventanaAnticipo.ShowDialog();

             
        }

        private void MenuConcepto_Click(object sender, RoutedEventArgs e)
        {
            w_Conceptos ventanaConcepto = new w_Conceptos();
            ventanaConcepto.ShowDialog();

        }

        private void MenuEmpleado_Click(object sender, RoutedEventArgs e)
        {
            w_Registrar_Empleado ventanaEmpleado = new w_Registrar_Empleado();
            ventanaEmpleado.ShowDialog();

        }

        private void MenuPermiso_Click(object sender, RoutedEventArgs e)
        {
             w_Permiso ventanaPermiso = new w_Permiso();
            ventanaPermiso.ShowDialog();

        }

        private void MenuTurno_Click(object sender, RoutedEventArgs e)
        {
            Turno ventanaTurno= new Turno();
            ventanaTurno.ShowDialog();

        }

        private void MenuSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
