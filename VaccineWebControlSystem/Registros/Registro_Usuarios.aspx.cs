using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VaccineWebControlSystem.Registros
{
    public partial class Registro_Usuarios : System.Web.UI.Page
    {
        Usuarios user = new Usuarios();
        Ciudades ciudad = new Ciudades();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
            
            LlenarDropDownList();
        }

        private void LlenarDropDownList()
        {
            CiudadDropDownList.DataSource = ciudad.Listado(" * ", " 1=1 ", " ");
            CiudadDropDownList.DataTextField = "Descripcion";
            CiudadDropDownList.DataValueField = "CiudadId";
            CiudadDropDownList.DataBind();
            
        }

        private int Id(string cadena)
        {
            int id = 0;
            int.TryParse(cadena, out id);
            return id;
        }

        private void LlenarCampos()
        {
                       
            NombreTextBox.Text = user.nombre;
            ApellidoTextBox.Text = user.apellido;
            DireccionTextBox.Text = user.direccion;
            CedulaTextBox.Text = user.Cedula;
            TelefonoTextBox.Text = user.telefono;
            EmailTextBox.Text = user.email;
            CiudadDropDownList.Text = Convert.ToInt32(user.ciudadId).ToString();
            NombreUsuarioTextBox.Text = user.nommbreUsuario;
            TipoUsuarioDropDownList.Text = user.tipoUsuario;
            ContrasenaTextBox.Text = user.contrasena;
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
                if (user.Buscar(Id(IdTextBox.Text)))
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
            Response.Write("<script>alert('"+mensaje +"');</script>");
        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            TelefonoTextBox.Text = "";
            EmailTextBox.Text = "";
            CiudadDropDownList.SelectedIndex = 0;
            NombreUsuarioTextBox.Text = "";
            TipoUsuarioDropDownList.SelectedIndex = 0;
            ContrasenaTextBox.Text = "";
            ConfContrasenaTextBox.Text = "";

        }
        
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void LlenarDatos()
        {
            
            user.nombre = NombreTextBox.Text ;
            user.apellido = ApellidoTextBox.Text;
            user.direccion = DireccionTextBox.Text;
            user.Cedula = CedulaTextBox.Text;
            user.telefono = TelefonoTextBox.Text;
            user.email = EmailTextBox.Text;
            user.ciudadId = Convert.ToInt32(CiudadDropDownList.Text);
            user.nommbreUsuario = NombreUsuarioTextBox.Text;
            user.tipoUsuario = TipoUsuarioDropDownList.Text;
            user.contrasena = ContrasenaTextBox.Text;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (NombreTextBox.Text.Length == 0 || ApellidoTextBox.Text.Length == 0 || DireccionTextBox.Text.Length == 0 ||
                TelefonoTextBox.Text.Length == 0 || EmailTextBox.Text.Length == 0 || CiudadDropDownList.Text.Length == 0 ||
                NombreUsuarioTextBox.Text.Length == 0 || TipoUsuarioDropDownList.Text.Length == 0 ||
                ContrasenaTextBox.Text.Length == 0 || ConfContrasenaTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Hay campos sin completar');<script>");
            }
            else

            if (Id(IdTextBox.Text) == 0)
            {

                LlenarDatos();
                if (user.Insertar())
                {
                    Response.Write("<script>alert('Material Guardado');<script>");
                }
                else
                {
                    Response.Write("<script>alert('Error al Guardar');</script>");
                }
                //Limpiar();
            }
            else
            if (Id(IdTextBox.Text) > 0)
            {
                if (user.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (user.Editar())
                    {
                        Response.Write("<script>alert('Material Guardado');<script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Guardar');</script>");
                    }
                }
                //Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe Ingresar el ID');<script>");
            }
            else
            {
                if (user.Buscar(Id(IdTextBox.Text)))
                {
                    user.Eliminar();
                    Response.Write("<script>alert('Usuario Eliminado');<script>");
                    //Limpiar();
                }
                else
                {
                    Response.Write("<script>alert('Error Usuario no se Elimino');<script>");
                    //Limpiar();
                }
            }
        }

        protected void SubirButton_Click(object sender, EventArgs e)
        {
            string nombre = "capture.jpg";
            FotoFileUpload.SaveAs(Server.MapPath("~/Imagenes" + nombre));
            FotoImage.ImageUrl = nombre;
        }
    }
}