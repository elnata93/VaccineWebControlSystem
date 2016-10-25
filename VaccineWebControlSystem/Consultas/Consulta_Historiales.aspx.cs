using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace VaccineWebControlSystem.Consultas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Historiales historial = new Historiales();
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string filtro = "";
            if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    filtro = "HistorialId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }
            }
            DataTable dt = new DataTable();
            dt = historial.Listado("HistorialId,Fecha,CentroSalud,Provincia,Municipio ", filtro, "");
            ConsultaGridView.DataSource = dt;
            ConsultaGridView.DataBind();
        }

        protected void ImprimirButton_Click1(object sender, EventArgs e)
        {
            Reportes.VaccineReportViewer viewer = new Reportes.VaccineReportViewer();
            Response.Redirect("/Reportes/HistorialesReportViewer.aspx");
        }
    }
}