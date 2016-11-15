using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Pacientes : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }

        public Pacientes()
        {
            this.PacienteId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Edad = 0;
            this.Sexo = 0;
            this.Direccion = "";
            this.Telefono = "";
            this.Cedula = "";
        }


        public Pacientes(int pacienteId, string nombres, string apellidos, int edad, int sexo, string direccion, string telefono, string cedula)
        {
            this.PacienteId = pacienteId;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Sexo = sexo;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Cedula = cedula;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("Insert Into Pacientes(Nombres,Apellidos,Edad,Sexo,Direccion,Telefono,Cedula) values('{0}','{1}',{2},{3},'{4}','{5}','{6}') ",
                    this.Nombres, this.Apellidos, this.Edad, this.Sexo, this.Direccion, this.Telefono, this.Cedula));

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
                retorno = conexion.Ejecutar(String.Format("update Pacientes set Nombres='{0}',Apellidos='{1}',Edad={2},Sexo={3},Direccion='{4}',Telefono='{5}',Cedula = {6} where PacienteId = {7} ",
                    this.Nombres, this.Apellidos, this.Edad, this.Sexo, this.Direccion, this.Telefono, this.Cedula, this.PacienteId));

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
                retorno = conexion.Ejecutar(String.Format("delete from Pacientes where PacienteId={0} ", this.PacienteId));

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
            data = conexion.ObtenerDatos(String.Format("select * from Pacientes where PacienteId= " + IdBuscado));

            if (data.Rows.Count > 0)
            {
                this.PacienteId = (int)data.Rows[0]["PacienteId"];
                this.Nombres = data.Rows[0]["Nombres"].ToString();
                this.Apellidos = data.Rows[0]["Apellidos"].ToString();
                this.Edad = (int)data.Rows[0]["Edad"];
                this.Sexo = (int)data.Rows[0]["Sexo"];
                this.Direccion = data.Rows[0]["Direccion"].ToString();
                this.Telefono = data.Rows[0]["Telefono"].ToString();
                this.Cedula = data.Rows[0]["Cedula"].ToString();

            }
            return data.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            if (!ordenFinal.Equals(""))
                ordenFinal = " Order by " + Orden;
            return conexion.ObtenerDatos(" select " + Campos + " From Pacientes where " + Condicion + Orden);
        }

    }
}
