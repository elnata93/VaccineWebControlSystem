using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace VaccineWebControlSystem.Reportes
{
    public partial class PacientesReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportePacientes();
        }

        private void ReportePacientes()
        {
            if (!IsPostBack)
            {
                PacienteReportViewer.LocalReport.DataSources.Clear();
                PacienteReportViewer.ProcessingMode = ProcessingMode.Local;

                PacienteReportViewer.LocalReport.ReportPath = @"Reportes\PacientesReport.rdlc";

                ReportDataSource source = new ReportDataSource("Pacientes", Pacientes.ListadoPac("1=1"));

                PacienteReportViewer.LocalReport.DataSources.Add(source);

                PacienteReportViewer.LocalReport.Refresh();
            }
        }
    }
}