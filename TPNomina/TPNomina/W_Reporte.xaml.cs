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
    }
}
