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
    /// Lógica de interacción para w_SalararioHistorico.xaml
    /// </summary>
    public partial class w_SalararioHistorico : Window
    {
        ConexionBD Datos;
        public w_SalararioHistorico()
        {
            InitializeComponent();
            Datos = new ConexionBD();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboEmpleado.ItemsSource = Datos.Empleado.ToList();
            cboEmpleado.DisplayMemberPath = "Nombres";
            cboEmpleado.SelectedValuePath = "Id_Empleado";
            if (cboEmpleado.SelectedItem != null)
            {

                Empleado salario = new Empleado();


                //salario.Salario_Basico = Convert.ToInt32(txtSalarioAnterior.Text);
                //txtSalarioAnterior.Text = cboEmpleado.SelectedItem.ToString();
                   
            }
            CargarDatosGrilla();
        }

        private void CargarDatosGrilla()
        {
            dgSalario.ItemsSource = Datos.Empleado_Salario_Historico.ToList();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (dgSalario.SelectedItem != null)
            {
                Empleado EmpleadoSeleccionada = (Empleado)dgSalario.SelectedItem;
                EmpleadoSeleccionada.Salario_Basico = Convert.ToInt32(txtSalarioAnterior.Text);
                EmpleadoSeleccionada =  (Empleado)cboEmpleado.SelectedItem;


                Empleado_Salario_Historico ESHSeleccionada = (Empleado_Salario_Historico)dgSalario.SelectedItem;
                ESHSeleccionada.Salario_Basico_Nuevo = Convert.ToInt32(txtSalario.Text);
                ESHSeleccionada.Fecha_Hora = DateTime.Now;
                EmpleadoSeleccionada.Salario_Basico = Convert.ToInt32(txtSalario.Text);

                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar primeramente la persona a modificar ");
        }

        private void DgSalario_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             
        }
    }
}
