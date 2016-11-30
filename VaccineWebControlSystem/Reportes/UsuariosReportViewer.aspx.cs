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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteUsuarios();
        }

        private void ReporteUsuarios()
        {
            if (!IsPostBack)
            {

                UsuarioReportViewer.LocalReport.DataSources.Clear();
                UsuarioReportViewer.ProcessingMode = ProcessingMode.Local;

                UsuarioReportViewer.LocalReport.ReportPath = @"Reportes\UsuariosReport.rdlc";

                ReportDataSource source = new ReportDataSource("Usuarios", Usuarios.ListadoUs("1=1"));

                UsuarioReportViewer.LocalReport.DataSources.Add(source);

                UsuarioReportViewer.LocalReport.Refresh();
            }
        }
    }
}