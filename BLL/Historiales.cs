using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class Historiales : ClaseMaestra
    {

        ConexionDb conexion = new ConexionDb();

        public int HistorialId { get; set; }
        public string CentroSalud { get; set; }
        public int ProvinciaId { get; set; }
        public int MunicipioId { get; set; }
        public int PacienteId { get; set; }
        public List<HistorialVacuna> historialVacuna { get; set; }


        public Historiales()
        {
            this.HistorialId = 0;
            this.CentroSalud = "";
            this.ProvinciaId = 0;
            this.MunicipioId = 0;
            this.PacienteId = 0;
            historialVacuna = new List<HistorialVacuna>();
        }

        public Historiales(int historialId, string CentroSalud, int provinciaId, int municipioId, int pacienteId)
        {
            this.HistorialId = historialId;
            this.CentroSalud = CentroSalud;
            this.ProvinciaId = provinciaId;
            this.MunicipioId = municipioId;
            this.PacienteId = pacienteId;
        }

        public void AgregarVacuna(int vacunaId, bool esUnica, int dosis)
        {
            historialVacuna.Add(new HistorialVacuna(vacunaId, esUnica, dosis));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;
            try
            {
                identity = conexion.Ejecutar(String.Format("insert into Histortiales(CentroSalud,ProvinciaId,MunicipioId,PacienteId) values('{0}',{1},{2},{3}')", this.CentroSalud, this.MunicipioId, this.ProvinciaId, this.PacienteId));

                int.TryParse(identity.ToString(), out retorno);
                this.HistorialId = retorno;
                foreach (HistorialVacuna item in historialVacuna)
                {
                    conexion.Ejecutar(String.Format("insert into HistorialesVacunas(HistorialId,VacunaId,EsUnica,Dosis) values({0},{1},{2},{3})", retorno, item.VacunaId, item.EsUnica, item.EsUnica));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("update Historiales set CentroSalud='{0}',ProvinciaId={1},MunicipioId={2} where HistorialId={3}", this.CentroSalud, this.MunicipioId, this.ProvinciaId, this.PacienteId, this.HistorialId));
                if (retorno)
                {
                    conexion.Ejecutar(String.Format("delete from Historiales where HistorialId={0}", this.HistorialId));
                    foreach (HistorialVacuna item in historialVacuna)
                    {
                        conexion.Ejecutar(String.Format("insert into PacientesVacunas(HistorialId,VacunaId,EsUnica,Dosis) values({0},{1},{2},{3})", this.HistorialId, item.VacunaId, item.EsUnica, item.Dosis));
                    }
                }
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
                retorno = conexion.Ejecutar(String.Format("delete from HistorialesVacunas where HistorialId={0}; "+"delete from Vacunas where HistorialId={0} ",this.HistorialId));
            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campo, string Condicion, string Orden)
        {
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Order by" + Orden;
            return conexion.ObtenerDatos("Select " + Campo + " from Historiales where " + Condicion + Orden);

        }

        public static DataTable ListadoHist(string Condicion)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.ObtenerDatos("Select * from Historiales where " + Condicion);

        }
    }
}
