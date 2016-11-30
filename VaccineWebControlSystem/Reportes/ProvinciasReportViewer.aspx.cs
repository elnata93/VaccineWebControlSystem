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
    public partial class ProvinciasReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteProvincias();
        }

        private void ReporteProvincias()
        {
            if (!IsPostBack)
            {
                ProvinciaReportViewer.LocalReport.DataSources.Clear();
                ProvinciaReportViewer.ProcessingMode = ProcessingMode.Local;

                ProvinciaReportViewer.LocalReport.ReportPath = @"Reportes\ProvinciasReport.rdlc";

                ReportDataSource source = new ReportDataSource("Provincias", Provincias.ListadoProv("1=1"));

                ProvinciaReportViewer.LocalReport.DataSources.Add(source);

                ProvinciaReportViewer.LocalReport.Refresh();
            }
        }
    }
}