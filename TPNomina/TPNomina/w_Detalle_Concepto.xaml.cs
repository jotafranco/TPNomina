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
        //    cboLiquidacion.DisplayMemberPath = "Mes";
            cboLiquidacion.SelectedValuePath = "Id_Liquidacion";

            cboConcepto.ItemsSource = Datos.Concepto.ToList();
            cboConcepto.DisplayMemberPath = "Descripcion";
            cboConcepto.SelectedValuePath = "Id_Concepto";



            cboEmpleado.ItemsSource = Datos.Empleado.ToList();
            cboEmpleado.DisplayMemberPath = "Nombres";
            cboEmpleado.SelectedValuePath = "Id_Empleado";
            CargarDatosGrilla();

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
            try
            {
                Liquidacion_Mensual_Detalle LMD = new Liquidacion_Mensual_Detalle();
                
                //SUMAR LOS CONCEPTOS EN UNA VARIABLE PARA 
                //SUMAR O RESTAR AL MONTO DE LIQUIDACION FINAL 
                //AFKSGGDKS T_T

                if (txtMonto.Text != " ")
                {
                    if (cboConcepto.SelectedItem != null)
                    {
                        if (cboEmpleado.SelectedItem != null)
                        {
                            if (cboLiquidacion.SelectedItem != null)
                            {
                                Liquidacion_Mensual varEst = (Liquidacion_Mensual)cboLiquidacion.SelectedItem;
                                if (Convert.ToInt16(txtMonto.Text) <= 0)
                                {
                                    MessageBox.Show("El monto debe ser mayor a 0");
                                }
                                else
                                {
                                    if (varEst.Estado != "A")
                                    {
                                        MessageBox.Show("El estado de la Liquidacion debe ser Activo");
                                    }
                                    else
                                    {
                                        Concepto concepto = (Concepto)cboConcepto.SelectedItem;
                                        LMD.Liquidacion_Id = varEst.Id_Liquidacion;
                                        LMD.Empleado = (Empleado)cboEmpleado.SelectedItem;
                                        LMD.Concepto = (Concepto)cboConcepto.SelectedItem;

                                        if (concepto.Tipo == "Negativo")
                                        {
                                            LMD.Monto = ((int.Parse(txtMonto.Text)) * -1);

                                        }
                                        else
                                        {
                                            LMD.Monto = int.Parse(txtMonto.Text);
                                        }

                                        Datos.Liquidacion_Mensual_Detalle.Add(LMD);
                                        Datos.SaveChanges();
                                        CargarDatosGrilla();
                                        LimpiarDatos();
                                        MessageBox.Show("Datos guardados");
                                    }
                                }

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

                MessageBox.Show("Error, tal vez la liquidación y el empleado son iguales");

            }


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

        private void cboConcepto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Concepto concepto = (Concepto)cboConcepto.SelectedItem;
            txtTipo.Text = concepto.Tipo;

        }

        private void LimpiarDatos()
        {
            //cboConcepto.SelectedValue = null; //ERROR AL LLAMAR EL MÉTODO EN ESTA LINEA
            cboEmpleado.SelectedValue = null;
            cboLiquidacion.SelectedValue = null;
            txtMonto.Text = string.Empty;
            txtTipo.Text = string.Empty;
            
        }



    }
}