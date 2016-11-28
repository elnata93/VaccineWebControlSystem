using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace VaccineWebControlSystem.Registros
{
    public partial class Registro_Municipio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Municipios muni = new Municipios();
       
        private void LlenarCampos()
        {
            DescripcionTextBox.Text = muni.Descripcion;

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Utility.ShowToastr(this,"Introdusca el ID","Mensaje","info");
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) != 0)
            {
                if (muni.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos();
                }
                else
                {
                    Utility.ShowToastr(this, "Id no Exite", "Mensaje", "info");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no Encontrado", "Mensaje", "info");
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
            muni.Descripcion = DescripcionTextBox.Text;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (DescripcionTextBox.Text.Length == 0)
            {
                Utility.ShowToastr(this,"Hay campos sin completar","Mensaje","info");
            }
            else

            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {

                LlenarDatos();
                if (muni.Insertar())
                {
                    Utility.ShowToastr(this, "Muninicipio Guardado", "Mensaje", "success");
                    Limpiar();
                }
                else
                {
                    Utility.ShowToastr(this, "Error al Guardar", "Mensaje", "error");
                    Limpiar();
                }
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) > 0)
            {
                if (muni.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (muni.Editar())
                    {
                        Utility.ShowToastr(this, "Muninicipio Editado", "Mensaje", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al Editar", "Mensaje", "error");
                        Limpiar();
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Utility.ShowToastr(this,"Debe Ingresar el Id","Mensaje","info");
            }
            else
            {
                if (muni.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    muni.Eliminar();
                    Utility.ShowToastr(this, "Muninicipio Eliminado", "Mensaje", "success");
                    Limpiar();
                }
                else
                {
                    Utility.ShowToastr(this, "Error al Eliminar", "Mensaje", "error");
                    Limpiar();
                }
            }
        }
    }
}