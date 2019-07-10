using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    /// Lógica de interacción para W_Reporte.xaml
    /// </summary>
    public partial class W_Reporte : Window
    {

       
        public W_Reporte()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CrystalReport1 CR = new CrystalReport1();
            CR.Load(@"CrystalReport1.rep");
            CrystalReportViewer1.ViewerCore.ReportSource = CR;

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //CrystalReport1 cryRpt = new CrystalReport1();

            //cryRpt.Load(@"C:\Users\J\Source\Repos\TPNomina\TPNomina\TPNomina\CrystalReport1.rpt");



            //ParameterFieldDefinitions crParameterFieldDefinitions;

            //ParameterFieldDefinition crParameterFieldDefinition;

            //ParameterValues crParameterValues = new ParameterValues();

            //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();



            //crParameterDiscreteValue.Value = txtMes.Text;

            //crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;

            ////crParameterFieldDefinition = crParameterFieldDefinitions["Mes"];
            ////crParameterFieldDefinition = crParameterFieldDefinitions["Anho"];
            //crParameterFieldDefinition = crParameterFieldDefinitions["Anho"];

            //crParameterValues = crParameterFieldDefinition.CurrentValues;



            //crParameterValues.Clear();

            //crParameterValues.Add(crParameterDiscreteValue);

            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //cryRpt.Refresh();

            //CrystalReportViewer1.ViewerCore.ReportSource = cryRpt;


            ////CrystalReportViewer1.ViewerCore.RefreshReport(); 
            ///




            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(@"C:\Users\J\Source\Repos\TPNomina\TPNomina\TPNomina\CrystalReport1.rpt");

            //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            //ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //Tables CrTables;

            //ParameterFieldDefinitions crParameterFieldDefinitions;
            //ParameterFieldDefinition crParameterFieldDefinition;
            //ParameterValues crParameterValues = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            //crParameterDiscreteValue.Value = txtMes.Text;
            //crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["Mes"];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();
            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //crParameterDiscreteValue.Value = txtAnho.Text;
            //crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["Anho"];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //crConnectionInfo.ServerName = @"LAPTOP-7FI8GS06\SQLEXPRESS";
            //crConnectionInfo.DatabaseName = "Nomina";
            //crConnectionInfo.UserID = "Sa";
            //crConnectionInfo.Password = "j321";

            //CrTables = cryRpt.Database.Tables;
            //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            //{
            //    crtableLogoninfo = CrTable.LogOnInfo;
            //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
            //}

            //CrystalReportViewer1.ViewerCore.ReportSource = cryRpt;
            //CrystalReportViewer1.RefreshReport();
            //cryRpt.Refresh();
            //CrystalReportViewer1.();


        }
    
    }
}
