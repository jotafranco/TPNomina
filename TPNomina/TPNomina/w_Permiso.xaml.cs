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
    /// Lógica de interacción para w_Permiso.xaml
    /// </summary>
    public partial class w_Permiso : Window
    {
        ConexionBD datos;

        public w_Permiso()
        {
            InitializeComponent();
            datos = new ConexionBD();
        }


        private void CargarDatosGrilla()
        {
            try
            {
                //Con una sola linea de código, cargamos la grilla con las Artesanias
                dgPermisos.ItemsSource = datos.Permisos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void btnAprobar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPermisos.SelectedItem != null)
            {
                Permisos P = (Permisos)dgPermisos.SelectedItem;


                if (P.Estado.Equals("Pendiente"))
                    P.Estado = "Aprobado";
                else
                    MessageBox.Show("La operacion no es valida");


                Datos.Entry(P).State = System.Data.Entity.EntityState.Modified;
                Datos.SaveChanges();
                CargarDatosGrilla();

            }

        }

        private void btnRechazar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPermisos.SelectedItem != null)
            {
                Permisos A = (Permisos)dgPermisos.SelectedItem;


                if (A.Estado.Equals("Pendiente"))
                    A.Estado = "Rechazado";
                else
                    MessageBox.Show("La operacion no es valida");


                Datos.Entry(P).State = System.Data.Entity.EntityState.Modified;
                Datos.SaveChanges();
                CargarDatosGrilla();
            }
        }
    }
}
