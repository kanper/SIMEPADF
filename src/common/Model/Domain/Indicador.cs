using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Indicador : AudityEntity, ISoftDeleted
    {
        public Indicador() {}

        public Indicador(string nombreIndicador, double meta)
        {
            NombreIndicador = nombreIndicador;
            Meta = new Meta(meta);
            TipoBeneficiario = "N";
        }

        [ForeignKey("Actividad")]
        public int CodigoIndicador { get; set; }
        public string NombreIndicador { get; set; }
        public string TipoBeneficiario { get; set; }
        public virtual Actividad Actividad { get; set; }
        public virtual Meta Meta { get; set; }

        public ICollection<PlanMonitoreoEvaluacion> PlanMonitoreoEvaluaciones { get; set; }
        public bool Deleted { get; set; }       
    }
}