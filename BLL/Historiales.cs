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
        public string Fecha { get; set; }
        public string CentroSalud { get; set; }
        public int ProvinciaId { get; set; }
        public int MunicipioId { get; set; }
        public int PacienteId { get; set; }
        public List<HistorialVacuna> historialVacuna { get; set; }


        public Historiales()
        {

            this.HistorialId = 0;
            this.Fecha = "";
            this.CentroSalud = "";
            this.ProvinciaId = 0;
            this.MunicipioId = 0;
            this.PacienteId = 0;
            historialVacuna = new List<HistorialVacuna>();
        }

        public Historiales(int historialId, string fecha,string centroSalud, int provinciaId, int municipioId, int pacienteId)
        {
            this.HistorialId = historialId;
            this.Fecha = fecha;
            this.CentroSalud = centroSalud;
            this.ProvinciaId = provinciaId;
            this.MunicipioId = municipioId;
            this.PacienteId = pacienteId;
        }

        public void AgregarVacuna(int esUnica, int vacunaId,  int dosis,string fecha)
        {
            historialVacuna.Add(new HistorialVacuna(esUnica, vacunaId,  dosis, fecha));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;
            try
            {
                identity = conexion.ObtenerValor(String.Format("insert into Historiales(Fecha,CentroSalud,ProvinciaId,MunicipioId,PacienteId) values('{0}','{1}',{2},{3},{4}) select @@Identity ", this.Fecha,this.CentroSalud, this.MunicipioId, this.ProvinciaId, this.PacienteId));

                int.TryParse(identity.ToString(), out retorno);
                this.HistorialId = retorno;
                foreach (HistorialVacuna item in historialVacuna)
                {
                    conexion.Ejecutar(String.Format("insert into HistorialDetalle(HistorialId,EsUnica,VacunaId,Dosis,Fecha) values({0},{1},{2},{3},'{4}')", retorno,item.EsUnica,item.VacunaId,item.EsUnica,item.Fecha));
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
                retorno = conexion.Ejecutar(String.Format("update Historiales set Fecha='{0}',CentroSalud='{1}',ProvinciaId={2},MunicipioId={3},PacienteId={4} where HistorialId={5}", this.Fecha, this.CentroSalud, this.MunicipioId, this.ProvinciaId, this.PacienteId, this.HistorialId));
                if (retorno)
                {
                    conexion.Ejecutar(String.Format("delete from PacientesVacunas where HistorialId={0}", this.HistorialId));
                    foreach (HistorialVacuna item in historialVacuna)
                    {
                        conexion.Ejecutar(String.Format("insert into PacientesVacunas(HistorialId,EsUnica,VacunaId,Dosis,Fecha) values({0},{1},{2},{3},'{4}')", this.HistorialId, item.EsUnica, item.VacunaId, item.Dosis,item.Fecha));
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
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
			DataTable data = new DataTable();
			try
			{
				dt = conexion.ObtenerDatos(String.Format("select * from Historiales where HistorialId= " + IdBuscado));
				if(dt.Rows.Count > 0)
				{
					this.HistorialId = (int)dt.Rows[0]["HistorialId"];
					this.CentroSalud = dt.Rows[0]["CentroSalud"].ToString();
					this.ProvinciaId = (int)dt.Rows[0]["ProvinciaId"];
					this.MunicipioId = (int)dt.Rows[0]["MunicipioId"];
                    this.PacienteId = (int)dt.Rows[0]["PacienteId"];
                    data = conexion.ObtenerDatos(String.Format("Select * from HistorialDetalle where HistorialId= " + IdBuscado));
					foreach (DataRow item in data.Rows)
					{
						this.AgregarVacuna((int)data.Rows[0]["EsUnica"],(int)data.Rows[0]["VacunaId"], (int)data.Rows[0]["Dosis"], data.Rows[0]["Fecha"].ToString()); 
					}
				}
			}
			catch(Exception ex)
			{
                throw ex;
			}
            return dt.Rows.Count > 0;
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
