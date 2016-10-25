using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Provincias : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int ProvinciaId { get; set; }
        public string Descripcion { get; set; }

        public Provincias()
        {
            this.ProvinciaId = 0;
            this.Descripcion = "";
        }

        public Provincias(int provinciaId, string descripcion)
        {
            this.ProvinciaId = provinciaId;
            this.Descripcion = descripcion;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Provincias(Descripcion) values('{0}')", this.Descripcion));
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
                retorno = conexion.Ejecutar(String.Format("update Provincias set Descripcion='{0}' where ProvinciaId={1}", this.Descripcion, this.ProvinciaId));
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
                retorno = conexion.Ejecutar(String.Format("delete from Provincias where ProvinciaId={0}", this.ProvinciaId));
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
                data = conexion.ObtenerDatos(String.Format("Select * from Provincias where ProvinciaId= " + IdBuscado));
                if (data.Rows.Count > 0)
                {
                    this.ProvinciaId = (int)data.Rows[0]["ProvinciaId"];
                    this.Descripcion = data.Rows[0]["Descripcion"].ToString();
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
            return conexion.ObtenerDatos("Select" + Campo + "from Provincias where " + Condicion + Orden);
        }
    }
}
