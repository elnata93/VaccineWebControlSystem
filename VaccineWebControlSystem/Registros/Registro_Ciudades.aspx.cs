using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class Registro_Ciudades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Ciudades ciuda = new Ciudades();

        
        private void LlenarCampos()
        {
            DescripcionTextBox.Text = ciuda.descripcion;
           
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
                if (ciuda.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos();
                }
                else
                {
                   Utility.ShowToastr(this,"Id no exite","Mensaje","info");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no encotrado", "Mensaje", "info");
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
            ciuda.descripcion = DescripcionTextBox.Text;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (DescripcionTextBox.Text.Length == 0 )
            {
                Utility.ShowToastr(this,"Hay campos sin completar","Mensaje","info");
            }
            else

            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {

                LlenarDatos();
                if (ciuda.Insertar())
                {
                    Utility.ShowToastr(this, "Ciudad Guardar", "Mensaje", "success");
                }
                else
                {
                    Utility.ShowToastr(this, "Error al guardar", "Mensaje", "error");
                }
                Limpiar();
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) > 0)
            {
                if (ciuda.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (ciuda.Editar())
                    {
                        Utility.ShowToastr(this, "Ciudad Editada", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al editar", "Mensaje", "error");
                    }
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {
                Utility.ShowToastr(this, "Debe ingresar el Id", "Mensaje", "info");
            }
            else
            {
                if (ciuda.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    ciuda.Eliminar();
                    Utility.ShowToastr(this, "Ciudad Eliminada", "Mensaje", "success");
                    Limpiar();
                }
                else
                {
                    Utility.ShowToastr(this, "Error", "Mensaje", "error");
                    Limpiar();
                }
            }
        }
    }
}