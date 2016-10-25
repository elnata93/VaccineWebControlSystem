using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Vacunas : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();

        public int vacunaId { get; set; }
        public string nombreVacuna { get; set; }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Vacunas(NombreVacuna) values('{0}')",this.nombreVacuna));
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
                retorno = conexion.Ejecutar(String.Format("update Vacunas set NombreVacuna='{0}' where VacunaId={1}",this.nombreVacuna,this,vacunaId));
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
                retorno = conexion.Ejecutar(String.Format("delete from Vacunas where VacunaId={0}",this.vacunaId));
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
                data = conexion.ObtenerDatos(String.Format("select * from Vacunas where VacunaId=" + IdBuscado));
                if(data.Rows.Count > 0)
                {
                    this.vacunaId = (int)data.Rows[0]["VacunaId"];
                    this.nombreVacuna = data.Rows[0]["NombreVacuna"].ToString();

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
                OrdenFinal = "Oder by" + Orden;
            return conexion.ObtenerDatos("select" + Campo + "fron Vacunas where" + Condicion + Orden);
        }
    }
}
