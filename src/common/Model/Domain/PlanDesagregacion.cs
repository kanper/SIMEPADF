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
        public string PlanProyectoId {
            get { return PlanMonitoreoEvaluacion.ProyectoId; }
            set { }
        }

        public int PlanIndicadorId
        {
            get { return PlanMonitoreoEvaluacion.IndicadorId; }
            set { }
        }

        public int DesagregacionId { get; set; }
        public Desagregacion Desagregacion { get; set; }
        
    }
}