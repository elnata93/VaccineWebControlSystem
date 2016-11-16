using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Historiales historial = new Historiales();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteLlenarDropDownList();
                ProvinviaLlenarDropDownList();
                MunicipioLlenarDropDownList();
                VacunaLlenarDropDownList();
                FechaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            }

        }

        private void PacienteLlenarDropDownList()
        {
            Pacientes paciente = new Pacientes();
            PacienteDropDownList.DataSource = paciente.Listado(" * ", " 1=1 ", " ");
            PacienteDropDownList.DataTextField = "Nombres";
            PacienteDropDownList.DataValueField = "PacienteId";
            PacienteDropDownList.DataBind();

        }

        private void ProvinviaLlenarDropDownList()
        {
            Provincias provincia = new Provincias();
            ProvinciaDropDownList.DataSource = provincia.Listado(" * ", " 1=1 ", " ");
            ProvinciaDropDownList.DataTextField = "Descripcion";
            ProvinciaDropDownList.DataValueField = "ProvinciaId";
            ProvinciaDropDownList.DataBind();

        }

        private void MunicipioLlenarDropDownList()
        {
            Municipios municipio = new Municipios();
            MunicipioDropDownList.DataSource = municipio.Listado(" * ", " 1=1 ", " ");
            MunicipioDropDownList.DataTextField = "Descripcion";
            MunicipioDropDownList.DataValueField = "MunicipioId";
            MunicipioDropDownList.DataBind();

        }

        private void VacunaLlenarDropDownList()
        {
            Vacunas vacu = new Vacunas();
            VacunaDropDownList.DataSource = vacu.Listado(" * ", " 1=1 ", " ");
            VacunaDropDownList.DataTextField = "Descripcion";
            VacunaDropDownList.DataValueField = "VacunaId";
            VacunaDropDownList.DataBind();

        }

        private void LlenarCampos()
        {
            IdTextBox.Text = historial.HistorialId.ToString();
            FechaLabel.Text = historial.Fecha;
            CentroSaludTextBox.Text = historial.CentroSalud;
            ProvinciaDropDownList.SelectedIndex = historial.ProvinciaId;
            MunicipioDropDownList.SelectedIndex = historial.MunicipioId;
            PacienteDropDownList.SelectedIndex = historial.PacienteId;
            foreach (GridViewRow item in HistorialGridView.Rows)
            {
                historial.AgregarVacuna(Convert.ToInt32(item.Cells[0].Text), Convert.ToInt32(item.Cells[1].TabIndex), Convert.ToInt32(item.Cells[2].Text), item.Cells[3].Text);
            }

        }

        private int ConvertToInt(string numero)
        {
            int id = 0;
            int.TryParse(numero, out id);
            return id;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Mensajes("Introdusca el ID");
            }
            else
            if (ConvertToInt(IdTextBox.Text) != 0)
            {
                if (historial.Buscar(ConvertToInt(IdTextBox.Text)))
                {
                    LlenarCampos();
                }
                else
                {
                    Mensajes("Id no exite");
                }
            }
            else
            {
                Mensajes("Id no encontrado");
            }
        }

        private void Mensajes(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            CentroSaludTextBox.Text = "";
            ProvinciaDropDownList.ClearSelection();
            MunicipioDropDownList.ClearSelection();
            PacienteDropDownList.ClearSelection();
            VacunaDropDownList.ClearSelection();
            SiRadioButton.Checked = false;
            NoRadioButton.Checked = false;
            DosisTextBox.Text = string.Empty;
            FechaCalendar.SelectedDates.Clear();
            HistorialGridView.DataSource = string.Empty;
            HistorialGridView.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenarDatos()
        {
            historial.Fecha = FechaLabel.Text;
            historial.CentroSalud = CentroSaludTextBox.Text;
            historial.ProvinciaId = ProvinciaDropDownList.SelectedIndex;
            historial.MunicipioId = MunicipioDropDownList.SelectedIndex;
            historial.PacienteId = PacienteDropDownList.SelectedIndex;
            foreach (GridViewRow item in HistorialGridView.Rows)
            {
                historial.AgregarVacuna(Convert.ToInt32(item.Cells[0].Text), Convert.ToInt32(item.Cells[1].TabIndex), Convert.ToInt32(item.Cells[2].Text), item.Cells[3].Text);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                LlenarDatos();
                if (historial.Insertar())
                {
                    Mensajes("Historial Guardado");
                }
                else
                {
                    Mensajes("Error al guardar");
                }
            }
            else
            {
                if (ConvertToInt(IdTextBox.Text) > 0)
                {
                    LlenarDatos();
                    if (historial.Editar())
                    {
                        Mensajes("Historial Editado");
                    }
                    else
                    {
                        Mensajes("Error al Editar");
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ConvertToInt(IdTextBox.Text) == 0)
            {
                Mensajes("Debe Ingresar el ID");
            }
            else
            {
                if (historial.Buscar(ConvertToInt(IdTextBox.Text)))
                {
                    historial.Eliminar();
                    Mensajes("Historial Eliminado");
                }
                else
                {
                    Mensajes("Error al Eliminar");
                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Historiales historial;

            if (Session["Historial"] == null)
            {
                Session["Historial"] = new Historiales();
            }

            historial = (Historiales)Session["Historial"];
            //if (VacunaDropDownList.SelectedIndex == 0 || NoRadioButton.TabIndex == 0 || SiRadioButton.TabIndex == 0 || DosisTextBox.Text.Length == 0)
            //{
            //    Response.Write("<script>alert('Debe llenar los Campos');</script>");
            //}
            historial.AgregarVacuna(Convert.ToInt32(VacunaDropDownList.Text), Convert.ToInt32(SiRadioButton.Checked), Convert.ToInt32(DosisTextBox.Text), CalendarTextBox.Text ); //Convert.ToDateTime(FechaCalendar.SelectedDate.ToString())
            HistorialGridView.DataSource = historial.historialVacuna;
            HistorialGridView.DataBind();
        }
    }
}