using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Sexo { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int CiudadId { get; set; }
        public string NommbreUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Contrasena { get; set; }
        

        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombre = "";
            this.Apellido = "";
            this.Sexo = 0;
            this.Direccion = "";
            this.Cedula = "";
            this.Telefono = "";
            this.Email = "";
            this.CiudadId = 0;
            this.NommbreUsuario = "";
            this.TipoUsuario = "";
            this.Contrasena = "";
        }

        public bool IniciarSesion()
        {
            DataTable dt = new DataTable();
            bool retorno = false;
            dt = conexion.ObtenerDatos(String.Format("select UsuarioId from Usuarios where NombresUsuarios='{0}' And Contrasena='{1}'", this.NommbreUsuario, this.Contrasena));
            if (dt.Rows.Count == 1)
            {
                UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                retorno = true;
            }

            return retorno;
        }

        public Usuarios(int usuarioid,int ciudadid,string nombre,string apellido,int sexo,string direccion,string cedula,string telefono,string email,string nombreusuario,string tipousuario,string contrasena)
        {
            this.UsuarioId = usuarioid;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.Email = email;
            this.CiudadId = ciudadid;
            this.NommbreUsuario = nombreusuario;
            this.TipoUsuario = tipousuario;
            this.Contrasena = contrasena;
           
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Usuarios(Nombres,Apellidos,Sexo,Direccion,Cedula,Telefono,Email,CiudadId,NombresUsuarios,TipoUsuario,Contrasena) values('{0}','{1}',{2},'{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}')", 
                    this.Nombre,this.Apellido,this.Sexo,this.Direccion,this.Cedula,this.Telefono,this.Email,this.CiudadId,this.NommbreUsuario,this.TipoUsuario,this.Contrasena));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("update Usuarios set Nombres='{0}',Apellidos='{1}',Sexo={2},Direccion='{3}',Cedula='{4}',Telefono='{5}',Email='{6}',CiudadId={7},NombreUsuarios='{8}',TipoUsuario='{9}',Contrasena='{10}' where UsuarioId={11} ",
                     this.Nombre, this.Apellido, this.Sexo, this.Direccion, this.Cedula, this.Telefono, this.Email, this.CiudadId, this.NommbreUsuario, this.TipoUsuario, this.Contrasena,this.UsuarioId));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("delete from Usuarios where UsuarioId={0}",this.UsuarioId));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable data = new DataTable();
            try
            {
                data = conexion.ObtenerDatos("Select * from Usuarios where UsuarioId= " + IdBuscado);
                if (data.Rows.Count > 0)
                {
                    
                    this.UsuarioId = (int)data.Rows[0]["UsuarioId"];
                    this.Nombre = data.Rows[0]["Nombres"].ToString();
                    this.Apellido = data.Rows[0]["Apellidos"].ToString();
                    this.Sexo = (int)data.Rows[0]["Sexo"];
                    this.Direccion = data.Rows[0]["Direccion"].ToString();
                    this.Cedula = data.Rows[0]["Cedula"].ToString();
                    this.Telefono = data.Rows[0]["Telefono"].ToString();
                    this.Email = data.Rows[0]["Email"].ToString();
                    this.CiudadId = (int)data.Rows[0]["CiudadId"];
                    this.NommbreUsuario = data.Rows[0]["NombresUsuarios"].ToString();
                    this.TipoUsuario = data.Rows[0]["TipoUsuario"].ToString();
                    this.Contrasena = data.Rows[0]["Contrasena"].ToString();
                }
                return data.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override DataTable Listado(string Campo, string Condicion, string Orden)
        {
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by" + Orden;
            return conexion.ObtenerDatos("Select " + Campo + " from Usuarios where " + Condicion + Orden);

        }

        public static DataTable ListadoUs( string Condicion)
        {
            ConexionDb conexion = new ConexionDb();
            return  conexion.ObtenerDatos("Select * from Usuarios where "+ Condicion );

        }
    }
}
