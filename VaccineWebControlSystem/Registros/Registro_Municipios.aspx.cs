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
        private int Id(string cadena)
        {
            int id = 0;
            int.TryParse(cadena, out id);
            return id;
        }
        private void LlenarCampos()
        {
            DescripcionTextBox.Text = muni.Descripcion;

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                Response.Write("<script>alert('Introdusca el ID')</script>");
            }
            else
            if (Id(IdTextBox.Text) != 0)
            {
                if (muni.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarCampos();
                }
                else
                {
                    Response.Write("<script>alert('Id no exite')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Id no encontrado')</script>");
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
                Response.Write("<script>alert('Hay campos sin completar')<script>");
            }
            else

            if (Id(IdTextBox.Text) == 0)
            {

                LlenarDatos();
                if (muni.Insertar())
                {
                    Response.Write("<script>alert('munid Guardado')<script>");
                }
                else
                {
                    Response.Write("<script>alert('Error al Guardar')</script>");
                }
                //Limpiar();
            }
            else
            if (Id(IdTextBox.Text) > 0)
            {
                if (muni.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (muni.Editar())
                    {
                        Response.Write("<script>alert('munid Guardado')<script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Guardar')</script>");
                    }
                }
                //Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe Ingresar el ID')<script>");
            }
            else
            {
                if (muni.Buscar(Id(IdTextBox.Text)))
                {
                    muni.Eliminar();
                    Response.Write("<script>alert('munid Eliminado')<script>");
                    //Limpiar();
                }
                else
                {
                    Response.Write("<script>alert('Error munid no se Elimino')<script>");
                    //Limpiar();
                }
            }
        }
    }
}