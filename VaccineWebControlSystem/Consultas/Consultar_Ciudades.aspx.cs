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
    public partial class Consultar_Ciudades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Ciudades ciudad = new Ciudades();

            string filtro = "";
            if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    filtro = "CiudadId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }
            }
            DataTable dt = new DataTable();
            dt = ciudad.Listado("CiudadId,Descripcion ", filtro, "");
            ConsultaGridView.DataSource = dt;
            ConsultaGridView.DataBind();
        }

        protected void ReporteButton_Click1(object sender, EventArgs e)
        {
            Reportes.VaccineReportViewer viewer = new Reportes.VaccineReportViewer();
            Response.Redirect("/Reportes/CiudadesReportViewer.aspx");

        }
    }
}