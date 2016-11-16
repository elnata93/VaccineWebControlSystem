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
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
            }
        }


        private void LlenarDropDownList()
        {
            Ciudades ciudad = new Ciudades();
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

        private void LlenarCampos(Usuarios user)
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
            Usuarios user = new Usuarios();
            Utility.ShowToastr(this, "Introdusca el ID","Error","Success");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('TODO BIEN', 'BIEN')", true);
            //if (IdTextBox.Text == "")
            //{
            //}
            //else
            //if (Id(IdTextBox.Text) != 0)
            //{
            //    if (user.Buscar(Id(IdTextBox.Text)))
            //    {
            //        LlenarCampos(user);
            //    }
            //    else
            //    {

            //        Utility.ShowToastr(this, "Id no exite", "Error", "Success");
            //    }
            //}
            //else
            //{
            //    Utility.ShowToastr(this, "Id no encontrado", "Error", "Success");

            //}
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

        private void LlenarDatos(Usuarios user)
        {
            user.nombre = NombreTextBox.Text;
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
            Usuarios user = new Usuarios();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
               LlenarDatos(user);
                if (user.Insertar())
                {
                    Limpiar();
                    Utility.ShowToastr(this, "Extio!", "Mensaje", "success");
                }
                else
                {
                   Utility.ShowToastr(this, "error", "Mensaje", "error");
                }
               
            }
            else
            if (IdTextBox.Text.Length > 0)
            {
                if (user.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarDatos(user);
                    if (user.Editar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Extio!", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "error", "Mensaje", "error");
                    }
                }
                
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            if (IdTextBox.Text.Length == 0)
            {
                //Mensajes("Debe Ingresar el ID");
            }
            else
            {
                if (user.Buscar(Id(IdTextBox.Text)))
                {
                    user.Eliminar();
                    //Mensajes("Usuario Eliminado");
                    //Limpiar();
                }
                else
                {
                    //Mensajes("Error Usuario no se Elimino");
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