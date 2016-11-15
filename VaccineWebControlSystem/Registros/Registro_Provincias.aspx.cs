using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class Registro_Provincia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Mensajes(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }

        private void LlenarCampos(Provincias provin )
        {
            DescripcionTextBox.Text = provin.Descripcion;

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Provincias provin = new Provincias();
            if (IdTextBox.Text == "")
            {
                Mensajes("Introdusca el ID");
            }
            else
            if (Utility.ConvertirToEntero(IdTextBox.Text) != 0)
            {
                if (provin.Buscar(Utility.ConvertirToEntero(IdTextBox.Text)))
                {
                    LlenarCampos(provin);
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

        private void LlenarDatos(Provincias provin )
        {
            provin.Descripcion = DescripcionTextBox.Text;
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Provincias provin = new Provincias();
            if (DescripcionTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Hay campos sin completar')<script>");
            }
            else

            if (Utility.ConvertirToEntero(IdTextBox.Text) == 0)
            {

                LlenarDatos(provin);
                if (provin.Insertar())
                {
                    Mensajes("Provincia Guardado");
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
                if (provin.Buscar(Utility.ConvertirToEntero(IdTextBox.Text)))
                {
                    LlenarDatos(provin);
                    if (provin.Editar())
                    {
                        Mensajes("Provincia Guardado");
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
            Provincias provin = new Provincias();
            if (IdTextBox.Text.Length == 0)
            {
                Mensajes("Debe Ingresar el ID");
            }
            else
                if (provin.Buscar(Utility.ConvertirToEntero(IdTextBox.Text)))
                {
                    provin.Eliminar();
                    Mensajes("Provincia Eliminado");
                    Limpiar();
                }
                else
                {
                    Mensajes("Error Provincia no se Elimino");
                    Limpiar();
                }
        }
    }
}