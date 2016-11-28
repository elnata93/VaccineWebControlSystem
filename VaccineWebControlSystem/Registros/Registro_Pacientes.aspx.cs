using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class Registro_Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void LlenarCampos(Pacientes paciente)
        {
            IdTextBox.Text = paciente.PacienteId.ToString();
            NombreTextBox.Text = paciente.Nombres;
            ApellidoTextBox.Text = paciente.Apellidos;
            EdadTextBox.Text = paciente.Edad.ToString();

            if (paciente.Sexo == 0)
            {
                MasculinoRadioButton.Checked = true;
            }
            else
            {
                FemeninoRadioButton.Checked = true;
            }
            DireccionTextBox.Text = paciente.Direccion;
            TelefonoTextBox.Text = paciente.Telefono;
            CedulaTextBox.Text = paciente.Cedula;

        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            EdadTextBox.Text = "";
            MasculinoRadioButton.Checked = false;
            FemeninoRadioButton.Checked = false;
            DireccionTextBox.Text = "";
            TelefonoTextBox.Text = "";
            CedulaTextBox.Text = "";
            EliminarButton.Enabled = false;

        }

        private void LlenarDatos(Pacientes paciente)
        {
            paciente.PacienteId = Utility.ConvertirToInt(IdTextBox.Text);
            paciente.Nombres = NombreTextBox.Text;
            paciente.Apellidos = ApellidoTextBox.Text;
            paciente.Edad = Convert.ToInt32(EdadTextBox.Text);
            if (MasculinoRadioButton.Checked)
            {
                paciente.Sexo = 0;
            }else
            {
                paciente.Sexo = 1;
            }
            paciente.Direccion = DireccionTextBox.Text;
            paciente.Telefono = TelefonoTextBox.Text;
            paciente.Cedula = CedulaTextBox.Text;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes();
            if (IdTextBox.Text == "")
            {
                Utility.ShowToastr(this, "Introdusca el ID", "Mensaje", "info");
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) != 0)
            {
                if (paciente.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos(paciente);
                }
                else
                {
                    Utility.ShowToastr(this, "Id no exite", "Mensaje", "inf");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no encontrado", "Mensaje", "info");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes();
            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {
                LlenarDatos(paciente);
                if (paciente.Insertar())
                {
                    Limpiar();
                    Utility.ShowToastr(this, "Paciente Guardado", "Mensaje", "success");
                }
                else
                {
                    Utility.ShowToastr(this, "Error no al Guardar", "Mensaje", "error");
                }
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) > 0)
            {
                if (paciente.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarDatos(paciente);
                    if (paciente.Editar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Paciente Editado", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al Editar", "Mensaje", "info");
                    }
                }

            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes();

            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {
                Utility.ShowToastr(this, "Debe ingresar el Id", "Mensaje", "info");
            }
            else
            {
                if (paciente.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    if (paciente.Eliminar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Paciente Eliminado", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al ELiminar", "Mensaje", "error");
                    }
                }
            }
        }
    }
}