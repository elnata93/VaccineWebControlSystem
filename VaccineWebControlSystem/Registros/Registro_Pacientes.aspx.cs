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
                FemeninoRadioButton.Checked = false;
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
            paciente.PacienteId = Utility.ConvertirToEntero( IdTextBox.Text);
            paciente.Nombres = NombreTextBox.Text;
            paciente.Apellidos = ApellidoTextBox.Text;
            paciente.Edad = Convert.ToInt32(EdadTextBox.Text);
            if (MasculinoRadioButton.Checked == true)
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

        private void Mensajes(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes();
            if (IdTextBox.Text == "")
            {
                Mensajes("Introdusca el ID");
            }
            else
            if (Utility.ConvertirToEntero(IdTextBox.Text) != 0)
            {
                if (paciente.Buscar(Utility.ConvertirToEntero(IdTextBox.Text)))
                {
                    LlenarCampos(paciente);
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

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes();
            if (Utility.ConvertirToEntero(IdTextBox.Text) == 0)
            {

                LlenarDatos(paciente);
                if (paciente.Insertar())
                {
                    Mensajes("Paciente Guardado");
                }
                else
                {
                    Mensajes("Error al Guardar");
                }
                Limpiar();
            }
            else
            if (Utility.ConvertirToEntero(IdTextBox.Text) > 0)
            {
                if (paciente.Buscar(Utility.ConvertirToEntero(IdTextBox.Text)))
                {
                    LlenarDatos(paciente);
                    if (paciente.Editar())
                    {
                        Mensajes("Paciente Editado");
                    }
                    else
                    {
                        Mensajes("Error al Guardar");
                    }
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes();

            if (Utility.ConvertirToEntero(IdTextBox.Text) == 0)
            {
                Mensajes("Debe Ingresar el ID");
            }
            else
                if (paciente.Buscar(Utility.ConvertirToEntero(IdTextBox.Text)))
                {
                    paciente.Eliminar();
                    Mensajes("Paciente Eliminado");
                    Limpiar();
                }
                else
                {
                    Mensajes("Error Paciente no se Elimino");
                    Limpiar();
                }
        }
    }
}