using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class NivelImpacto : AudityEntity, ISoftDeleted
    {
        public NivelImpacto()
        {
        }

        public NivelImpacto(string nombreNivelImpacto)
        {
            NombreNivelImpacto = nombreNivelImpacto;
        }

        public int Id { get; set; }
        public string NombreNivelImpacto { get; set; }

        public ICollection<PlanMonitoreoEvaluacion> Planes { get; set; }

        public bool Deleted { get; set; }
    }
}