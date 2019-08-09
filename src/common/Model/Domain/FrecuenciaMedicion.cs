using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class FrecuenciaMedicion : AudityEntity, ISoftDeleted
    {
        public FrecuenciaMedicion()
        {
        }

        public FrecuenciaMedicion(string nombreFrecuencia)
        {
            NombreFrecuencia = nombreFrecuencia;
        }

        public int Id { get; set; }
        public string NombreFrecuencia { get; set; }

        public ICollection<PlanMonitoreoEvaluacion> Planes { get; set; }

        public bool Deleted { get; set; }
    }
}