using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteLlenarDropDownList();
                ProvinviaLlenarDropDownList();
                MunicipioLlenarDropDownList();
                VacunaLlenarDropDownList();
                FechaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                int Id;
                if (Request.QueryString["Id"] != null)
                {
                    Id = Utility.ConvertirToInt(Request.QueryString["Id"].ToString());

                    if (Id > 0)
                    {
                        Historiales historial = new Historiales();
                        if (!historial.Buscar(Id))
                        {
                            Utility.ShowToastr(this, "Registro no encontrado", "Error", "Danger");

                        }
                        else
                        {
                            IdTextBox.Text = Id.ToString();
                            LlenarCampos(historial);
                        }

                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("VacunaId"), new DataColumn("Dosis"), new DataColumn("Fecha") });
                Session["historial"] = dt;


            }

        }

        private void PacienteLlenarDropDownList()
        {
            Pacientes paciente = new Pacientes();
            PacienteDropDownList.DataSource = paciente.Listado(" * ", " 1=1 ", " ");
            PacienteDropDownList.DataTextField = "Nombres";
            PacienteDropDownList.DataValueField = "PacienteId";
            PacienteDropDownList.DataBind();
            PacienteDropDownList.Items.Insert(0, "Selecionar");
        }

        private void ProvinviaLlenarDropDownList()
        {
            Provincias provincia = new Provincias();
            ProvinciaDropDownList.DataSource = provincia.Listado(" * ", " 1=1 ", " ");
            ProvinciaDropDownList.DataTextField = "Descripcion";
            ProvinciaDropDownList.DataValueField = "ProvinciaId";
            ProvinciaDropDownList.DataBind();
            ProvinciaDropDownList.Items.Insert(0, "Selecionar");
        }

        private void MunicipioLlenarDropDownList()
        {
            Municipios municipio = new Municipios();
            MunicipioDropDownList.DataSource = municipio.Listado(" * ", " 1=1 ", " ");
            MunicipioDropDownList.DataTextField = "Descripcion";
            MunicipioDropDownList.DataValueField = "MunicipioId";
            MunicipioDropDownList.DataBind();
            MunicipioDropDownList.Items.Insert(0, "Selecionar");
        }

        private void VacunaLlenarDropDownList()
        {
            Vacunas vacu = new Vacunas();
            VacunaDropDownList.DataSource = vacu.Listado(" * ", " 1=1 ", " ");
            VacunaDropDownList.DataTextField = "Descripcion";
            VacunaDropDownList.DataValueField = "VacunaId";
            VacunaDropDownList.DataBind();
            VacunaDropDownList.Items.Insert(0, "Selecionar");

        }

        private void LlenarCampos(Historiales historial)
        {
            IdTextBox.Text = historial.HistorialId.ToString();
            FechaLabel.Text = historial.Fecha;
            CentroSaludTextBox.Text = historial.CentroSalud;
            ProvinciaDropDownList.SelectedIndex = historial.ProvinciaId;
            MunicipioDropDownList.SelectedIndex = historial.MunicipioId;
            PacienteDropDownList.SelectedIndex = historial.PacienteId;
            //foreach (GridViewRow item in HistorialGridView.Rows)
            //{
            //    historial.AgregarVacuna(Utility.ConvertirToInt(item.Cells[0].Text), Utility.ConvertirToInt(item.Cells[1].Text), item.Cells[2].Text);
            //}
            HistorialGridView.DataSource = historial.historialVacuna;
            HistorialGridView.DataBind();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Historiales historial = new Historiales();
            if (IdTextBox.Text == "")
            {
                Utility.ShowToastr(this, "Introdusca el ID", "Mensaje", "info");
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) != 0)
            {
                if (historial.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos(historial);
                }
                else
                {
                    Utility.ShowToastr(this, "Id no Existe!", "Mensaje", "info");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no Encontrado!", "Mensaje", "info");
            }
        }

        private void Limpiar()
        {
            FechaLabel.Text = FechaLabel.Text;
            IdTextBox.Text = string.Empty;
            CentroSaludTextBox.Text = "";
            ProvinciaDropDownList.ClearSelection();
            MunicipioDropDownList.ClearSelection();
            PacienteDropDownList.ClearSelection();
            VacunaDropDownList.ClearSelection();
            DosisTextBox.Text = string.Empty;
            FechaVacunaTextBox.Text = string.Empty;
            HistorialGridView.DataSource = null;
            HistorialGridView.DataBind();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenarDatos(Historiales historial)
        {
            historial.Fecha = FechaLabel.Text;
            historial.CentroSalud = CentroSaludTextBox.Text;
            historial.ProvinciaId = ProvinciaDropDownList.SelectedIndex;
            historial.MunicipioId = MunicipioDropDownList.SelectedIndex;
            historial.PacienteId = PacienteDropDownList.SelectedIndex;
            foreach (GridViewRow item in HistorialGridView.Rows)
            {
                historial.AgregarVacuna(Convert.ToInt32(item.Cells[0].TabIndex), Convert.ToInt32(item.Cells[1].Text), item.Cells[2].Text);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Historiales historial = new Historiales();
            if (IdTextBox.Text.Length == 0)
            {
                LlenarDatos(historial);
                if (historial.Insertar())
                {
                    Limpiar();
                    Utility.ShowToastr(this, "Extio!", "Mensaje", "success");
                }
                else
                {
                    Utility.ShowToastr(this, "Error!", "Mensaje", "error");
                }
                Limpiar();
            }
            else
            {
                if (Utility.ConvertirToInt(IdTextBox.Text) > 0)
                {
                    LlenarDatos(historial);
                    if (historial.Editar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Extio!", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error!", "Mensaje", "error");
                    }
                    
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Historiales historial = new Historiales();
            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {
                Utility.ShowToastr(this, "Debe Ingresae el ID!", "Mensaje", "info");
            }
            else
            {
                if (historial.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    if (historial.Eliminar())
                    {

                        Utility.ShowToastr(this, "Historial Eliminado", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al Elimininar", "Mensaje", "error");
                    }
                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if (Session["historial"] == null)
            {
                Session["historial"] = new Historiales();
            }

            DataTable dt = (DataTable)Session["historial"];

            dt.Rows.Add(Utility.ConvertirToInt(VacunaDropDownList.Text), Utility.ConvertirToInt(DosisTextBox.Text), FechaVacunaTextBox.Text);

            Session["historial"] = dt;

            HistorialGridView.DataSource = dt;
            HistorialGridView.DataBind();

        }
    }
}