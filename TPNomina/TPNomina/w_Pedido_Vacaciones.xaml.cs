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

        private void btnAprobar_Click(object sender, RoutedEventArgs e)
        {

            if (dgVacaciones.SelectedItem != null)
            {
                Vacaciones V = (Vacaciones)dgVacaciones.SelectedItem;


                if (V.Estado.Equals("Pendiente"))
                    V.Estado = "Aprobado";
                else
                    MessageBox.Show("La operacion no es valida");


                Datos.Entry(V).State = System.Data.Entity.EntityState.Modified;
                Datos.SaveChanges();
                cargarGrillaVacaciones();

            }

        }

        private void btnRechazar_Click(object sender, RoutedEventArgs e)
        {
            if (dgVacaciones.SelectedItem != null)
            {
                Vacaciones V = (Vacaciones)dgVacaciones.SelectedItem;


                if (V.Estado.Equals("Pendiente"))
                    V.Estado = "Rechazado";
                else
                    MessageBox.Show("La operacion no es valida");


                Datos.Entry(V).State = System.Data.Entity.EntityState.Modified;
                Datos.SaveChanges();
                cargarGrillaVacaciones();

            }
        }
    }
}
