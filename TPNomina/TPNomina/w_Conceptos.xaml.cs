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
    /// Lógica de interacción para w_Conceptos.xaml
    /// </summary>
    public partial class w_Conceptos : Window
    {
        ConexionBD datos;
        public w_Conceptos()
        {
            InitializeComponent();

            datos = new ConexionBD();
        }

        private void LimpiarDatos()
        {

           txtDescripcion_Concepto.Text = string.Empty;
           txtTipo_Concepto.Text = string.Empty;

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                Concepto con = new Concepto();
                con.Descripcion = txtDescripcion_Concepto.Text;
                con.Tipo = txtTipo_Concepto.Text;


                if (txtDescripcion_Concepto.Text !=""  )
                {
                    if (txtTipo_Concepto.Text != "")
                    {
                        datos.Concepto.Add(con);
                        datos.SaveChanges();
                        MessageBox.Show("Concepto Guardado");
                        LimpiarDatos();
                    }
                    else

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

                MessageBox.Show("LLena todos los campos plis ");

            }



        }

        

            private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
