using Microsoft.Win32;
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
    /// Lógica de interacción para w_Registrar_Empleado.xaml
    /// </summary>
    public partial class w_Registrar_Empleado : Window
    {
        ConexionBD datos;
        public w_Registrar_Empleado()
        {
            InitializeComponent();
            datos = new ConexionBD();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Instaciar el objeto de la clase Empleado
            Empleado emp = new Empleado();

            emp.Nombres = txtNombre.Text;
            emp.Apellidos = txtApellido.Text;
            emp.Nro_Documento = txtDocumento.Text;
            emp.Direccion = txtDireccion.Text;
            emp.Nro_Telefono = txtTelefono.Text;
           // emp.Fecha_Nacimiento = dtpFechaNacimiento.SelectedDate;
            emp.Fecha_Incorporacion = dtpFechaIncorporacion.SelectedDate;
            emp.Imagen_Perfil = foto.Source.ToString();

            //Guardamos los datos ingresados
            datos.Empleado.Add(emp);
            datos.SaveChanges();

        }

        private void BtnImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Elegir una imagen";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                foto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
