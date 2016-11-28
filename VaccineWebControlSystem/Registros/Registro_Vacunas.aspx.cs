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


        private void LlenarCampos(Vacunas vacu)
        {
            DescripcionTextBox.Text = vacu.Descripcion;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Vacunas vacu = new Vacunas();
            if (IdTextBox.Text == "")
            {
                Utility.ShowToastr(this, "Introdusca el ID", "Mensaje", "info");
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) != 0)
            {
                if (vacu.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos(vacu);
                }
                else
                {
                    Utility.ShowToastr(this, "Id no exite", "Mensaje", "info");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no encontrado", "Mensaje", "info");
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

        private void LlenarDatos(Vacunas vacu)
        {
            vacu.Descripcion = DescripcionTextBox.Text;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Vacunas vacu = new Vacunas();
            if (DescripcionTextBox.Text.Length == 0)
            {
                Utility.ShowToastr(this, "Hay campos sin completar", "Mensaje", "info");
            }
            else

            if (Utility.ConvertirToInt(IdTextBox.Text) == 0)
            {
                LlenarDatos(vacu);
                if (vacu.Insertar())
                {
                    Limpiar();
                    Utility.ShowToastr(this, "Vacuna Guardada", "Mensaje", "success");
                }
                else
                {
                    Utility.ShowToastr(this, "Error al Guardar", "Mensaje", "error");
                }
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) > 0)
            {
                if (vacu.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarDatos(vacu);
                    if (vacu.Editar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Vacuna Editada", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error al Editar", "Mensaje", "error");
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Vacunas vacu = new Vacunas();
            if (IdTextBox.Text.Length == 0)
            {
                Utility.ShowToastr(this, "Debe Ingresar el ID", "Mensaje", "info");
            }
            else
            {
                if (vacu.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    if (vacu.Eliminar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Vacuna Eliminado", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error Vacuna no se Elimino", "Mensaje", "error");

                    }

                }
                else
                {
                    Utility.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }
    }
}