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

        

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboUsuario.ItemsSource = datos.Usuario.ToList();
            cboUsuario.DisplayMemberPath = "Usuario1";
            cboUsuario.SelectedValuePath = "Id_Usuario";

        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            PassBox.Clear();
            cboUsuario.SelectedIndex = -1;
        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = (from u in datos.Usuario
                            where (cboUsuario.Text == u.Usuario1 && u.Password == PassBox.Password)
                            select u).ToList();
            MessageBox.Show("Inicio correcto");

            if (usuarios.Count() == 0)
            {
                MessageBox.Show("Contraseña incorrecta");
            }
            else
            {
                w_MenuPrincipal ventanaMenu = new w_MenuPrincipal();
                ventanaMenu.ShowDialog();
                MessageBox.Show("Adiositoooo!!!");
            }
        }
    }
}

