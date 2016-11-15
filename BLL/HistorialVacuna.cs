using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class HistorialVacuna
    {
        public int PacienteVacunaId { get; set; }
        public int EsUnica { get; set; }
        public int VacunaId { get; set; }
        public int Dosis { get; set; }
        public string Fecha { get; set; }

        public HistorialVacuna()
        {
            this.VacunaId = 0;
            this.EsUnica = 0;
            this.Dosis = 0;
            this.Fecha = "";
        }
        public HistorialVacuna(int esUnica,int vacunaId,int dosis, string fecha)
        {
            this.EsUnica = esUnica;
            this.VacunaId = vacunaId;
            this.Dosis = dosis;
            this.Fecha = fecha;
        }
    }
}
