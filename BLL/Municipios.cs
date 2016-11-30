using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Municipios : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int MunicipioId { get; set; }
        public string Descripcion { get; set; }

        public Municipios()
        {
            this.MunicipioId = 0;
            this.Descripcion = "";
        }

        public Municipios(int provinciaId, string descripcion)
        {
            this.MunicipioId = provinciaId;
            this.Descripcion = descripcion;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Municipios(Descripcion) values('{0}')", this.Descripcion));
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
                retorno = conexion.Ejecutar(String.Format("update Municipios set Descripcion='{0}' where MunicipioId={1}", this.Descripcion, this.MunicipioId));
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
                retorno = conexion.Ejecutar(String.Format("delete from MUnicipios where MunicipioId={0}", this.MunicipioId));
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
                data = conexion.ObtenerDatos(String.Format("Select * from Municipios where MunicipioId= " + IdBuscado));
                if (data.Rows.Count > 0)
                {
                    this.MunicipioId = (int)data.Rows[0]["MunicipioId"];
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
            return conexion.ObtenerDatos("Select " + Campo + "from Municipios where " + Condicion + Orden);
        }

        public static DataTable ListadoMun(string condicion)
        {
            ConexionDb conexion  = new ConexionDb();
            return conexion.ObtenerDatos("select * from Municipios where " + condicion);
        }
    }
}

