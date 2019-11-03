namespace Model.Domain
{
    public class PlanSocioDesagregacion
    {
        public double Valor { get; set; }
        public int Trimestre { get; set; }
        public string PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto { get; set; }
        public int PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId { get; set; }
        public int PlanDesagregacionDesagregacionId { get; set; }
        public PlanDesagregacion PlanDesagregacion { get; set; }
        public int ProyectoSocioSocioInternacionalId { get; set; }
        public ProyectoSocio ProyectoSocio { get; set; }
    }
}