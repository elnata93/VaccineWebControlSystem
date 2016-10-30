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
            FechaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                historial.AgregarVacuna(Convert.ToInt32(item.Cells[0].Text),Convert.ToBoolean(item.Cells[1].TabIndex),Convert.ToInt32(item.Cells[2].Text),Convert.ToString(item.Cells[3].Text));
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
            DosisTextBox.Text = "";
            FechaCalendar.SelectedDates.Clear();
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
                historial.AgregarVacuna(Convert.ToInt32(item.Cells[0].Text), Convert.ToBoolean(item.Cells[1].TabIndex), Convert.ToInt32(item.Cells[2].Text), Convert.ToString(item.Cells[3].Text));
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
                if(ConvertToInt(IdTextBox.Text) > 0)
                {
                    LlenarDatos();
                    if (historial.Editar())
                    {
                        Mensajes("Historial Editado");
                    }else
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
    }
}