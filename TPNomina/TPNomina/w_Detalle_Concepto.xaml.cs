﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            calculo();

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

        private void calculo()
        {
            try
            {

                // Empleado.Salario_Basico + Concepto 

                //Empleado e = (Empleado)cboEmpleado.SelectedItem;
                //Liquidacion_Mensual l = (Liquidacion_Mensual)cboLiquidacion.SelectedItem;

                //var totalIngresos  = Empleado.Salario_Basico + Concepto
                
                int id_Emp;

                using (SqlConnection ConexionSQLServer = new SqlConnection("Server=LAPTOP-7FI8GS06\\SQLEXPRESS;Database=Nomina;User ID=sa;Password=j321;Trusted_Connection=False;"))
                {
                    using (SqlCommand cmdSQL = new SqlCommand("select * from Empleado", (SqlConnection)ConexionSQLServer))
                    {
                        if (ConexionSQLServer.State != ConnectionState.Open)
                        {
                            ConexionSQLServer.Open();
                        }

                        SqlDataReader elDataReader = cmdSQL.ExecuteReader();

                        while (elDataReader.Read())
                        {
                            id_Emp = (int)elDataReader["Id_Empleado"];
                            
                            CalculoSalario(id_Emp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculoSalario(int id_Emp)
        {
            try
            {

                List<Liquidacion_Mensual_Detalle> listasal = new List<Liquidacion_Mensual_Detalle>();
                listasal = Datos.Liquidacion_Mensual_Detalle.ToList();

                var liqPos = from c in listasal
                             where c.Empleado.Id_Empleado == id_Emp && c.Monto > 0
                             select c;

            }
            catch(Exception ex)
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
                                if (Convert.ToInt64(txtMonto.Text) <= 0)
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

                MessageBox.Show("Error, revise los datos que selecciona");

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
            if (concepto.Descripcion == "Ips")
            {
                //Valida pero no podemos limpiar el combox y se queda seleccionado IPS QUE CAGADA
                MessageBox.Show("Ips es un concepto que se c;alculo automáticamente...NO SE PUEDE SELECCIONAR");
            }
            else
            {
                txtTipo.Text = concepto.Tipo;
            }
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