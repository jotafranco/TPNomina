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
            //cboEmpleado.ItemsSource = Datos.Empleado.ToList();
            //cboEmpleado.DisplayMemberPath = "Nombres";
            //cboEmpleado.SelectedValuePath = "Id_Empleado";
            //if (cboEmpleado.SelectedItem != null)
            //{
                 
            //}
            CargarDatosGrilla();
        }

        private void CargarDatosGrilla()
        {
            dgSalario.ItemsSource = Datos.Empleado.ToList();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            int salarioAnterior;
            Empleado EmpleadoSeleccionada = (Empleado)dgSalario.SelectedItem;
            Empleado_Salario_Historico empSalarioHistorico = new Empleado_Salario_Historico();
            try { 
                if (dgSalario.SelectedItem != null)
                {
                    salarioAnterior = int.Parse(txtSalarioAnterior.Text);
                //Salario Actual del Empleado
                    EmpleadoSeleccionada.Salario_Basico = int.Parse(txtSalario.Text);

                //Histórico de salarios
                    empSalarioHistorico.Empleado_Id = EmpleadoSeleccionada.Id_Empleado;
                    empSalarioHistorico.Salario_Basico_Anterior = salarioAnterior;
                    empSalarioHistorico.Salario_Basico_Nuevo = int.Parse(txtSalario.Text);
                    empSalarioHistorico.Fecha_Hora = DateTime.Now;
                    empSalarioHistorico.Usuario_Id = int.Parse(Global.user);
                    //Falta guardar el Usuario para que no genero conflicto, al eliminar o mejor comentar el try catch se puede ver el error
                //empSalarioHistorico.Usuario_Id = 

                    Datos.Entry(EmpleadoSeleccionada).State = System.Data.Entity.EntityState.Modified;
                    Datos.Empleado_Salario_Historico.Add(empSalarioHistorico);
                    Datos.SaveChanges();
                    CargarDatosGrilla();

                    MessageBox.Show("Datos guardados :)");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar primeramente la persona a modificar ");
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void DgSalario_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Muestra los datos de la tabla de Empleados
             if(dgSalario.SelectedItem != null)
            {
                Empleado emp = (Empleado)dgSalario.SelectedItem;
                txtEmpleado.Text = emp.Nombres;
                txtSalarioAnterior.Text = emp.Salario_Basico.ToString();
            }
        }
        
    }
}
