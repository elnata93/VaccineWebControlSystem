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
    public partial class MunicipiosReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReporteMunicipios();
        }

        private void ReporteMunicipios()
        {
            if (!IsPostBack)
            {
                MunicipioReportViewer.LocalReport.DataSources.Clear();
                MunicipioReportViewer.ProcessingMode = ProcessingMode.Local;

                MunicipioReportViewer.LocalReport.ReportPath = @"Reportes\MunicipiosReport.rdlc";

                ReportDataSource source = new ReportDataSource("Municipios", Municipios.ListadoMun("1=1"));

                MunicipioReportViewer.LocalReport.DataSources.Add(source);

                MunicipioReportViewer.LocalReport.Refresh();
            }
        }
    }
}