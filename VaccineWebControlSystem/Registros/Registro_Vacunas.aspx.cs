using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class Registro_Vacunas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Vacunas vacu = new Vacunas();

        private int Id(string cadena)
        {
            int id = 0;
            int.TryParse(cadena, out id);
            return id;
        }
        private void LlenarCampos()
        {
            DescripcionTextBox.Text = vacu.Descripcion;

        }

        private void Mensajes(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Mensajes("Introdusca el ID");
            }
            else
            if (Id(IdTextBox.Text) != 0)
            {
                if (vacu.Buscar(Id(IdTextBox.Text)))
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

        private void Limpiar()
        {
            IdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            IdTextBox.Enabled = true;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenarDatos()
        {
            vacu.Descripcion = DescripcionTextBox.Text;
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (DescripcionTextBox.Text.Length == 0)
            {
                Mensajes("Hay campos sin completar");
            }
            else

            if (Id(IdTextBox.Text) == 0)
            {

                LlenarDatos();
                if (vacu.Insertar())
                {
                    Mensajes("vacud Guardado");
                }
                else
                {
                    Mensajes("Error al Guardar");
                }
                //Limpiar();
            }
            else
            if (Id(IdTextBox.Text) > 0)
            {
                if (vacu.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (vacu.Editar())
                    {
                        Mensajes("Vacuna Guardado");
                    }
                    else
                    {
                        Mensajes("Error al Guardar");
                    }
                }
                //Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Mensajes("Debe Ingresar el ID");
            }
            else
            {
                if (vacu.Buscar(Id(IdTextBox.Text)))
                {
                    vacu.Eliminar();
                    Mensajes("Vacuna Eliminado");
                    //Limpiar();
                }
                else
                {
                    Mensajes("Error Vacuna no se Elimino");
                    //Limpiar();
                }
            }
        }
    }
}