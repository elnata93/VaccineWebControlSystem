using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class HistorialesVacunas
    {
        public int PacienteVacunaId { get; set; }
        public int VacunaId { get; set; }
        public int Dosis { get; set; }
        public string Fecha { get; set; }

        public HistorialesVacunas()
        {
            this.VacunaId = 0;
            this.Dosis = 0;
            this.Fecha = "";
        }
        public HistorialesVacunas(int vacunaId,int dosis, string fecha)
        {
            this.VacunaId = vacunaId;
            this.Dosis = dosis;
            this.Fecha = fecha;
        }
    }
}
