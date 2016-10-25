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
        public int usuarioId { get; set; }
        public string fecha { get; set; }
        public string imagen { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string Cedula { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public int ciudadId { get; set; }
        public string nommbreUsuario { get; set; }
        public string tipoUsuario { get; set; }
        public string contrasena { get; set; }
        

        public Usuarios()
        {
            this.usuarioId = 0;
            this.fecha = "";
            this.imagen = "";
            this.nombre = "";
            this.apellido = "";
            this.direccion = "";
            this.Cedula = "";
            this.telefono = "";
            this.email = "";
            this.ciudadId = 0;
            this.nommbreUsuario = "";
            this.tipoUsuario = "";
            this.contrasena = "";
        }

        public Usuarios(int usuarioid,int ciudadid,string fecha,string imagen,string nombre,string apellido,string direccion,string cedula,string telefono,string email,string nombreusuario,string tipousuario,string contrasena)
        {
            this.usuarioId = usuarioid;
            this.fecha = fecha;
            this.imagen = imagen;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.Cedula = cedula;
            this.telefono = telefono;
            this.email = email;
            this.ciudadId = ciudadid;
            this.nommbreUsuario = nombreusuario;
            this.tipoUsuario = tipousuario;
            this.contrasena = contrasena;
           
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Usuarios(Fecha,Imagen,Nombres,Apellidos,Direccion,Cedula,Telefono,Email,CiudadId,NombresUsuarios,TipoUsuario,Contrasena) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}')",this.fecha,this.imagen,this.nombre,this.apellido,this.direccion,this.Cedula,this.telefono,this.email,this.ciudadId,this.nommbreUsuario,this.tipoUsuario,this.contrasena));
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
                retorno = conexion.Ejecutar(String.Format("update Usuarios set Fecha='{0}',Imagem='{1}',Nombres='{2}',Apellidos='{3}',Direccion='{4}',Cedula='{5}',Telefono='{6}',Email='{7}',CiudadId={8},NombreUsuarios='{9}',TipoUsuario='{10}',Contrasena='{11}' where UsuarioId={12} ", this.fecha, this.imagen, this.nombre, this.apellido, this.direccion, this.Cedula, this.telefono, this.email, this.ciudadId, this.nommbreUsuario, this.tipoUsuario, this.contrasena,this.usuarioId));
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
                retorno = conexion.Ejecutar(String.Format("delete from Usuarios where UsuarioId={0}",this.usuarioId));
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
                    this.fecha = data.Rows[0]["Fecha"].ToString();
                    this.imagen = data.Rows[0]["Imagen"].ToString();
                    this.usuarioId = (int)data.Rows[0]["UsuarioId"];
                    this.nombre = data.Rows[0]["Nombres"].ToString();
                    this.apellido = data.Rows[0]["Apellidos"].ToString();
                    this.direccion = data.Rows[0]["Direccion"].ToString();
                    this.Cedula = data.Rows[0]["Cedula"].ToString();
                    this.telefono = data.Rows[0]["Telefono"].ToString();
                    this.email = data.Rows[0]["Email"].ToString();
                    this.ciudadId = (int)data.Rows[0]["CiudadId"];
                    this.nommbreUsuario = data.Rows[0]["NombresUsuarios"].ToString();
                    this.tipoUsuario = data.Rows[0]["TipoUsuario"].ToString();
                    this.contrasena = data.Rows[0]["Contrasena"].ToString();
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
