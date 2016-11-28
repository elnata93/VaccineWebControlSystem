using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace VaccineWebControlSystem.Consultas
{
    public partial class Consultar_Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Pacientes paci = new Pacientes();

            string filtro = "";
            if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    filtro = "PacienteId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }
            }
            DataTable dt = new DataTable();
            dt = paci.Listado("PacienteId,Nombres,Apellidos,Edad,Sexo,Direccion,Telefono,Cedula ", filtro, "");
            ConsultaGridView.DataSource = dt;
            ConsultaGridView.DataBind();
        }
        
        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Reportes.VaccineReportViewer viewer = new Reportes.VaccineReportViewer();
            Response.Redirect("/Reportes/PacientesReportViewer.aspx");
        }
    }
}