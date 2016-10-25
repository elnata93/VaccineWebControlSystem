using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Ciudades : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int ciudadId { get; set; }
        public string descripcion { get; set; }

        public Ciudades()
        {
            this.ciudadId = 0;
            this.descripcion = "";
        }

        public Ciudades(int ciudadid,string descripcion)
        {
            this.ciudadId = ciudadid;
            this.descripcion = descripcion;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Ciudades(Descripcion) values('{0}')",this.descripcion));
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
                retorno = conexion.Ejecutar(String.Format("update Ciudades set Descripcion='{0}' where CiudadId={1}",this.descripcion,this.ciudadId));
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
                retorno = conexion.Ejecutar(String.Format("delete from Ciudades where CiudadId={0}",this.ciudadId));
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
                data = conexion.ObtenerDatos(String.Format("Select * from Ciudades where CiudadId= " + IdBuscado));
                if(data.Rows.Count > 0)
                {
                    this.ciudadId = (int)data.Rows[0]["CiudadId"];
                    this.descripcion = data.Rows[0]["Descripcion"].ToString();
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
            return conexion.ObtenerDatos("Select" + Campo + "from Ciudades where " + Condicion + Orden);
        }
    }
}
