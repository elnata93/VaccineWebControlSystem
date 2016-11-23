using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BLL;

namespace VaccineWebControlSystem.Reportes
{
    public partial class VaccineReportViewer : System.Web.UI.Page
    {
        public string reporte { get; set; }
        public DataTable data { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuariosreportViewer.LocalReport.DataSources.Clear();
                UsuariosreportViewer.ProcessingMode = ProcessingMode.Local;

                UsuariosreportViewer.LocalReport.ReportPath = @"Reportes\UsuariosReport.rdlc";

                ReportDataSource source = new ReportDataSource("Usuarios", Usuarios.ListadoUs("1=1"));

                UsuariosreportViewer.LocalReport.DataSources.Add(source);

                UsuariosreportViewer.LocalReport.Refresh();

                //this.reportViewer1.Reset();
                //this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                //this.reportViewer1.LocalReport.ReportPath = this.reporte;

                //ReportDataSource source = new ReportDataSource(this.data.TableName, this.data);

                //this.reportViewer1.LocalReport.DataSources.Add(source);

                //this.reportViewer1.RefreshReport();
            }
        }

    }
}