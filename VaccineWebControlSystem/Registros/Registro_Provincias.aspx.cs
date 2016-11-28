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


        private void LlenarCampos(Provincias provin)
        {
            DescripcionTextBox.Text = provin.Descripcion;

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Provincias provin = new Provincias();
            if (IdTextBox.Text == "")
            {
                Utility.ShowToastr(this, "Introdusca el ID", "Mendsaje", "info");
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) != 0)
            {
                if (provin.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos(provin);
                }
                else
                {
                    Utility.ShowToastr(this, "Id no Existe", "Mendsaje", "info");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no Encotrado", "Mendsaje", "info");
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

        private void LlenarDatos(Provincias provin)
        {
            provin.Descripcion = DescripcionTextBox.Text;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Provincias provin = new Provincias();
            if (DescripcionTextBox.Text.Length == 0)
            {
                Utility.ShowToastr(this, "Hay campos sin completar", "Mensaje", "info");
            }
            else

            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {

                LlenarDatos(provin);
                if (provin.Insertar())
                {

                    Utility.ShowToastr(this, "Provincia Guardado", "Mensaje", "success");
                    Limpiar();
                }
                else
                {
                    Utility.ShowToastr(this, "Error al Guardado", "Mensaje", "error");
                    Limpiar();
                }
                Limpiar();
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) > 0)
            {
                if (provin.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarDatos(provin);
                    if (provin.Editar())
                    {
                        Utility.ShowToastr(this, "Provincia Editada", "Mensaje", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al Editar", "Mensaje", "error");
                        Limpiar();
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
                Utility.ShowToastr(this, "Debe Ingresar el ID", "Mensaje", "info");
                Limpiar();
            }
            else
            {
                if (provin.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    if (provin.Eliminar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Provincia Eliminado", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error no se Elimino", "Mensaje", "error");
                    }
                }
                else
                {
                    Utility.ShowToastr(this, "Error ", "Mensaje", "error");
                    Limpiar();
                }
            }
        }
    }
}