using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class HistorialDetalle
    {
        public int PacienteVacunaId { get; set; }
        public int VacunaId { get; set; }
        public int Dosis { get; set; }
        public string Fecha { get; set; }

        public HistorialDetalle()
        {
            this.VacunaId = 0;
            this.Dosis = 0;
            this.Fecha = "";
        }
        public HistorialDetalle(int vacunaId,int dosis, string fecha)
        {
            this.VacunaId = vacunaId;
            this.Dosis = dosis;
            this.Fecha = fecha;
        }
    }
}
