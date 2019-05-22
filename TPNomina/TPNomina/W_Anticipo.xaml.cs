﻿using System;
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
    /// Lógica de interacción para W_Anticipo.xaml
    /// </summary>
    public partial class W_Anticipo : Window
    {
        ConexionBD Datos;
        public W_Anticipo()
        {
            InitializeComponent();
            Datos = new ConexionBD();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                //Con una sola linea de código, cargamos la grilla con las Artesanias
                dgAnticipos.ItemsSource = Datos.Anticipo.ToList();
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
    }
}
