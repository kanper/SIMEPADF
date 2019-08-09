using System.Collections.Generic;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class FuenteDato : AudityEntity, ISoftDeleted
    {
        public FuenteDato()
        {
        }

        public FuenteDato(string nombreFuente)
        {
            NombreFuente = nombreFuente;
        }

        public int Id { get; set; }
        public string NombreFuente { get; set; }

        public ICollection<PlanMonitoreoEvaluacion> Planes { get; set; }                

        public bool Deleted { get; set; }
       
    }
}