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
    /// Interaction logic for w_Detalle_Concepto.xaml
    /// </summary>
    public partial class w_Detalle_Concepto : Window
    {
        ConexionBD Datos;
        public w_Detalle_Concepto()
        {
            InitializeComponent();
            Datos = new ConexionBD();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboLiquidacion.ItemsSource = Datos.Liquidacion_Mensual.ToList();
            cboLiquidacion.DisplayMemberPath = "Mes";
            cboLiquidacion.SelectedValuePath = "Id_Liquidacion";

            cboConcepto.ItemsSource = Datos.Concepto.ToList();
            cboConcepto.DisplayMemberPath = "Descripcion";
            cboConcepto.SelectedValuePath = "Id_Concepto";
            


            cboEmpleado.ItemsSource = Datos.Empleado.ToList();
            cboEmpleado.DisplayMemberPath = "Nombres";
            cboEmpleado.SelectedValuePath = "Id_Empleado";

        }

        private void CargarDatosGrilla()
        {
            try
            {
                dgConcepto.ItemsSource = Datos.Liquidacion_Mensual_Detalle.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregarConcepto_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                Liquidacion_Mensual_Detalle LMD = new Liquidacion_Mensual_Detalle();
                //FALTA VALIDAR MONTO > 0, MOSTRAR EN TIPO SI ES POSITIVO O NEGATIVO
                //VALIDAR EN MONTO QUE SI ES NEGATIVO MULTIPLICAR POR -1
                //SUMAR LOS CONCEPTOS EN UNA VARIABLE PARA 
                //SUMAR O RESTAR AL MONTO DE LIQUIDACION FINAL 
                //AFKSGGDKS T_T

                
            
       
            if (txtMonto.Text  != " ")
                { 
                    if (cboConcepto.SelectedItem != null)
                    {
                        if (cboEmpleado.SelectedItem != null)
                        {
                            if(cboLiquidacion.SelectedItem != null)
                            {
                                Liquidacion_Mensual varEst = (Liquidacion_Mensual)cboLiquidacion.SelectedItem;
                                /*
                                 REVISAR
                                 */
                                //Por alguna razón trae null, tal vez no consulta con la base de datos
                                if (varEst.Estado != "A")//Estado=NULL
                                {
                                    MessageBox.Show("El estado de la Liquidacion debe ser Activo");
                                }else
                                {
                                    LMD.Liquidacion_Id = int.Parse(cboLiquidacion.SelectedItem);
                                    LMD.Empleado = (Empleado)cboEmpleado.SelectedItem;
                                    LMD.Concepto = (Concepto)cboConcepto.SelectedItem;
                                    LMD.Monto = int.Parse(txtMonto.Text);

                                    Datos.Liquidacion_Mensual_Detalle.Add(LMD);
                                    Datos.SaveChanges();
                                    CargarDatosGrilla();
                                }
                                
                            }else
                            {
                                MessageBox.Show("Falta Campos");
                            }
                        }else
                        {
                            MessageBox.Show("Falta Campos");
                        }
                    }else
                    {
                        MessageBox.Show("Falta Campos");
                    }
                    
                }else
                {
                    MessageBox.Show("Falta Campos");
                }

            //}catch
            //{

            //    MessageBox.Show("Error, Algo salió mal xDDDD");

            //}

        }

        private void btnEliminarConcepto_Click(object sender, RoutedEventArgs e)
        {
            if (dgConcepto.SelectedItem != null)
            {
                Liquidacion_Mensual_Detalle DML = (Liquidacion_Mensual_Detalle)dgConcepto.SelectedItem;            
                Datos.Liquidacion_Mensual_Detalle.Remove(DML);
                Datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Concepto de la grilla para eliminar!");
        }

    }
}
