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
    public partial class CiudadesReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteCiudades();
        }

        private void ReporteCiudades()
        {
            if (!IsPostBack)
            {
                CiudadReportViewer.LocalReport.DataSources.Clear();
                CiudadReportViewer.ProcessingMode = ProcessingMode.Local;

                CiudadReportViewer.LocalReport.ReportPath = @"Reportes\CiudadesReport.rdlc";

                ReportDataSource source = new ReportDataSource("Ciudades", Ciudades.ListadoCiud("1=1"));

                CiudadReportViewer.LocalReport.DataSources.Add(source);

                CiudadReportViewer.LocalReport.Refresh();
            }
        }
    }
}