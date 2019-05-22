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
    /// Lógica de interacción para w_Inicio_Sesion.xaml
    /// </summary>
    public partial class w_Inicio_Sesion : Window
    {
        ConexionBD datos;
        public w_Inicio_Sesion()
        {
            InitializeComponent();

            datos = new ConexionBD();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            
        }
        
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboUsuario.ItemsSource = datos.Usuario.ToList();
            cboUsuario.DisplayMemberPath = "Usuario1";
            cboUsuario.SelectedValuePath = "Id_Usuario";

        }
    }
}

