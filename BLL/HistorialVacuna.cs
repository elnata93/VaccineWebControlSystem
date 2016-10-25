using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class HistorialVacuna
    {
        public int PacienteVacunaId { get; set; }
        public int VacunaId { get; set; }
        public bool EsUnica { get; set; }
        public int Dosis { get; set; }

        public HistorialVacuna()
        {
            this.VacunaId = 0;
            this.EsUnica = true;
            this.Dosis = 0;
        }
        public HistorialVacuna(int vacunaId,bool esUnica,int dosis)
        {
            this.VacunaId = vacunaId;
            this.EsUnica = esUnica;
            this.Dosis = dosis;
        }
    }
}
