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
    /// Lógica de interacción para Turno.xaml
    /// </summary>
    public partial class w_Turno : Window
    {
        ConexionBD datos;
        public w_Turno()
        {
            InitializeComponent();

            datos = new ConexionBD();
        }

        private void LimpiarDatos()
        {
            
            txtHoraEnt.Text = string.Empty;
            txtHoraSal.Text = string.Empty;
            txtObservacion.Text = string.Empty;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                    Turno tur = new Turno();
                    tur.Hora_Entrada = txtHoraEnt.Text;
                    tur.Hora_Salida = txtHoraSal.Text;
                    tur.Observaciones = txtObservacion.Text;

                if (txtHoraEnt.Text != "")
                {
                    if (txtHoraSal.Text != "")
                    {
                        if (txtObservacion.Text != "")
                        {
                            datos.Turno.Add(tur);
                            datos.SaveChanges();
                            MessageBox.Show("Turno Guardado con éxito¡¡¡");
                            LimpiarDatos();
                        }
                        else

                        {
                            MessageBox.Show("Falta Campos");
                        }
                    } else

                    {
                        MessageBox.Show("Falta Campos");
                    }
                }
                else

                    {
                        MessageBox.Show("Falta Campos");
                    }
            }

            catch
            {

                MessageBox.Show("Completa todo -.- ");

            }

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
