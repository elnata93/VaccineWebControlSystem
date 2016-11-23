using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Reutilizable
{
    public partial class PacientesWebUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pacientes paciente = new Pacientes();
                PacientesDropDownList.DataSource = paciente.Listado("*", "1=1", "");
                PacientesDropDownList.DataTextField = "Nombres";
                PacientesDropDownList.DataValueField = "PacienteId";
                PacientesDropDownList.DataBind();
                PacientesDropDownList.Items.Insert(0, "Selecionar--");
            }
        }
    }
}