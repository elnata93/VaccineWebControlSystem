using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VaccineWebControlSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void LlenarDatos(Usuarios usuario)
        {
            if (ValidarNombre(UserNameTextBox.Text))
            {
                usuario.NommbreUsuario = UserNameTextBox.Text;
                usuario.Contrasena = PasswordTextBox.Text;
            }
        }

        public static bool ValidarNombre(string Nombre)
        {
            return Regex.IsMatch(Nombre, @"[a-zA-ZñÑ\s]{2,50}");
        }

        protected void IniciarSesionButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
           
            LlenarDatos(usuario);
            if (usuario.IniciarSesion())
            {
                FormsAuthentication.RedirectFromLoginPage(UserNameTextBox.Text, RememberCheckBox.Checked);
            }
            else
            {
                // Utility.ShowToastr(this, "Usuario Incorrecto", "Mensaje", "error"); ponerle el mensaje
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Registros/Registro_Usuarios.aspx");
        }
        
    }
}