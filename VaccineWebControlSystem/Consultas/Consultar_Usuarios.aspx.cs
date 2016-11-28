using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using BLL;

namespace VaccineWebControlSystem.Consultas
{
    public partial class Consulta_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();

            string filtro = "";
            if (string.IsNullOrWhiteSpace(FiltroTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    filtro = "UsuarioId = " + FiltroTextBox.Text;
                }
                else
                {
                    filtro = FiltroDropDownList.SelectedValue + " like '%" + FiltroTextBox.Text + "%'";
                }
            }
            DataTable dt = new DataTable();
            dt = user.Listado("UsuarioId,Nombres,Apellidos,Direccion,Cedula,Telefono,Email,CiudadId,NombresUsuarios,TipoUsuario ", filtro, "");
            ConsultaGridView.DataSource = dt;
            ConsultaGridView.DataBind();
        }

        protected void ImprimirButton_Click1(object sender, EventArgs e)
        {
            Reportes.VaccineReportViewer viewer = new Reportes.VaccineReportViewer();
            //DataTable dt = new DataTable();
            //dt = (DataTable)ConsultaGridView.DataSource;

            Response.Redirect("/Reportes/UsuariosReportViewer.aspx");

            //Response.RedirectLocation = "/Registros/Ciudades.aspx";
            //viewer.reporte = @"Reportes\UsuariosReport.rdlc";
            //viewer.data = dt;
            //viewer.LocalReport.Refresh();

            //Report.VaccineReportViewer viewer = new Report.VaccineReportViewer();
            //DataTable dt = new DataTable();

            //dt = (DataTable)ConsultadataGridView.DataSource;
            //dt.TableName = "Usuarios";

            //viewer.reporte = "UsuariosReport.rdlc";
            //viewer.data = dt;

            //viewer.ShowDialog();
        }
    }
}