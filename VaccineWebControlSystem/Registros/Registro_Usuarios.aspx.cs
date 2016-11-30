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
        

        private void LlenarCampos(Usuarios user)
        {
            NombreTextBox.Text = user.Nombre;
            ApellidoTextBox.Text = user.Apellido;
            if (user.Sexo == 0)
            {
                MasculinoRadioButton.Checked = true;
            }
            else
            {
                FemeninoRadioButton.Checked = true;
            }
            DireccionTextBox.Text = user.Direccion;
            CedulaTextBox.Text = user.Cedula;
            TelefonoTextBox.Text = user.Telefono;
            EmailTextBox.Text = user.Email;
            CiudadDropDownList.Text = Convert.ToInt32(user.CiudadId).ToString();
            NombreUsuarioTextBox.Text = user.NommbreUsuario;
            TipoUsuarioDropDownList.Text = user.TipoUsuario;
            ContrasenaTextBox.Text = user.Contrasena;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();

            if (IdTextBox.Text == "")
            {
                Utility.ShowToastr(this, "Introdusca el ID", "Mensaje", "error");
            }
            else
            if (Utility.ConvertirToInt(IdTextBox.Text) != 0)
            {
                if (user.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarCampos(user);
                }
                else
                {

                    Utility.ShowToastr(this, "Id no exite", "Error", "info");
                }
            }
            else
            {
                Utility.ShowToastr(this, "Id no encontrado", "Error", "info");

            }
        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            MasculinoRadioButton.Checked = false;
            FemeninoRadioButton.Checked = false;
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            TelefonoTextBox.Text = "";
            EmailTextBox.Text = "";
            CiudadDropDownList.ClearSelection();
            NombreUsuarioTextBox.Text = "";
            TipoUsuarioDropDownList.ClearSelection();
            ContrasenaTextBox.Text = "";
            ConfContrasenaTextBox.Text = "";

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenarDatos(Usuarios user)
        {
            user.Nombre = NombreTextBox.Text;
            user.Apellido = ApellidoTextBox.Text;
            if (MasculinoRadioButton.Checked)
            {
                user.Sexo = 0;
            }
            else
            {
                user.Sexo = 1;
            }
            user.Direccion = DireccionTextBox.Text;
            user.Cedula = CedulaTextBox.Text;
            user.Telefono = TelefonoTextBox.Text;
            user.Email = EmailTextBox.Text;
            user.CiudadId = Utility.ConvertirToInt(CiudadDropDownList.Text);
            user.NommbreUsuario = NombreUsuarioTextBox.Text;
            user.TipoUsuario = TipoUsuarioDropDownList.Text;
            user.Contrasena = ContrasenaTextBox.Text;
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
                    Utility.ShowToastr(this, "Usuario Guardado", "Mensaje", "success");
                }
                else
                {
                    Utility.ShowToastr(this, "Error al Guardar", "Mensaje", "error");
                }

            }
            else
            if (IdTextBox.Text.Length > 0)
            {
                if (user.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    LlenarDatos(user);
                    if (user.Editar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Usuario Editado", "Mensaje", "success");
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
            Usuarios user = new Usuarios();
            if (IdTextBox.Text.Length == 0)
            {
                Utility.ShowToastr(this, "Debe Ingresar el ID", "Mensaje", "info");
            }
            else
            {
                if (user.Buscar(Utility.ConvertirToInt(IdTextBox.Text)))
                {
                    if (user.Eliminar())
                    {
                        Limpiar();
                        Utility.ShowToastr(this, "Usuario Eliminado", "Mensaje", "success");
                    }
                    else
                    {
                        Utility.ShowToastr(this, "Error Usuario no se Elimino", "Mensaje", "error");
                    }
                }
                else
                {
                    Utility.ShowToastr(this, "Error ", "Mensaje", "error");
                }
            }
        }

        protected void SubirButton_Click(object sender, EventArgs e)
        {
            //string nombre = "capture.jpg";
            //FotoFileUpload.SaveAs(Server.MapPath("~/Imagenes" + nombre));
            //FotoImage.ImageUrl = nombre;
        }
    }
}