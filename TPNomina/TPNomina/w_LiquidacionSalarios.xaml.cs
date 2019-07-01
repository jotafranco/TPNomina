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
    /// Lógica de interacción para w_LiquidacionSalarios.xaml
    /// </summary>
    public partial class w_LiquidacionSalarios : Window
    {
        ConexionBD Datos;
        public w_LiquidacionSalarios()
        {

            InitializeComponent();
            Datos = new ConexionBD();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Liquidacion_Mensual LM = new Liquidacion_Mensual();
                LM.Mes = Convert.ToInt16(txtMes.Text);
                LM.Anho = Convert.ToInt16(txtAño.Text);
                LM.Fecha_Generacion = DateTime.Now;
                LM.Usuario_Id= int.Parse(Global.user);
                LM.Estado = "A";

                if (txtMes.Text != "")
                {
                    if (txtAño.Text != "")
                    {
                        Datos.Liquidacion_Mensual.Add(LM);
                        Datos.SaveChanges();
                        MessageBox.Show("Liquidacion Guardada");
                        
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

        
    }
}
