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
    public partial class HistorialesReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteHistoriales();
        }

        private void ReporteHistoriales()
        {
            if (!IsPostBack)
            {
                HistorialReportViewer.LocalReport.DataSources.Clear();
                HistorialReportViewer.ProcessingMode = ProcessingMode.Local;

                HistorialReportViewer.LocalReport.ReportPath = @"Reportes\HistorialesReport.rdlc";

                ReportDataSource source = new ReportDataSource("Historiales", Historiales.ListadoHist("1=1"));

                HistorialReportViewer.LocalReport.DataSources.Add(source);

                HistorialReportViewer.LocalReport.Refresh();
            }
            
        }
    }
}