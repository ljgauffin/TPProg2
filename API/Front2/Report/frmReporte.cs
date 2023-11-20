using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fabrica.datos;
using Fabrica.Datos;
using Fabrica.Dominio;




namespace Front2.Report
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.DataTable1' Puede moverla o quitarla según sea necesario.
           
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<Parametro> parametros = new List<Parametro>();
            string sp = "SP_REPORTE";
            parametros.Add(new Parametro("@desde", dtpDesde.Value));
            parametros.Add(new Parametro("@hasta", dtpHasta.Value));
           


            DataTable tabla = DBHelper.GetInstancia().Consultar(sp, parametros);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", tabla));
            this.reportViewer1.RefreshReport();



        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
