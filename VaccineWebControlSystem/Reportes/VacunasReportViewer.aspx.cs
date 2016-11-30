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
    public partial class VacunasReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteVacunas();
        }

        private void ReporteVacunas()
        {
            if (!IsPostBack)
            {
                VacunaReportViewer.LocalReport.DataSources.Clear();
                VacunaReportViewer.ProcessingMode = ProcessingMode.Local;

                VacunaReportViewer.LocalReport.ReportPath = @"Reportes\VacunasReport.rdlc";

                ReportDataSource source = new ReportDataSource("Vacunas", Vacunas.ListadoVac("1=1"));

                VacunaReportViewer.LocalReport.DataSources.Add(source);

                VacunaReportViewer.LocalReport.Refresh();
            }
        }
    }
}