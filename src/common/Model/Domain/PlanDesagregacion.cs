using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Domain
{
    public class PlanDesagregacion
    {
        public PlanDesagregacion()
        {
        }

        public PlanDesagregacion(PlanMonitoreoEvaluacion planMonitoreoEvaluacion, Desagregacion desagregacion)
        {
            PlanMonitoreoEvaluacion = planMonitoreoEvaluacion;
            Desagregacion = desagregacion;
        }
       
        public PlanMonitoreoEvaluacion PlanMonitoreoEvaluacion { get; set; }

        public string PlanMonitoreoEvaluacionProyectoCodigoProyecto { get; set; }
               
        public int PlanMonitoreoEvaluacionIndicadorId { get; set; }


        public int DesagregacionId { get; set; }
        public Desagregacion Desagregacion { get; set; }
        
    }
}